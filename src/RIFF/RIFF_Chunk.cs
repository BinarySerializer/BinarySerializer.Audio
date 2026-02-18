using System.Text;

namespace BinarySerializer.Audio.RIFF
{
    /// <summary>
    /// RIFF (Resource Interchange File Format) file data
    /// </summary>
    public class RIFF_Chunk : BinarySerializable
    {
        public string Identifier { get; set; }
        public RIFF_ChunkData Data { get; set; }

        private void SerializeChunk(SerializerObject s, long chunkSize)
        {
            RIFFSettings settings = s.GetRequiredSettings<RIFFSettings>();
            RIFFSettings.ChunkResolver resolver = settings.GetChunkResolver(Identifier);

            if (resolver == null)
            {
                Data = s.SerializeObject<RIFF_Chunk_Unknown>((RIFF_Chunk_Unknown)Data, onPreSerialize: x =>
                {
                    x.Pre_ChunkSize = chunkSize;
                    x.Pre_Identifier = Identifier;
                }, name: nameof(Data));
            }
            else
            {
                Data = resolver(s, Data, chunkSize, nameof(Data));
            }
        }

        public override void SerializeImpl(SerializerObject s)
        {
            Identifier = s.SerializeString(Identifier, 4, Encoding.ASCII, name: nameof(Identifier));
            s.DoProcessed(new DataLengthProcessor(), p =>
            {
                p.Serialize<uint>(s, name: "Size");
                SerializeChunk(s, p.SerializedValue);
            });
            s.Align(2, baseOffset: Offset);
        }
    }
}