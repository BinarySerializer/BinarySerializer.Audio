using System.Text;
using BinarySerializer.Audio.RIFF;

namespace BinarySerializer.Audio.SF2
{
    public class RIFF_Chunk_SF2_InstrumentHeaders : RIFF_ChunkData
    {
        public override string ChunkIdentifier => "inst";
        public InstrumentHeader[] Headers { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Headers = s.SerializeObjectArray<InstrumentHeader>(Headers, Pre_ChunkSize / InstrumentHeader.StructSize, name: nameof(Headers));
        }

        public class InstrumentHeader : BinarySerializable
        {
            public const int StructSize = 0x16;

            public string Name { get; set; }
            public ushort BagIndex { get; set; }

            public override void SerializeImpl(SerializerObject s)
            {
                Name = s.SerializeString(Name, length: 20, encoding: Encoding.ASCII, name: nameof(Name));
                BagIndex = s.Serialize<ushort>(BagIndex, name: nameof(BagIndex));
            }
        }
    }
}