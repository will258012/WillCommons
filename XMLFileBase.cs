// <copyright file="XMLFileUtils.cs" company="algernon (K. Algernon A. Sheppard)">
// Copyright (c) algernon (K. Algernon A. Sheppard). All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the AlgernonCommons project root for full license information.
// </copyright>
using ColossalFramework;
using System;
using System.IO;
using System.Xml.Serialization;

namespace WillCommons
{
    /// <summary>
    /// XML file utilities.
    /// </summary>
    public class XMLFileBase
    {
        /// <summary>
        /// Load the specified XML file.
        /// </summary>
        /// <typeparam name="TFile">XML file type.</typeparam>
        /// <param name="fileName">Filename.</param>
        public static void Load<TFile>(string fileName) where TFile : new()
        {
            Logging.Msg("loading XML file " + fileName);

            // Null check.
            if (fileName.IsNullOrWhiteSpace())
            {
                Logging.Err("invalid XML filename");
                return;
            }

            try
            {
                // Check to see if configuration file exists.
                if (File.Exists(fileName))
                {
                    // Read it.
                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(TFile));
                        if (!(xmlSerializer.Deserialize(reader) is TFile xmlFile))
                        {
                            Logging.Err("couldn't deserialize XML file " + fileName);
                        }
                    }
                }
                else
                {
                    Logging.Msg("XML file " + fileName + " not found");
                }
            }
            catch (Exception e)
            {
                Logging.Err(e + "exception reading XML file " + fileName);
            }
        }

        /// <summary>
        /// Save XML file.
        /// </summary>
        /// <typeparam name="TFile">XML file type.</typeparam>
        /// <param name="fileName">Filename.</param>
        public static void Save<TFile>(string fileName) where TFile : new()
        {
            try
            {
                Logging.Msg("saving XML file " + fileName);

                // Pretty straightforward.
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(TFile));
                    xmlSerializer.Serialize(writer, new TFile());
                }
            }
            catch (Exception e)
            {
                Logging.Err(e + "exception saving XML settings file");
            }
        }
    }
}