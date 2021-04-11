using System;
using System.Collections.Generic;
using System.IO;

namespace StarWing.Framework
{
    internal static class Log
    {
        private static readonly List<TextWriter> Outputs = new();

        public static void RegisterOutput(TextWriter stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            Outputs.Add(stream);
        }

        public static void Info(string message)
        {
            var info = $"{DateTime.Now} [INFO]: {message}";
            Outputs.ForEach(writer => writer.WriteLineAsync(info));
        }

        public static void Debug(string message)
        {
            var info = $"{DateTime.Now} [DEBUG]: {message}";
            Outputs.ForEach(writer => writer.WriteLineAsync(info));
        }

        public static void Error(string message, Exception? ex)
        {
            var userInfo = $"{DateTime.Now} [ERROR]: {message}";
            var exceptionMessage = ex == null
                                       ? string.Empty
                                       : $"Stack trace: {ex.StackTrace}\n"
                                       + $"Message: {ex.Message}";
            var info = string.Concat(userInfo, exceptionMessage);
            Outputs.ForEach(writer => writer.WriteLineAsync(info));
        }
    }
}