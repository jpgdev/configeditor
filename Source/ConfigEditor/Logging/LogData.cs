using System;

namespace ConfigEditor.Logging
{
    public struct LogData
    {
        public string LoggerName { get; }
        public LogLevel Level { get; set; }
        public string Message { get; set; }
        public DateTimeOffset TimeStamp { get; }
        public Exception Exception { get; set; }
        public string ExtendedMessage { get; set; }

        public LogData(
            string loggerName,
            LogLevel level, 
            string message, 
            DateTimeOffset timeStamp = default(DateTimeOffset),
            Exception exception = null, 
            string extendedMessage = null)
        {
            LoggerName = loggerName;
            Level = level;
            Message = message;
            Exception = exception;
            ExtendedMessage = extendedMessage;

            if (timeStamp == default(DateTimeOffset))
                timeStamp = DateTimeOffset.Now;

            TimeStamp = timeStamp;
        }
    }
}