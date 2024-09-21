using BepInEx;
using BoplFixedMath;
using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace HighJump
{
    [BepInPlugin("com.buzzard.highjump", "High Jump", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo("Plugin HighJump is loaded!");

            Harmony harmony = new Harmony("com.buzzard.highjump");
            Time.timeScale = 0.5f;

            MethodInfo highjumpog = AccessTools.Method(typeof(PlayerPhysics), "Awake");
            MethodInfo highjumppatch = AccessTools.Method(typeof(myPatches), "Awake_HighJump_Plug");
            harmony.Patch(highjumpog, new HarmonyMethod(highjumppatch));
            MethodInfo fastabilog = AccessTools.Method(typeof(Ability), "Awake");
            MethodInfo fastabilpatch = AccessTools.Method(typeof(myPatches), "Awake_FasterAbilities_Plug");
            harmony.Patch(fastabilog, new HarmonyMethod(fastabilpatch));


        }

        public class myPatches
        {
            public static void Awake_FasterAbilities_Plug(ref Ability __instance)
            {
                __instance.Cooldown = (Fix)0.4;
            }
            public static void Awake_HighJump_Plug(ref PlayerPhysics __instance)
            {
                __instance.jumpStrength = (Fix)69;
            }
        }
    }
}
