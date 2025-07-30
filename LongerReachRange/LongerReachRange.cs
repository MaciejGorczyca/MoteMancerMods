using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace LongerReachRange
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class LongerReachRange : BaseUnityPlugin
    {
        private const string GUID = "coust.motemancermods.longerreachrange";
        private const string NAME = "Longer Reach Range";
        private const string VERSION = "1.0.0.0";

        private const int NewReachValue = 9999;
        
        internal static ManualLogSource Log;
        
        private readonly Harmony harmony = new Harmony(GUID);

        private void Awake()
        {
            Log = Logger;
            Log.LogInfo($"Plugin {NAME} is loaded!");

            harmony.PatchAll();
        }


        [HarmonyPatch(typeof(Upgrades), "Awake")]
        public static class UpgradesAwakePatch
        {

            [HarmonyPostfix]
            public static void Postfix(Upgrades __instance)
            {
                Log.LogInfo("Upgrades.Awake() has run. Executing Postfix patch...");

                if (__instance == null)
                {
                    Log.LogError("Patch failed: The __instance of Upgrades was null.");
                    return;
                }


                UpgradeManagerData upgradeData = (UpgradeManagerData)AccessTools.Field(typeof(Upgrades), "m_upgradeData").GetValue(__instance);

                if (upgradeData == null)
                {
                    Log.LogError("Patch failed: Could not retrieve 'm_upgradeData' from Upgrades instance.");
                    return;
                }
                
                int oldReach = upgradeData.m_baseReachDistance;
                upgradeData.m_baseReachDistance = NewReachValue;

                Log.LogInfo($"Patch applied: Base reach distance changed from {oldReach} to {NewReachValue}.");
            }
        }
    }
}
