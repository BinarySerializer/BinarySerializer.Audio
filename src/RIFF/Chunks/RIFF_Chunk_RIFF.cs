using System;
using System.Linq;
using System.Text;

namespace BinarySerializer.Audio.RIFF
{
    public class RIFF_Chunk_RIFF : RIFF_ChunkData
    {
        public override string ChunkIdentifier => "RIFF";
        public string Type { get; set; }
        public RIFF_Chunk[] Chunks { get; set; }

#nullable enable
        public T? GetChunk<T>()
            where T : RIFF_ChunkData
        {
            return Chunks.Select(x => x.Data).OfType<T>().FirstOrDefault();
        }

        public T GetRequiredChunk<T>()
            where T : RIFF_ChunkData
        {
            return Chunks.Select(x => x.Data).OfType<T>().FirstOrDefault() ??
                   throw new Exception($"Could not find a RIFF chunk of type {typeof(T)}");
        }
#nullable restore

        public override void SerializeImpl(SerializerObject s)
        {
            Type = s.SerializeString(Type, length: 4, encoding: Encoding.ASCII, name: nameof(Type));
            Chunks = s.SerializeObjectArrayUntil<RIFF_Chunk>(
                Chunks,
                _ => (s.CurrentFileOffset - Offset.FileOffset) >= Pre_ChunkSize,
                name: nameof(Chunks));
        }
    }
}