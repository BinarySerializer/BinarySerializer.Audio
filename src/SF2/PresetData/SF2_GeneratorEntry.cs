namespace BinarySerializer.Audio.SF2
{
    public class SF2_GeneratorEntry : BinarySerializable
    {
        public const int StructSize = 0x4;

        public SF2_Generator Generator { get; set; }
        public short Amount { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Generator = s.Serialize<SF2_Generator>(Generator, name: nameof(Generator));
            Amount = s.Serialize<short>(Amount, name: nameof(Amount));
        }
    }
}