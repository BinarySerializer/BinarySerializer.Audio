using BinarySerializer.Audio.RIFF;
using System.Text;

namespace BinarySerializer.Audio.SF2 {
	public class RIFF_Chunk_SF2_Info_SoundEngine : RIFF_ChunkData
    {
		public override string ChunkIdentifier => "isng";
        public string SoundEngineName { get; set; }

		public override void SerializeImpl(SerializerObject s) {
			SoundEngineName = s.SerializeString(SoundEngineName, encoding: Encoding.ASCII, name: nameof(SoundEngineName));
		}
    }
}