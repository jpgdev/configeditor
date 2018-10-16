using System;

namespace ConfigEditor.Logging
{
    public class ConsoleLogger : ILogger
    {
        private readonly string m_loggerName;

        public ConsoleLogger(string loggerName)
        {
            m_loggerName = loggerName;
        }

        private string GetPrefix(LogLevel loggingLevel)
        {
            return $"[{DateTime.Now:HH:mm:ss.fff}][{m_loggerName}][{loggingLevel}] - ";
        }

        public void TraceDebug(string message) => Trace(LogLevel.Debug, message);

        public void TraceError(string message) => Trace(LogLevel.Error, message);

        public void TraceError(Exception exception, string message)
        {
            string exceptionMessage = null;
            if (exception != null)
            {
                exceptionMessage = $"{exception.Message}\n{exception.StackTrace}";
            }

            Trace(LogLevel.Error, message, exceptionMessage);
        }

        public void Trace(LogLevel level, string message, string extendedInformation)
        {
            Console.WriteLine($"{GetPrefix(level)}{message}\n{extendedInformation}");
        }

        public void Trace(LogLevel level, string message)
        {
            Console.WriteLine($"{GetPrefix(level)}{message}");
        }
    }
}