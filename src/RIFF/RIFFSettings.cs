using System.Collections.Generic;

namespace BinarySerializer.Audio.RIFF
{
    public class RIFFSettings
    {
        public RIFFSettings()
        {
            // Register defaults
            RegisterChunkResolver("RIFF", (s, data, chunkSize, name) =>
                s.SerializeObject<RIFF_Chunk_RIFF>((RIFF_Chunk_RIFF)data, x => x.Pre_ChunkSize = chunkSize, name: name));
            RegisterChunkResolver("data", (s, data, chunkSize, name) =>
                s.SerializeObject<RIFF_Chunk_Data>((RIFF_Chunk_Data)data, x => x.Pre_ChunkSize = chunkSize, name: name));
            RegisterChunkResolver("LIST", (s, data, chunkSize, name) =>
                s.SerializeObject<RIFF_Chunk_List>((RIFF_Chunk_List)data, x => x.Pre_ChunkSize = chunkSize, name: name));
        }

        private Dictionary<string, ChunkResolver> ChunkResolvers { get; } = new Dictionary<string, ChunkResolver>();

        public delegate RIFF_ChunkData ChunkResolver(SerializerObject s, RIFF_ChunkData data, long chunkSize, string name);

        public void RegisterChunkResolver(string identifier, ChunkResolver chunkResolver)
        {
            ChunkResolvers[identifier] = chunkResolver;
        }

        public ChunkResolver GetChunkResolver(string identifier)
        {
            if (ChunkResolvers.TryGetValue(identifier, out ChunkResolver chunkResolver))
                return chunkResolver;

            return null;
        }
    }
}