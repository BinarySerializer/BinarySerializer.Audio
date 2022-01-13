using BinarySerializer.Audio.RIFF;

namespace BinarySerializer.Audio.SF2 {
	public class RIFF_Chunk_SF2_Info_VersionTag : RIFF_ChunkData
    {
		public override string ChunkIdentifier => "ifil";
        public ushort Major { get; set; }
        public ushort Minor { get; set; }

		public override void SerializeImpl(SerializerObject s) {
			Major = s.Serialize<ushort>(Major, name: nameof(Major));
			Minor = s.Serialize<ushort>(Minor, name: nameof(Minor));
		}
    }
}