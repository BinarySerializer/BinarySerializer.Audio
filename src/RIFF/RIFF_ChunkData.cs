using System.Collections.Generic;
using System.Text;

namespace BinarySerializer.Audio.RIFF {
    /// <summary>
    /// RIFF (Resource Interchange File Format) file data
    /// </summary>
    public abstract class RIFF_ChunkData : BinarySerializable
    {
        public abstract string ChunkIdentifier { get; }
        public long Pre_ChunkSize { get; set; }

        public RIFF_Chunk CreateChunk() => new RIFF_Chunk() {
            Identifier = ChunkIdentifier,
            Data = this
        };

    }
}