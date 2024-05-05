using System;
using BinarySerializer.Audio.RIFF;

namespace BinarySerializer.Audio.SF2
{
    public class RIFF_Chunk_SF2_SampleData : RIFF_ChunkData
    {
        public override string ChunkIdentifier => "smpl";
        public short[] SampleData { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            SampleData = s.SerializeArray<short>(SampleData, Pre_ChunkSize / 2, name: nameof(SampleData));
        }

        public uint AddSample(short[] sample)
        {
            if (sample == null || sample.Length == 0) return (uint)(SampleData?.Length ?? 0);
            int startIndex = 0;
            if (SampleData == null)
            {
                SampleData = new short[sample.Length];
            }
            else
            {
                var sdata = SampleData;
                startIndex = sdata.Length;
                Array.Resize<short>(ref sdata, startIndex + sample.Length);
                SampleData = sdata;
            }
            Array.Copy(sample, 0, SampleData, startIndex, sample.Length);
            return (uint)startIndex;
        }
    }
}