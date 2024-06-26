﻿namespace BinarySerializer.Audio
{
    /// <summary>
    /// XM audio file data
    /// </summary>
    public class XM_PatternRow : BinarySerializable
    {
        public XM_PatternRow()
        {
            SerializedSize = 1;
        }

        public byte Flags { get; set; } = 0x80;
        public byte Note { get; set; }
        public byte Instrument { get; set; }
        public byte VolumeColumnByte { get; set; }
        public byte EffectType { get; set; }
        public byte EffectParameter { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Flags = s.Serialize<byte>(Flags, name: nameof(Flags));
            if (BitHelpers.ExtractBits(Flags, 1, 7) == 1)
            {
                if (BitHelpers.ExtractBits(Flags, 1, 0) == 1) 
                    Note = s.Serialize<byte>(Note, name: nameof(Note));
                if (BitHelpers.ExtractBits(Flags, 1, 1) == 1) 
                    Instrument = s.Serialize<byte>(Instrument, name: nameof(Instrument));
                if (BitHelpers.ExtractBits(Flags, 1, 2) == 1) 
                    VolumeColumnByte = s.Serialize<byte>(VolumeColumnByte, name: nameof(VolumeColumnByte));
                if (BitHelpers.ExtractBits(Flags, 1, 3) == 1) 
                    EffectType = s.Serialize<byte>(EffectType, name: nameof(EffectType));
                if (BitHelpers.ExtractBits(Flags, 1, 4) == 1) 
                    EffectParameter = s.Serialize<byte>(EffectParameter, name: nameof(EffectParameter));
            }
            else
            {
                Note = Flags;
                Instrument = s.Serialize<byte>(Instrument, name: nameof(Instrument));
                VolumeColumnByte = s.Serialize<byte>(VolumeColumnByte, name: nameof(VolumeColumnByte));
                EffectType = s.Serialize<byte>(EffectType, name: nameof(EffectType));
                EffectParameter = s.Serialize<byte>(EffectParameter, name: nameof(EffectParameter));
            }
        }

        public XM_PatternRow(
            byte? note = null,
            byte? instrument = null,
            byte? volumeColumnByte = null,
            byte? effectType = null,
            byte? effectParameter = null)
        {
            if (note.HasValue && instrument.HasValue && volumeColumnByte.HasValue && effectType.HasValue && effectParameter.HasValue)
            {
                Flags = note.Value;
                Note = note.Value;
                Instrument = instrument.Value;
                VolumeColumnByte = volumeColumnByte.Value;
                EffectType = effectType.Value;
                EffectParameter = effectParameter.Value;
                SerializedSize = 5;
            }
            else
            {
                SerializedSize = 1;
                if (note.HasValue)
                {
                    Flags = (byte)BitHelpers.SetBits(Flags, 1, 1, 0);
                    Note = note.Value;
                    SerializedSize++;
                }
                if (instrument.HasValue)
                {
                    Flags = (byte)BitHelpers.SetBits(Flags, 1, 1, 1);
                    Instrument = instrument.Value;
                    SerializedSize++;
                }
                if (volumeColumnByte.HasValue)
                {
                    Flags = (byte)BitHelpers.SetBits(Flags, 1, 1, 2);
                    VolumeColumnByte = volumeColumnByte.Value;
                    SerializedSize++;
                }
                if (effectType.HasValue)
                {
                    Flags = (byte)BitHelpers.SetBits(Flags, 1, 1, 3);
                    EffectType = effectType.Value;
                    SerializedSize++;
                }
                if (effectParameter.HasValue)
                {
                    Flags = (byte)BitHelpers.SetBits(Flags, 1, 1, 4);
                    EffectParameter = effectParameter.Value;
                    SerializedSize++;
                }
            }
        }
    }
}