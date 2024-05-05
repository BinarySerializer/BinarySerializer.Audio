using System.Text;
using BinarySerializer.Audio.RIFF;

namespace BinarySerializer.Audio.SF2
{
    public class RIFF_Chunk_SF2_Info_Comment : RIFF_ChunkData
    {
        public override string ChunkIdentifier => "ICMT";
        public string Comment { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Comment = s.SerializeString(Comment, encoding: Encoding.ASCII, name: nameof(Comment));
        }
    }
}