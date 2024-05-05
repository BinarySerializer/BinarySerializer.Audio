namespace BinarySerializer.Audio.RIFF
{
    public class RIFF_Chunk_Unknown : RIFF_ChunkData
    {
        public string Pre_Identifier { get; set; }

        public override string ChunkIdentifier => Pre_Identifier;

        public byte[] Data { get; set; }

        public override void SerializeImpl(SerializerObject s) 
        {
            Data = s.SerializeArray<byte>(Data, Pre_ChunkSize, name: nameof(Data));
        }
    }
}