using BepInEx;
using BoplFixedMath;
using HarmonyLib;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

namespace AntiSquish
{
    [BepInPlugin("com.buzzard.antisquish", "No Squish", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo("Plugin NoSquish is loaded!");

            Harmony harmony = new Harmony("com.buzzard.antisquish");

            MethodInfo grenadeoriginal = AccessTools.Method(typeof(PlayerCollision), "Awake");
            MethodInfo grenadepatch = AccessTools.Method(typeof(myPatches), "Awake_AntiSquish_Plug");
            harmony.Patch(grenadeoriginal, new HarmonyMethod(grenadepatch));

        }

        public class myPatches
        {
            public static void Awake_AntiSquish_Plug(PlayerCollision __instance)
            {
                __instance.isSquishable = false;

            }
        }
    }
}
