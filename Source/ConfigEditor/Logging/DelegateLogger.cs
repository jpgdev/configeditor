using System;

namespace ConfigEditor.Logging
{
    public class DelegateLogger : ILogger
    {
        private readonly string m_loggerName;
        private readonly Action<LogData> m_loggerAction;

        public DelegateLogger(string loggerName, Action<LogData> loggerAction)
        {
            m_loggerAction = loggerAction ?? throw new ArgumentNullException(nameof(loggerAction));
            m_loggerName = loggerName;
        }

        public void TraceDebug(string message)
        {
            m_loggerAction.Invoke(new LogData(m_loggerName, LogLevel.Debug, message));
        }

        public void TraceError(Exception exception, string message)
        {
            m_loggerAction.Invoke(new LogData(m_loggerName, LogLevel.Error, message, exception:exception));
        }

        public void TraceError(string message)
        {
            m_loggerAction.Invoke(new LogData(m_loggerName, LogLevel.Error, message));
        }
    }
}