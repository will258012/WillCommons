// <copyright>
// Copyright (c) will258012. All rights reserved.
// </copyright>

using UnityEngine;

namespace WillCommons
{
    /// <summary>
    /// Logging unity class.
    /// </summary>
    public class Logging
    {
        private static string TAG => (ModBase.Instance?.BaseName ?? ModBase.ModAssembly.GetName().Name) + ": ";
        /// <summary>
        /// Print a message to Unity log.
        /// </summary>
        /// <param name="msg">Message to log.</param>
        public static void Msg(object msg) => Debug.Log(TAG + msg);
        /// <summary>
        /// Print a warning message to Unity log.
        /// </summary>
        /// <param name="msg">Message to log.</param>
        public static void Warn(object msg) => Debug.LogWarning(TAG + msg);
        /// <summary>
        /// Print a error message to Unity log.
        /// </summary>
        /// <param name="msg">Message to log.</param>
        public static void Err(object msg) => Debug.LogError(TAG + msg);
        /// <summary>
        /// Priny a exception message to Unity log.
        /// </summary>
        /// <param name="e">Exception.</param>
        /// <param name="AdditionalMsg">Optional additional messages.</param>
        public static void Exception(System.Exception e, object AdditionalMsg = null)
        {
            Debug.Log(TAG);
            if (AdditionalMsg != null)
                Debug.Log(AdditionalMsg);
            Debug.LogException(e);
        }
    }

}
