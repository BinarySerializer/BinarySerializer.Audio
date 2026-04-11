using BinarySerializer.Audio.SF2;

namespace BinarySerializer.Audio.RIFF
{
    public static class RIFFSettingsExtensions
    {
        public static void RegisterWAV(this RIFFSettings settings)
        {
            settings.RegisterChunkResolver("fmt ", (s, data, chunkSize, name) =>
                s.SerializeObject<RIFF_Chunk_Format>((RIFF_Chunk_Format)data, x => x.Pre_ChunkSize = chunkSize, name: name));
            settings.RegisterChunkResolver("cue ", (s, data, chunkSize, name) =>
                s.SerializeObject<RIFF_Chunk_Cue>((RIFF_Chunk_Cue)data, x => x.Pre_ChunkSize = chunkSize, name: name));
        }

        public static void RegisterProTools(this RIFFSettings settings)
        {
            settings.RegisterChunkResolver("bext", (s, data, chunkSize, name) =>
                s.SerializeObject<RIFF_Chunk_BEXT>((RIFF_Chunk_BEXT)data, x => x.Pre_ChunkSize = chunkSize, name: name));
        }

        public static void RegisterSF2(this RIFFSettings settings)
        {
            settings.RegisterChunkResolver("ifil", (s, data, chunkSize, name) =>
                s.SerializeObject<RIFF_Chunk_SF2_Info_VersionTag>((RIFF_Chunk_SF2_Info_VersionTag)data, x => x.Pre_ChunkSize = chunkSize, name: name));
            settings.RegisterChunkResolver("isng", (s, data, chunkSize, name) =>
                s.SerializeObject<RIFF_Chunk_SF2_Info_SoundEngine>((RIFF_Chunk_SF2_Info_SoundEngine)data, x => x.Pre_ChunkSize = chunkSize, name: name));
            settings.RegisterChunkResolver("INAM", (s, data, chunkSize, name) =>
                s.SerializeObject<RIFF_Chunk_SF2_Info_BankName>((RIFF_Chunk_SF2_Info_BankName)data, x => x.Pre_ChunkSize = chunkSize, name: name));
            settings.RegisterChunkResolver("ICMT", (s, data, chunkSize, name) =>
                s.SerializeObject<RIFF_Chunk_SF2_Info_Comment>((RIFF_Chunk_SF2_Info_Comment)data, x => x.Pre_ChunkSize = chunkSize, name: name));
            settings.RegisterChunkResolver("smpl", (s, data, chunkSize, name) =>
                s.SerializeObject<RIFF_Chunk_SF2_SampleData>((RIFF_Chunk_SF2_SampleData)data, x => x.Pre_ChunkSize = chunkSize, name: name));
            settings.RegisterChunkResolver("phdr", (s, data, chunkSize, name) =>
                s.SerializeObject<RIFF_Chunk_SF2_PresetHeaders>((RIFF_Chunk_SF2_PresetHeaders)data, x => x.Pre_ChunkSize = chunkSize, name: name));
            settings.RegisterChunkResolver("pbag", (s, data, chunkSize, name) =>
                s.SerializeObject<RIFF_Chunk_SF2_PresetBag>((RIFF_Chunk_SF2_PresetBag)data, x => x.Pre_ChunkSize = chunkSize, name: name));
            settings.RegisterChunkResolver("pmod", (s, data, chunkSize, name) =>
                s.SerializeObject<RIFF_Chunk_SF2_PresetModulatorList>((RIFF_Chunk_SF2_PresetModulatorList)data, x => x.Pre_ChunkSize = chunkSize, name: name));
            settings.RegisterChunkResolver("pgen", (s, data, chunkSize, name) =>
                s.SerializeObject<RIFF_Chunk_SF2_PresetGeneratorList>((RIFF_Chunk_SF2_PresetGeneratorList)data, x => x.Pre_ChunkSize = chunkSize, name: name));
            settings.RegisterChunkResolver("inst", (s, data, chunkSize, name) =>
                s.SerializeObject<RIFF_Chunk_SF2_InstrumentHeaders>((RIFF_Chunk_SF2_InstrumentHeaders)data, x => x.Pre_ChunkSize = chunkSize, name: name));
            settings.RegisterChunkResolver("ibag", (s, data, chunkSize, name) =>
                s.SerializeObject<RIFF_Chunk_SF2_InstrumentBag>((RIFF_Chunk_SF2_InstrumentBag)data, x => x.Pre_ChunkSize = chunkSize, name: name));
            settings.RegisterChunkResolver("imod", (s, data, chunkSize, name) =>
                s.SerializeObject<RIFF_Chunk_SF2_InstrumentModulatorList>((RIFF_Chunk_SF2_InstrumentModulatorList)data, x => x.Pre_ChunkSize = chunkSize, name: name));
            settings.RegisterChunkResolver("igen", (s, data, chunkSize, name) =>
                s.SerializeObject<RIFF_Chunk_SF2_InstrumentGeneratorList>((RIFF_Chunk_SF2_InstrumentGeneratorList)data, x => x.Pre_ChunkSize = chunkSize, name: name));
            settings.RegisterChunkResolver("shdr", (s, data, chunkSize, name) =>
                s.SerializeObject<RIFF_Chunk_SF2_SampleHeaders>((RIFF_Chunk_SF2_SampleHeaders)data, x => x.Pre_ChunkSize = chunkSize, name: name));
        }
    }
}