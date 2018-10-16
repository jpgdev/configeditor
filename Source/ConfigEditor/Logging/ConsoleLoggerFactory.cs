using System;

namespace ConfigEditor.Logging
{
    public class ConsoleLoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger(Type type)
        {
            return new ConsoleLogger(type.Name);
        }

        public ILogger CreateLogger(object obj)
        {
            return new ConsoleLogger(obj.GetType().Name);
        }
    }
}