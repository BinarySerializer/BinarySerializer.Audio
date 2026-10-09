using System.Text;

namespace BinarySerializer.Audio.RIFF
{
    public class RIFF_Chunk_LabeledText : RIFF_ChunkData
    {
        public override string ChunkIdentifier => "ltxt";

        public uint CuePointID { get; set; }
        public uint SampleLength { get; set; }
        public string PurposeID { get; set; }
        public ushort Country { get; set; }
        public ushort Language { get; set; }
        public ushort Dialect { get; set; }
        public ushort CodePage { get; set; }
        public string Text { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
			CuePointID = s.Serialize<uint>(CuePointID, name: nameof(CuePointID));
			SampleLength = s.Serialize<uint>(SampleLength, name: nameof(SampleLength));
			PurposeID = s.SerializeString(PurposeID, 4, encoding: Encoding.ASCII, name: nameof(PurposeID));
			Country = s.Serialize<ushort>(Country, name: nameof(Country));
			Language = s.Serialize<ushort>(Language, name: nameof(Language));
			Dialect = s.Serialize<ushort>(Dialect, name: nameof(Dialect));
			CodePage = s.Serialize<ushort>(CodePage, name: nameof(CodePage));
            if (s.CurrentFileOffset - Offset.FileOffset < Pre_ChunkSize) {
                Text = s.SerializeString(Text, encoding: Encoding.ASCII, name: nameof(Text));
            }
        }
    }
}