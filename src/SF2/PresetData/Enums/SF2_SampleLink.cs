using System;

namespace BinarySerializer.Audio.SF2
{
    [Flags]
    public enum SF2_SampleLink : ushort
    {
        None = 0,
        MonoSample = 1 << 0,
        RightSample = 1 << 1,
        LeftSample = 1 << 2,
        LinkedSample = 1 << 3,
        Rom = 1 << 15,
    }
}