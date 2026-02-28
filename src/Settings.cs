using ModSettings;

namespace ManuelFatigueModu
{
    internal class FatigueModSettings : JsonModSettings
    {
        [Name("Walk fatigue multiplier")]
        [Description("1.0 vanilla. If you set it to 0.1, walking fatigue will decrease by 90%. If you set it to 0.0, you won't get tired at all while walking.")]
        [Slider(0f, 1f, 101)]
        public float fatigueMultiplier = 1.0f;
    }

    internal static class Settings
    {
        public static FatigueModSettings options;

        public static void OnLoad()
        {
            options = new FatigueModSettings();
            options.AddToModSettings("Fatigue Settings");
        }
    }

}
