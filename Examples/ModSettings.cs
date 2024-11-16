using ColossalFramework.IO;
using System.IO;
using System.Xml.Serialization;
namespace WillCommons.Examples
{
    /// <summary>
    /// Represents a settings file for a mod, serialized in XML format.
    /// </summary>
    [XmlRoot("MySettings")] // Specifies the root element name for the XML file.
    public sealed class ModSettings : XMLFileBase
    {
        /// <summary>
        /// The file path for storing the mod's settings.
        /// </summary>
        [XmlIgnore] // Prevents this field from being serialized into XML.
        private static readonly string SettingsFileName = Path.Combine(DataLocation.localApplicationData, "MySettings.xml");

        /// <summary>
        /// Get the active <see cref="ModSettings"/> instance.
        /// NOTE: This is only for other mods to access mod settings. Do not use this for calls within the mod.
        /// </summary>
        [XmlIgnore]
        public static ModSettings Instance
        {
            get
            {
                if (_modSettings == null)
                {
                    // Lazy initialization: create a new instance if it hasn't been loaded yet.
                    _modSettings = new ModSettings();
                }
                return _modSettings;
            }
        }

        /// <summary>
        /// Hold the singleton instance of ModSettings.
        /// </summary>
        [XmlIgnore]
        private static ModSettings _modSettings;

        /// <summary>
        /// Load the settings from the XML file. If the file does not exist, a new default instance is created.
        /// </summary>
        internal static void Load() => Load<ModSettings>(SettingsFileName);

        /// <summary>
        /// Save the current settings to the XML file. If the file does not exist, this will create it.
        /// </summary>
        internal static void Save() => Save<ModSettings>(SettingsFileName);

        /// <summary>
        /// Setting that used to be serialized in the XML file.
        /// </summary>
        [XmlElement("ExampleSetting")] // Specifies the XML element name for this setting.
        public bool XMLExampleSetting { get => ExampleSetting; set => ExampleSetting = value; }

        /// <summary>
        /// An example setting used within the mod. This is not directly serialized, but its value is managed via XMLExampleSetting.
        /// </summary>
        [XmlIgnore]
        internal static bool ExampleSetting = false;// default value
    }
}
