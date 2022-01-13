using BinarySerializer.Audio.RIFF;
using System.Linq;

namespace BinarySerializer.Audio
{
    /// <summary>
    /// WAV audio file data, mainly to use as a shortcut to create RIFF files easier
    /// </summary>
    public class WAV : BinarySerializable
    {
        private RIFF_Chunk RootChunk { get; set; }

        public RIFF_Chunk Root {
            get {
                if (RootChunk == null) {
                    RootChunk = new RIFF_Chunk_RIFF() {
                        Type = "WAVE",
                        Chunks = new RIFF_Chunk[] {
                            new RIFF_Chunk_Format().CreateChunk(),
                            new RIFF_Chunk_Data().CreateChunk()
                        },
                    }.CreateChunk();
                }
                return RootChunk;
            }
        }
        public RIFF_Chunk_RIFF Riff => (RIFF_Chunk_RIFF)(Root?.Data);
        public RIFF_Chunk_Format Format => (RIFF_Chunk_Format)(Riff.Chunks.FirstOrDefault(c => c.Data.GetType() == typeof(RIFF_Chunk_Format)).Data);
        public RIFF_Chunk_Data Data => (RIFF_Chunk_Data)(Riff.Chunks.FirstOrDefault(c => c.Data.GetType() == typeof(RIFF_Chunk_Data)).Data);

        /// <summary>
        /// Handles the data serialization
        /// </summary>
        /// <param name="s">The serializer object</param>
        public override void SerializeImpl(SerializerObject s)
        {
			RootChunk = s.SerializeObject<RIFF_Chunk>(Root, name: nameof(RootChunk));
        }
    }
}