// <copyright>
// Copyright (c) will258012. All rights reserved.
// </copyright>

using CitiesHarmony.API;
using HarmonyLib;

namespace WillCommons
{
    /// <summary>
    /// A utility class for managing Harmony patches.
    /// </summary>
    public static class HarmonyPatcher
    {
        /// <summary>
        /// Applies Harmony patches when Harmony is ready.
        /// </summary>
        /// <param name="HarmonyID">The unique identifier for the Harmony instance.</param>
        public static void PatchOnReady(string HarmonyID)
        {
            try
            {
                // Wait for Harmony to be ready and then apply patches.
                HarmonyHelper.DoOnHarmonyReady(() => Patch(HarmonyID));
            }
            catch (System.Exception e)
            {
                // Log any exception that occurs during patching.
                Logging.Exception(e, "Patching fails:");
            }
        }

        /// <summary>
        /// Attempts to remove Harmony patches.
        /// </summary>
        /// <param name="HarmonyID">The unique identifier for the Harmony instance.</param>
        public static void TryUnpatch(string HarmonyID)
        {
            try
            {
                // Only unpatch if Harmony is installed.
                if (HarmonyHelper.IsHarmonyInstalled)
                {
                    Unpatch(HarmonyID);
                }
            }
            catch (System.Exception e)
            {
                // Log any exception that occurs during unpatching.
                Logging.Exception(e, "Unpatching fails:");
            }
        }

        /// <summary>
        /// Applies all Harmony patches using the provided Harmony ID.
        /// </summary>
        /// <param name="HarmonyID">The unique identifier for the Harmony instance.</param>
        private static void Patch(string HarmonyID)
        {
            // Check if the patches are already applied to avoid duplications.
            if (PatcherModBase.PatcherInstance?.HasPatched ?? false)
            {
                Logging.Warn($"<{HarmonyID}> is already patched");
                return;
            }
            //Patch Harmony patches.
            Logging.Msg($"Patching <{HarmonyID}>");
            var harmony = new Harmony(HarmonyID);
            harmony.PatchAll();
            PatcherModBase.PatcherInstance.HasPatched = true;
            Logging.Msg("Successfully patched");
        }

        /// <summary>
        /// Removes all Harmony patches using the provided Harmony ID.
        /// </summary>
        /// <param name="HarmonyID">The unique identifier for the Harmony instance.</param>
        private static void Unpatch(string HarmonyID)
        {
            // Check if the patches have never been applied to avoid unnecessary unpatching.
            if (!(PatcherModBase.PatcherInstance?.HasPatched ?? false))
            {
                Logging.Warn($"<{HarmonyID}> has never been patched");
                return;
            }
            // Unpatch Harmony patches.
            Logging.Msg($"Unpatching <{HarmonyID}>");
            var harmony = new Harmony(HarmonyID);
            harmony.UnpatchAll(HarmonyID);
            Logging.Msg("Successfully unpatched");
            PatcherModBase.PatcherInstance.HasPatched = false;
        }
    }
}
