namespace BinarySerializer.Audio.RIFF
{
    public class RIFF_Chunk_Cue : RIFF_ChunkData
    {
        public override string ChunkIdentifier => "cue ";

        public uint CuePointsCount { get; set; }
        public CuePoint[] CuePoints { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            CuePointsCount = s.Serialize<uint>(CuePointsCount, name: nameof(CuePointsCount));
            CuePoints = s.SerializeObjectArray<CuePoint>(CuePoints, CuePointsCount, name: nameof(CuePoints));
        }

        public class CuePoint : BinarySerializable
        {
            public uint Id { get; set; }
            public uint Position { get; set; }
            public string DataChunkId { get; set; }
            public uint ChunkStart { get; set; }
            public uint BlockStart { get; set; }
            public uint SampleStart { get; set; }

            public override void SerializeImpl(SerializerObject s)
            {
                Id = s.Serialize<uint>(Id, name: nameof(Id));
                Position = s.Serialize<uint>(Position, name: nameof(Position));
                DataChunkId = s.SerializeString(DataChunkId, length: 4, name: nameof(DataChunkId));
                ChunkStart = s.Serialize<uint>(ChunkStart, name: nameof(ChunkStart));
                BlockStart = s.Serialize<uint>(BlockStart, name: nameof(BlockStart));
                SampleStart = s.Serialize<uint>(SampleStart, name: nameof(SampleStart));
            }
        }
    }
}