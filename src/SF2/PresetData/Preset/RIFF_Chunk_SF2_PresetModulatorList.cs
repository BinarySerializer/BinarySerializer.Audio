using BinarySerializer.Audio.RIFF;

namespace BinarySerializer.Audio.SF2 {
	public class RIFF_Chunk_SF2_PresetModulatorList : RIFF_ChunkData {
		public override string ChunkIdentifier => "pmod";
		public SF2_ModulatorEntry[] Modulators { get; set; }

		public override void SerializeImpl(SerializerObject s) {
			Modulators = s.SerializeObjectArray<SF2_ModulatorEntry>(Modulators, ChunkSize / SF2_ModulatorEntry.StructSize, name: nameof(Modulators));
		}
	}
}