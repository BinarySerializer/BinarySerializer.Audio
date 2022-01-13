using BinarySerializer.Audio.RIFF;
using System.Text;

namespace BinarySerializer.Audio.SF2 {
	public class RIFF_Chunk_SF2_PresetHeaders : RIFF_ChunkData {
		public override string ChunkIdentifier => "phdr";
		public PresetHeader[] Headers { get; set; }

		public override void SerializeImpl(SerializerObject s) {
			Headers = s.SerializeObjectArray<PresetHeader>(Headers, ChunkSize / PresetHeader.StructSize, name: nameof(Headers));
		}

		public class PresetHeader : BinarySerializable {
			public const int StructSize = 0x26;

			public string Name { get; set; }
			public ushort Preset { get; set; }
			public ushort Bank { get; set; }
			public ushort BagIndex { get; set; }
			public uint Library { get; set; }
			public uint Genre { get; set; }
			public uint Morphology { get; set; }

			public override void SerializeImpl(SerializerObject s) {
				Name = s.SerializeString(Name, length: 20, encoding: Encoding.ASCII, name: nameof(Name));
				Preset = s.Serialize<ushort>(Preset, name: nameof(Preset));
				Bank = s.Serialize<ushort>(Bank, name: nameof(Bank));
				BagIndex = s.Serialize<ushort>(BagIndex, name: nameof(BagIndex));
				Library = s.Serialize<uint>(Library, name: nameof(Library));
				Genre = s.Serialize<uint>(Genre, name: nameof(Genre));
				Morphology = s.Serialize<uint>(Morphology, name: nameof(Morphology));
			}
		}
	}
}