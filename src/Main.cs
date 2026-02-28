using HarmonyLib;
using Il2Cpp;
using MelonLoader;
using UnityEngine;
using ManuelFatigueModu;

[assembly: MelonInfo(typeof(FatigueMain), "Manuel Fatigue Mod", "1.0.0", "BisterSelim")]
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
                bool isWalking = GameManager.GetPlayerManagerComponent().PlayerIsWalking();
                bool isSprinting = GameManager.GetPlayerManagerComponent().PlayerIsSprinting();

                if (isWalking && !isSprinting)
                {
                    float walkingRate = __instance.m_FatigueIncreasePerHourWalking;
                    float reduction = walkingRate * (1.0f - Settings.options.fatigueMultiplier);
                    __instance.AddFatigue(-(reduction * Time.deltaTime / 3600f));
                }
            }
        }
    }

}
