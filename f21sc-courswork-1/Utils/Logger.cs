using System;

namespace f21sc_courswork_1.Utils
{
    /// <summary>
    /// Class dedicated to log what happens in the program, especially in the technical flow (eg not the user actions)
    /// </summary>
    class Logger
    {
        /// <summary>
        /// Generic logging method
        /// </summary>
        /// <param name="logType"><see cref="LogType"/> item specifying the level of this log</param>
        /// <param name="message">Message to display along with the log</param>
        private static void Trace(LogType logType, string message)
        {
            Console.WriteLine("{0}: {1}", logType, message);
        }

        /// <summary>
        /// Logs an info-level message
        /// </summary>
        /// <param name="message">Message to log</param>
        public static void Info(string message)
        {
            Trace(LogType.INFOS, message);
        }


        /// <summary>
        /// Logs an error-level message
        /// </summary>
        /// <param name="message">Message to log</param>
        public static void Error(string message)
        {
            Trace(LogType.ERROR, message);
        }

        /// <summary>
        /// Enum for log types
        /// </summary>
        private enum LogType
        {
            INFOS,
            ERROR,
        }
    }
}
