// <copyright>
// Copyright (c) will258012. All rights reserved.
// </copyright>

namespace WillCommons
{
    /// <summary>
    /// Base mod class with Harmony patching feature.
    /// </summary>
    public abstract class PatcherModBase : ModBase
    {
        /// <summary>
        /// Initialize a new instance of <see cref="PatcherModBase"/> class.
        /// </summary>
        public PatcherModBase() => PatcherInstance = this;
        /// <summary>
        /// Get the active <see cref="PatcherModBase"/> instance.
        /// </summary>
        public static PatcherModBase PatcherInstance { get; private set; }
        /// <summary>
        /// Unique identifier used for Harmony Patch.
        /// Could name like this:
        /// <code>com.(User name).(Mod name)</code>
        /// </summary>
        public abstract string HarmonyID { get; }
        /// <summary>
        /// Get the status of patching.
        /// </summary>
        public bool HasPatched { get; internal set; }
        public override void OnEnabled()
        {
            HarmonyPatcher.PatchOnReady(HarmonyID);
        }
        public override void OnDisabled()
        {
            HarmonyPatcher.TryUnpatch(HarmonyID);
        }
    }
}
