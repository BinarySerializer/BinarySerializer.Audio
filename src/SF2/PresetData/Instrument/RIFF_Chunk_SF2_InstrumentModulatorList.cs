﻿using BinarySerializer.Audio.RIFF;

namespace BinarySerializer.Audio.SF2
{
    public class RIFF_Chunk_SF2_InstrumentModulatorList : RIFF_ChunkData
    {
        public override string ChunkIdentifier => "imod";
        public SF2_ModulatorEntry[] Modulators { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Modulators = s.SerializeObjectArray<SF2_ModulatorEntry>(Modulators, Pre_ChunkSize / SF2_ModulatorEntry.StructSize, name: nameof(Modulators));
        }
    }
}