using System.Text;

namespace BinarySerializer.Audio.RIFF
{
    public class RIFF_Chunk_Label : RIFF_ChunkData
    {
        public override string ChunkIdentifier => "labl";

        public uint CuePointID { get; set; }
        public string Text { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
			CuePointID = s.Serialize<uint>(CuePointID, name: nameof(CuePointID));
			Text = s.SerializeString(Text, encoding: Encoding.ASCII, name: nameof(Text));
        }
    }
}