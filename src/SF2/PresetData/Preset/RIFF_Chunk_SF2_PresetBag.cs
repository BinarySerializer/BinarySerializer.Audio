using BinarySerializer.Audio.RIFF;

namespace BinarySerializer.Audio.SF2
{
    public class RIFF_Chunk_SF2_PresetBag : RIFF_ChunkData
    {
        public override string ChunkIdentifier => "pbag";
        public SF2_BagEntry[] Entries { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Entries = s.SerializeObjectArray<SF2_BagEntry>(Entries, Pre_ChunkSize / SF2_BagEntry.StructSize, name: nameof(Entries));
        }
    }
}