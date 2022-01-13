using BinarySerializer.Audio.RIFF;

namespace BinarySerializer.Audio.SF2 {
	public class RIFF_Chunk_SF2_PresetGeneratorList : RIFF_ChunkData {
		public override string ChunkIdentifier => "pgen";
		public SF2_GeneratorEntry[] Generators { get; set; }

		public override void SerializeImpl(SerializerObject s) {
			Generators = s.SerializeObjectArray<SF2_GeneratorEntry>(Generators, ChunkSize / SF2_GeneratorEntry.StructSize, name: nameof(Generators));
		}
	}
}