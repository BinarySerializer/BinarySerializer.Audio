using BinarySerializer.Audio.SF2;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySerializer.Audio.RIFF {
    /// <summary>
    /// RIFF (Resource Interchange File Format) file data
    /// </summary>
    public class RIFF_Chunk : BinarySerializable
    {
        public string Identifier { get; set; }
        public uint ChunkSize { get; set; }
        public RIFF_ChunkData Data { get; set; }

        /// <summary>
        /// Handles the data serialization
        /// </summary>
        /// <param name="s">The serializer object</param>
        public override void SerializeImpl(SerializerObject s)
        {
            // Serialize header
            Identifier = s.SerializeString(Identifier, 4, Encoding.ASCII, name: nameof(Identifier));
            ChunkSize = s.Serialize<uint>(ChunkSize, name: nameof(ChunkSize));
            SerializeChunk(s);

            // Update chunk size
            ChunkSize = (uint)(s.CurrentFileOffset - Offset.FileOffset - 8);
            s.DoAt(Offset + 4, () => ChunkSize = s.Serialize<uint>(ChunkSize, name: nameof(ChunkSize)));

            if(ChunkSize % 2 != 0) s.SerializePadding(1);
        }

        private void SerializeChunk(SerializerObject s) {
            RIFF_ChunkData SerializeData<T>() where T : RIFF_ChunkData, new() {
                return s.SerializeObject<T>((T)Data, onPreSerialize: d => d.ChunkSize = ChunkSize, name: nameof(Data));
            }

            Data = Identifier switch
            {
                "RIFF" => SerializeData<RIFF_Chunk_RIFF>(),
                "data" => SerializeData<RIFF_Chunk_Data>(),
                "LIST" => SerializeData<RIFF_Chunk_List>(),

                // WAV
                "fmt " => SerializeData<RIFF_Chunk_Format>(),

                // SF2
                "ifil" => SerializeData<RIFF_Chunk_SF2_Info_VersionTag>(),
                "isng" => SerializeData<RIFF_Chunk_SF2_Info_SoundEngine>(),
                "INAM" => SerializeData<RIFF_Chunk_SF2_Info_BankName>(),
                "ICMT" => SerializeData<RIFF_Chunk_SF2_Info_Comment>(),
                "smpl" => SerializeData<RIFF_Chunk_SF2_SampleData>(),
                "phdr" => SerializeData<RIFF_Chunk_SF2_PresetHeaders>(),
                "pbag" => SerializeData<RIFF_Chunk_SF2_PresetBag>(),
                "pmod" => SerializeData<RIFF_Chunk_SF2_PresetModulatorList>(),
                "pgen" => SerializeData<RIFF_Chunk_SF2_PresetGeneratorList>(),
                "inst" => SerializeData<RIFF_Chunk_SF2_InstrumentHeaders>(),
                "ibag" => SerializeData<RIFF_Chunk_SF2_InstrumentBag>(),
                "imod" => SerializeData<RIFF_Chunk_SF2_InstrumentModulatorList>(),
                "igen" => SerializeData<RIFF_Chunk_SF2_InstrumentGeneratorList>(),
                "shdr" => SerializeData<RIFF_Chunk_SF2_SampleHeaders>(),

                // Unknown
                _ => SerializeData<RIFF_Chunk_Data>(),
            };
        }

    }
}