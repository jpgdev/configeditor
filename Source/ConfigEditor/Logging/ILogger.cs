using System;

namespace ConfigEditor.Logging
{
    public interface ILogger
    {
        void TraceDebug(string message);
        void TraceError(Exception exception, string message);
        void TraceError(string message);
    }
}