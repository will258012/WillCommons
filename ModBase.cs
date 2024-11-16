// <copyright>
// Copyright (c) will258012. All rights reserved.
// </copyright>

using ICities;
using System.Reflection;

namespace WillCommons
{
    public abstract class ModBase : LoadingExtensionBase, IUserMod
    {
        /// <summary>
        /// Initialize a new instance of <see cref="ModBase"/> class.
        /// </summary>
        public ModBase() => Instance = this;
        /// <summary>
        /// Get the active <see cref="ModBase"/> instance.
        /// </summary>
        public static ModBase Instance { get; private set; }
        /// <summary>
        /// Get the mod full name (with version) displayed in Content Manager, Settings Screen and so on.
        /// </summary>
        public string Name => $"{BaseName} v{ModVersion}";
        /// <summary>
        /// The base mod name, without the version.
        /// </summary>
        public abstract string BaseName { get; }
        /// <summary>
        /// The mod description displayed in Content Manager.
        /// </summary>
        public abstract string Description { get; }
        /// <summary>
        /// Get the mod version (in a form similar to 1.0.0).
        /// </summary>
        public string ModVersion
        {
            get
            {
                var assemblyVersion = ModAssembly.GetName().Version;
                return $"{assemblyVersion.Major}.{assemblyVersion.Minor}.{assemblyVersion.Build}";
            }
        }
        /// <summary>
        /// Called when the mod is enabled.
        /// </summary>
        public virtual void OnEnabled() { }
        /// <summary>
        /// Called when the mod is disabled.
        /// </summary>
        public virtual void OnDisabled() { }
        /// <summary>
        /// Called on the start of level loading.
        /// Also could be executed in other cases, e.g. when a mod is subscribed in-game (in which case <see cref="OnCreated(ILoading)"/> will be called again for *all* mods).
        /// </summary>
        /// <param name="loading">Loading mode. Could be used to distinguish if it is a game or some kind of editor, etc.</param>
        public override void OnCreated(ILoading loading) { }
        /// <summary>
        /// Called when the mod is released.
        /// </summary>
        public override void OnReleased() { }
        /// <summary>
        /// Called on the end of level loading.
        /// </summary>
        /// <param name="mode">Loading mode. Could be used to distinguish between types of loads.</param>
        public override void OnLevelLoaded(LoadMode mode) { }
        /// <summary>
        /// Called on the start of level unloading.
        /// </summary>
        public override void OnLevelUnloading() { }
        /// <summary>
        /// Get the mod's assembly.
        /// </summary>
        public static Assembly ModAssembly => Assembly.GetExecutingAssembly();
    }
}
