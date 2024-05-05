namespace BinarySerializer.Audio
{
    /// <summary>
    /// XM audio file data
    /// </summary>
    public class XM_Pattern : BinarySerializable
    {
        public int Pre_NumChannels { get; set; }

        public uint PatternHeaderLength { get; set; } = 9;
        public byte PackingType { get; set; } = 0;
        public ushort NumRows { get; set; }
        public ushort PackedPatternDataSize { get; set; }

        public XM_PatternRow[] PatternRows { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            PatternHeaderLength = s.Serialize<uint>(PatternHeaderLength, name: nameof(PatternHeaderLength));
            PackingType = s.Serialize<byte>(PackingType, name: nameof(PackingType));
            NumRows = s.Serialize<ushort>(NumRows, name: nameof(NumRows));
            PackedPatternDataSize = s.Serialize<ushort>(PackedPatternDataSize, name: nameof(PackedPatternDataSize));

            if (PatternRows == null)
            {
                PatternRows = s.SerializeObjectArray<XM_PatternRow>(PatternRows, Pre_NumChannels * NumRows, name: nameof(PatternRows));
            }
            else
            {
                PatternRows = s.SerializeObjectArray<XM_PatternRow>(PatternRows, PatternRows.Length, name: nameof(PatternRows));
            }
            if (s.CurrentAbsoluteOffset != Offset.AbsoluteOffset + PackedPatternDataSize + 4 + 1 + 2 + 2)
            {
                s.SystemLogger?.LogWarning("XM: Incorrect Pattern Size");
            }
        }
    }
}