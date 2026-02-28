using ModSettings;

namespace ManuelFatigueModu // Dikkat: Burası Main.cs ile birebir aynı oldu
{
    internal class FatigueModSettings : JsonModSettings
    {
        [Name("Yürüme Yorgunluk Çarpanı")]
        [Description("1.0 varsayılandır. 0.1'e çekerseniz yürüme yorgunluğu %90 azalır. 0.0 yaparsanız yürürken hiç yorulmazsınız.")]
        [Slider(0f, 1f, 101)]
        public float fatigueMultiplier = 1.0f;

        [Name("Koşma Yorgunluğuna Etki")]
        [Description("Eğer açıksa, koşarken (sprinting) harcanan efor da yukarıdaki çarpandan etkilenir.")]
        public bool affectSprinting = false;
    }

    internal static class Settings
    {
        public static FatigueModSettings options;

        public static void OnLoad()
        {
            options = new FatigueModSettings();
            // Modun oyun içi ayarlar menüsünde görünmesi için bu satır şarttır
            options.AddToModSettings("Yorgunluk Ayarları");
        }
    }
}