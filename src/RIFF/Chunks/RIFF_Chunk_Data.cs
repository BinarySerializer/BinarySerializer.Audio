using System.Collections.Generic;
using System.Text;

namespace BinarySerializer.Audio.RIFF
{
    public class RIFF_Chunk_Data : RIFF_ChunkData
    {
		public override string ChunkIdentifier => "data";
        public byte[] Data { get; set; }

		public override void SerializeImpl(SerializerObject s) {
            Data = s.SerializeArray<byte>(Data, ChunkSize, name: nameof(Data));
        }
    }
}