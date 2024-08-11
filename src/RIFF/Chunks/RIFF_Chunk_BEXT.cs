namespace BinarySerializer.Audio.RIFF
{
    // Metadata from Pro Tools
    public class RIFF_Chunk_BEXT : RIFF_ChunkData
    {
        public override string ChunkIdentifier => "bext";

        public string Description { get; set; }
        public string Originator { get; set; }
        public string OriginatorReference { get; set; }
        public string OriginationDate { get; set; }
        public string OriginationTime { get; set; }
        public uint TimeReferenceLow { get; set; }
        public uint TimeReferenceHigh { get; set; }
        public ushort Version { get; set; }
        public byte[] Umid { get; set; }
        public ushort LoudnessValue { get; set; }
        public ushort LoudnessRange { get; set; }
        public ushort MaxTruePeakLevel { get; set; }
        public ushort MaxMomentaryLoudness { get; set; }
        public ushort MaxShortTermLoudness { get; set; }
        public byte[] Reserved { get; set; }
        public byte[] CodingHistory { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Description = s.SerializeString(Description, length: 256, name: nameof(Description));
            Originator = s.SerializeString(Originator, length: 32, name: nameof(Originator));
            OriginatorReference = s.SerializeString(OriginatorReference, length: 32, name: nameof(OriginatorReference));
            OriginationDate = s.SerializeString(OriginationDate, length: 10, name: nameof(OriginationDate));
            OriginationTime = s.SerializeString(OriginationTime, length: 8, name: nameof(OriginationTime));
            TimeReferenceLow = s.Serialize<uint>(TimeReferenceLow, name: nameof(TimeReferenceLow));
            TimeReferenceHigh = s.Serialize<uint>(TimeReferenceHigh, name: nameof(TimeReferenceHigh));
            Version = s.Serialize<ushort>(Version, name: nameof(Version));
            Umid = s.SerializeArray<byte>(Umid, 64, name: nameof(Umid));
            LoudnessValue = s.Serialize<ushort>(LoudnessValue, name: nameof(LoudnessValue));
            LoudnessRange = s.Serialize<ushort>(LoudnessRange, name: nameof(LoudnessRange));
            MaxTruePeakLevel = s.Serialize<ushort>(MaxTruePeakLevel, name: nameof(MaxTruePeakLevel));
            MaxMomentaryLoudness = s.Serialize<ushort>(MaxMomentaryLoudness, name: nameof(MaxMomentaryLoudness));
            MaxShortTermLoudness = s.Serialize<ushort>(MaxShortTermLoudness, name: nameof(MaxShortTermLoudness));
            Reserved = s.SerializeArray<byte>(Reserved, 180, name: nameof(Reserved));
            CodingHistory = s.SerializeArray<byte>(CodingHistory, Offset + Pre_ChunkSize - s.CurrentPointer, name: nameof(CodingHistory));
        }
    }
}