using BepInEx;
using BoplFixedMath;
using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace SuperDash
{
    [BepInPlugin("com.buzzard.nogrenadeselfdestruct", "No Grenade Self Destruct", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo("Plugin ModName is loaded!");

            Harmony harmony = new Harmony("com.buzzard.nogrenadeselfdestruct");


            MethodInfo original = AccessTools.Method(typeof(Grenade), "Awake");
            MethodInfo patch = AccessTools.Method(typeof(myPatches), "Awake_ModName_Plug");
            harmony.Patch(original, new HarmonyMethod(patch));
        }

        public class myPatches
        {
            public static void Awake_ModName_Plug(Grenade __instance)
            {
                __instance.detonationTime = (Fix)99999999;
                __instance.selfDestructDelay = (Fix)99999999;
            }
        }
    }
}
