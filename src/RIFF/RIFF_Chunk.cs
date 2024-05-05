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
        public RIFF_ChunkData Data { get; set; }

        private void SerializeChunk(SerializerObject s, long chunkSize)
        {
            Data = Identifier switch
            {
                "RIFF" => serializeData<RIFF_Chunk_RIFF>(),
                "data" => serializeData<RIFF_Chunk_Data>(),
                "LIST" => serializeData<RIFF_Chunk_List>(),

                // WAV
                "fmt " => serializeData<RIFF_Chunk_Format>(),

                // SF2
                "ifil" => serializeData<RIFF_Chunk_SF2_Info_VersionTag>(),
                "isng" => serializeData<RIFF_Chunk_SF2_Info_SoundEngine>(),
                "INAM" => serializeData<RIFF_Chunk_SF2_Info_BankName>(),
                "ICMT" => serializeData<RIFF_Chunk_SF2_Info_Comment>(),
                "smpl" => serializeData<RIFF_Chunk_SF2_SampleData>(),
                "phdr" => serializeData<RIFF_Chunk_SF2_PresetHeaders>(),
                "pbag" => serializeData<RIFF_Chunk_SF2_PresetBag>(),
                "pmod" => serializeData<RIFF_Chunk_SF2_PresetModulatorList>(),
                "pgen" => serializeData<RIFF_Chunk_SF2_PresetGeneratorList>(),
                "inst" => serializeData<RIFF_Chunk_SF2_InstrumentHeaders>(),
                "ibag" => serializeData<RIFF_Chunk_SF2_InstrumentBag>(),
                "imod" => serializeData<RIFF_Chunk_SF2_InstrumentModulatorList>(),
                "igen" => serializeData<RIFF_Chunk_SF2_InstrumentGeneratorList>(),
                "shdr" => serializeData<RIFF_Chunk_SF2_SampleHeaders>(),

                // Unknown
                _ => s.SerializeObject<RIFF_Chunk_Unknown>((RIFF_Chunk_Unknown)Data, onPreSerialize: x =>
                {
                    x.Pre_ChunkSize = chunkSize;
                    x.Pre_Identifier = Identifier;
                }, name: nameof(Data)),
            };

            RIFF_ChunkData serializeData<T>()
                where T : RIFF_ChunkData, new() =>
                s.SerializeObject<T>((T)Data, onPreSerialize: d => d.Pre_ChunkSize = chunkSize, name: nameof(Data));
        }

        public override void SerializeImpl(SerializerObject s)
        {
            Identifier = s.SerializeString(Identifier, 4, Encoding.ASCII, name: nameof(Identifier));
            s.DoProcessed(new DataLengthProcessor(), p =>
            {
                p.Serialize<uint>(s, name: "Size");
                SerializeChunk(s, p.SerializedValue);
            });
            s.Align(2, baseOffset: Offset);
        }
    }
}