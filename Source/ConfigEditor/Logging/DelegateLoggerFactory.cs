using System;

namespace ConfigEditor.Logging
{
    public class DelegateLoggerFactory : ILoggerFactory
    {
        private readonly Action<LogData> m_logAction;

        public DelegateLoggerFactory(Action<LogData> logAction)
        {
            m_logAction = logAction;
        }


        public ILogger CreateLogger(Type type)
        {
            return new DelegateLogger(type.Name, m_logAction);
        }

        public ILogger CreateLogger(object obj)
        {
            return new DelegateLogger(obj.GetType().Name, m_logAction);
        }
    }
}