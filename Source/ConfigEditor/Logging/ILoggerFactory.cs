using System;
using System.Collections.Generic;

namespace ConfigEditor.Logging
{
    public interface ILoggerFactory
    {
        ILogger CreateLogger(Type type);

        ILogger CreateLogger(object obj);
    }
}