using ICities;
namespace WillCommons.Examples
{
    /// <summary>
    /// An example mod demonstrating the use of Harmony and a base patching system.
    /// </summary>
    public class Mod : PatcherModBase
    {
        public override string BaseName => "My Mod";

        public override string Description => "This is a sample mod to demonstrate Harmony integration.";

        public override string HarmonyID => "com.username.mymod";

        public override void OnCreated(ILoading loading)
        {
            // Initialize or reinitialize resources here...
        }

        public override void OnDisabled()
        {
            base.OnDisabled(); // This unpatches Harmony patches.
            // Perform cleanup tasks here...
        }
        public override void OnEnabled()
        {
            base.OnEnabled(); // This patches Harmony patches.
            // Initialize resources here...
        }

        public override void OnLevelLoaded(LoadMode mode)
        {
            // Add logic here that needs to be executed once the level is fully loaded...
        }

        public override void OnLevelUnloading()
        {
            // Add cleanup logic here for level-specific resources...
        }
        public override void OnReleased()
        {
            // Perform cleanup tasks here...
        }

        /// <summary>
        /// Called to create a settings UI for the mod in the game's settings menu.
        /// </summary>
        /// <param name="helper">The UI helper provided by the game.</param>
        public void OnSettingsUI(UIHelperBase helper)
        {
            // Example: Adding a checkbox for a setting.
            var group = helper.AddGroup("My Mod Settings"); // Create a settings group.
            group.AddCheckbox(
                "A Example Setting",    // Label for the checkbox.
                ModSettings.ExampleSetting, // Initial state of the checkbox.
                isChecked =>                // Callback for when the checkbox is toggled.
                {
                    ModSettings.ExampleSetting = isChecked;
                    ModSettings.Save(); // Save the updated settings.
                });
        }
    }
}
