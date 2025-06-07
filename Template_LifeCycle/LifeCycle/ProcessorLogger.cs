using System.Collections.Generic;
using Stride.Engine;

namespace Template_LifeCycle.LifeCycle
{
    public class ProcessorLogger : SyncScript
    {
        public static ProcessorLogger Instance;

        private List<(LogType logType, string context)> messageList;

        public enum LogType
        {
            Info,
            Debug,
            Warning,
            Error,
            Fatal,
            Verbose
        }

        public override void Start()
        {
            Instance = this;
            messageList = new();

            Log.ActivateLog(Stride.Core.Diagnostics.LogMessageType.Debug);
            Log.Verbose("Test");
        }

        public override void Update()
        {
            foreach (var message in messageList)
            {
                if (message.logType == LogType.Info) Log.Info(message.context);
                if (message.logType == LogType.Debug) Log.Debug(message.context);
                if (message.logType == LogType.Warning) Log.Warning(message.context);
                if (message.logType == LogType.Error) Log.Error(message.context);
                if (message.logType == LogType.Fatal) Log.Fatal(message.context);
                if (message.logType == LogType.Verbose) Log.Verbose(message.context);
            }
            messageList.Clear();
        }

        public void LogMessage((LogType, string) message)
        {
            messageList.Add(message);
        }
    }
}
