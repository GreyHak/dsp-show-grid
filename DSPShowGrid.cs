﻿//
// Copyright (c) 2021, Aaron Shumate
// All rights reserved.
//
// This source code is licensed under the BSD-style license found in the
// LICENSE.txt file in the root directory of this source tree. 
//
// Dyson Sphere Program is developed by Youthcat Studio and published by Gamera Game.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace DSPShowGrid
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    [BepInProcess("DSPGAME.exe")]
    public class DSPShowGrid : BaseUnityPlugin
    {
        public const string pluginGuid = "greyhak.dysonsphereprogram.showgrid";
        public const string pluginName = "DSP Show Grid";
        public const string pluginVersion = "1.0.0";
        new internal static ManualLogSource Logger;
        //new internal static BepInEx.Configuration.ConfigFile Config;
        Harmony harmony;

        public void Awake()
        {
            Logger = base.Logger;  // "C:\Program Files (x86)\Steam\steamapps\common\Dyson Sphere Program\BepInEx\LogOutput.log"
            //Config = base.Config;  // "C:\Program Files (x86)\Steam\steamapps\common\Dyson Sphere Program\BepInEx\config\"

            harmony = new Harmony(pluginGuid);
            harmony.PatchAll(typeof(DSPShowGrid));
        }

        [HarmonyPrefix, HarmonyPatch(typeof(UIBuildingGrid), "Update")]
        public static void UIBuildingGrid_Update_Prefix(UIBuildingGrid __instance)
        {
            if (GameMain.mainPlayer != null)
            {
                __instance.material.SetFloat("_ZMin", -10f);
                __instance.material.SetFloat("_ZMax", 10f);
            }
        }
    }
}
