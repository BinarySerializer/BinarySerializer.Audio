namespace BinarySerializer.Audio.SF2
{
    public class SF2_ModulatorEntry : BinarySerializable
    {
        public const int StructSize = 0xA;

        public SF2_Modulator Source { get; set; }
        public SF2_Generator Destination { get; set; }
        public short Amount { get; set; }
        public SF2_Modulator AmountSource { get; set; }
        public SF2_Transform Transform { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Source = s.Serialize<SF2_Modulator>(Source, name: nameof(Source));
            Destination = s.Serialize<SF2_Generator>(Destination, name: nameof(Destination));
            Amount = s.Serialize<short>(Amount, name: nameof(Amount));
            AmountSource = s.Serialize<SF2_Modulator>(AmountSource, name: nameof(AmountSource));
            Transform = s.Serialize<SF2_Transform>(Transform, name: nameof(Transform));
        }
    }
}