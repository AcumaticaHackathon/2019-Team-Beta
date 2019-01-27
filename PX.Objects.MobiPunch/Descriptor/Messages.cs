using PX.Common;
using PX.Data;
using System;

namespace PX.Objects.MobiPunch
{
    [PXLocalizable(Messages.Prefix)]
    public static class Messages
    {
        public const string Prefix = "MP";

        public const string PunchedIn = "Punched In";
        public const string PunchedOut = "Punched Out";
        public const string ConditionallyPunchedIn = "Conditionally Punched In";

        /// <summary>
        /// Localize the message
        /// </summary>
        /// <param name="msg">Message to localize</param>
        /// <returns>Localized message</returns>
        public static string GetLocal(string msg)
        {
            return GetLocal(msg, typeof(Messages));
        }

        /// <summary>
        /// Localize the message with provided format arguments
        /// </summary>
        /// <param name="msg">Message to localize</param>
        /// <param name="formatArgs">Arguments for string.Format</param>
        /// <returns>Localized message</returns>
        public static string GetLocal(string msg, params object[] formatArgs)
        {
            return string.Format(GetLocal(msg, typeof(Messages)), formatArgs);
        }

        /// <summary>
        /// Localize the message
        /// </summary>
        public static string GetLocal(string msg, Type msgType)
        {
            return PXLocalizer.Localize(msg, msgType.ToString());
        }
    }
}