namespace BinarySerializer.Audio.SF2
{
    public class SF2_BagEntry : BinarySerializable
    {
        public const int StructSize = 0x4;

        public ushort GeneratorIndex { get; set; }
        public ushort ModulatorIndex { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            GeneratorIndex = s.Serialize<ushort>(GeneratorIndex, name: nameof(GeneratorIndex));
            ModulatorIndex = s.Serialize<ushort>(ModulatorIndex, name: nameof(ModulatorIndex));
        }
    }
}