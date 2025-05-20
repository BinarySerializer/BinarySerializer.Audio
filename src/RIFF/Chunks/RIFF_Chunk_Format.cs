namespace BinarySerializer.Audio.RIFF
{
    public class RIFF_Chunk_Format : RIFF_ChunkData
    {
        public override string ChunkIdentifier => "fmt ";

        public ushort FormatType { get; set; }
        public ushort ChannelCount { get; set; }
        public uint SampleRate { get; set; }
        public uint ByteRate { get; set; }
        public ushort BlockAlign { get; set; }
        public ushort BitsPerSample { get; set; }
        public byte[] AdditionalData { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            FormatType = s.Serialize<ushort>(FormatType, name: nameof(FormatType));
            ChannelCount = s.Serialize<ushort>(ChannelCount, name: nameof(ChannelCount));
            SampleRate = s.Serialize<uint>(SampleRate, name: nameof(SampleRate));
            ByteRate = s.Serialize<uint>(ByteRate, name: nameof(ByteRate));
            BlockAlign = s.Serialize<ushort>(BlockAlign, name: nameof(BlockAlign));
            BitsPerSample = s.Serialize<ushort>(BitsPerSample, name: nameof(BitsPerSample));

            long additionalDataLength = Pre_ChunkSize - 16;
            if (additionalDataLength < 0)
                additionalDataLength = 0;
            AdditionalData = s.SerializeArray<byte>(AdditionalData, additionalDataLength, name: nameof(AdditionalData));
        }
    }
}