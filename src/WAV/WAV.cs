using BinarySerializer.Audio.RIFF;

namespace BinarySerializer.Audio
{
    /// <summary>
    /// WAV audio file data, mainly to use as a shortcut to create RIFF files easier
    /// </summary>
    public class WAV : BinarySerializable
    {
        private RIFF_Chunk RootChunk { get; set; }

        public RIFF_Chunk Root => RootChunk ??= new RIFF_Chunk_RIFF()
        {
            Type = "WAVE",
            Chunks = new[]
            {
                new RIFF_Chunk_Format().CreateChunk(),
                new RIFF_Chunk_Data().CreateChunk()
            },
        }.CreateChunk();

        public RIFF_Chunk_RIFF Riff => (RIFF_Chunk_RIFF)Root.Data;
        public RIFF_Chunk_Format Format => Riff.GetRequiredChunk<RIFF_Chunk_Format>();
        public RIFF_Chunk_Data Data => Riff.GetRequiredChunk<RIFF_Chunk_Data>();

        public override void SerializeImpl(SerializerObject s)
        {
            RootChunk = s.SerializeObject<RIFF_Chunk>(Root, name: nameof(RootChunk));

            if (!(RootChunk.Data is RIFF_Chunk_RIFF { Type: "WAVE" }))
                throw new BinarySerializableException(this, "The file is not a valid WAVE file");
        }
    }
}