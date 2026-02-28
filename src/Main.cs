using HarmonyLib;
using Il2Cpp;
using MelonLoader;
using UnityEngine;
using ManuelFatigueModu;

[assembly: MelonInfo(typeof(FatigueMain), "Manuel Yorgunluk Modu", "1.0.0", "SeninAdin")]
[assembly: MelonGame("Hinterland", "TheLongDark")]

namespace ManuelFatigueModu
{
    public class FatigueMain : MelonMod
    {
        public override void OnInitializeMelon()
        {
            Settings.OnLoad();
            MelonLogger.Msg("Fatigue Control Mod is Ready!");
        }

        [HarmonyPatch(typeof(Fatigue), "Update")]
        public class Fatigue_Update_Patch
        {
            public static void Postfix(Fatigue __instance)
            {
                // Senin bulduğun stabil metodlar
                bool isWalking = GameManager.GetPlayerManagerComponent().PlayerIsWalking();
                bool isSprinting = GameManager.GetPlayerManagerComponent().PlayerIsSprinting();

                if (isWalking && !isSprinting)
                {
                    // Oyunun varsayılan yürüme maliyetini çekiyoruz
                    float walkingRate = __instance.m_FatigueIncreasePerHourWalking;

                    // Bu değer üzerinden senin belirlediğin 'indirim' miktarını hesaplıyoruz
                    // Eğer multiplier 0.2 ise, %80'ini geri iade edeceğiz
                    float reduction = walkingRate * (1.0f - Settings.options.fatigueMultiplier);

                    // Zaman ölçeği düzeltmesiyle yorgunluğu azaltıyoruz
                    __instance.AddFatigue(-(reduction * Time.deltaTime / 3600f));
                }
            }
        }
    }
}