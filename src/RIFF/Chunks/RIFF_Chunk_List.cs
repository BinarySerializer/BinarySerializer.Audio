﻿using System.Text;

namespace BinarySerializer.Audio.RIFF
{
    public class RIFF_Chunk_List : RIFF_ChunkData
    {
        public override string ChunkIdentifier => "LIST";

        public string Type { get; set; }
        public RIFF_Chunk[] Chunks { get; set; }

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