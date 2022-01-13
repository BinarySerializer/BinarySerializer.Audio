namespace BinarySerializer.Audio.SF2 {
	public enum SF2_Modulator : ushort {
        None = 0,
        NoteOnVelocity = 1,
        NoteOnKey = 2,
        PolyPressure = 10,
        ChnPressure = 13,
        PitchWheel = 14,
        PitchWheelSensivity = 16
    }
}
