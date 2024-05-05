using BinarySerializer.Audio.RIFF;
using System.Text;

namespace BinarySerializer.Audio.SF2 {
	public class RIFF_Chunk_SF2_SampleHeaders : RIFF_ChunkData {
		public override string ChunkIdentifier => "shdr";
		public SampleHeader[] Headers { get; set; }

		public override void SerializeImpl(SerializerObject s) {
			Headers = s.SerializeObjectArray<SampleHeader>(Headers, Pre_ChunkSize / SampleHeader.StructSize, name: nameof(Headers));
		}

		public class SampleHeader : BinarySerializable {
			public const int StructSize = 0x2E;

			public string Name { get; set; }
			public uint StartOffset { get; set; }
			public uint EndOffset { get; set; }
			public uint StartLoop { get; set; }
			public uint EndLoop { get; set; }
			public uint SampleRate { get; set; }
			public byte OriginalKey { get; set; }
			public sbyte PitchCorrection { get; set; }
			public ushort SampleLink { get; set; }
			public SF2_SampleLink Type { get; set; }

			public override void SerializeImpl(SerializerObject s) {
				Name = s.SerializeString(Name, length: 20, encoding: Encoding.ASCII, name: nameof(Name));
				StartOffset = s.Serialize<uint>(StartOffset, name: nameof(StartOffset));
				EndOffset = s.Serialize<uint>(EndOffset, name: nameof(EndOffset));
				StartLoop = s.Serialize<uint>(StartLoop, name: nameof(StartLoop));
				EndLoop = s.Serialize<uint>(EndLoop, name: nameof(EndLoop));
				SampleRate = s.Serialize<uint>(SampleRate, name: nameof(SampleRate));
				OriginalKey = s.Serialize<byte>(OriginalKey, name: nameof(OriginalKey));
				PitchCorrection = s.Serialize<sbyte>(PitchCorrection, name: nameof(PitchCorrection));
				SampleLink = s.Serialize<ushort>(SampleLink, name: nameof(SampleLink));
				Type = s.Serialize<SF2_SampleLink>(Type, name: nameof(Type));
			}
		}
	}
}