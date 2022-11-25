using BepInEx;
using HarmonyLib;

namespace ExampleMod
{
    [BepInPlugin(ModGuid, ModName, ModVersion)]
    public class Main : BaseUnityPlugin
    {
        private const string ModName = "AlwaysChristmas";
        private const string ModAuthor  = "reddust9";
        private const string ModGuid = "com.reddust9.alwayschristmas";
        private const string ModVersion = "1.0.0";
        internal void Awake()
        {
            // Creating new harmony instance
            var harmony = new Harmony(ModGuid);

            // Applying patches
            harmony.PatchAll();
            Logger.LogInfo($"{ModName} successfully loaded! Made by {ModAuthor}");
        }

        [HarmonyPatch("SeasonChecker", "IsItChristmas")]
        public class Patch
        {
            public static bool Prefix(ref bool __result)
            {
                __result = true;
                return false;
            }
        }
    }
}
