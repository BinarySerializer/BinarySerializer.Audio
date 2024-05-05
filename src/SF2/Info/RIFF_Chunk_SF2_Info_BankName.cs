using System.Text;
using BinarySerializer.Audio.RIFF;

namespace BinarySerializer.Audio.SF2
{
    public class RIFF_Chunk_SF2_Info_BankName : RIFF_ChunkData
    {
        public override string ChunkIdentifier => "INAM";
        public string SoundFontBankName { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            SoundFontBankName = s.SerializeString(SoundFontBankName, encoding: Encoding.ASCII, name: nameof(SoundFontBankName));
        }
    }
}