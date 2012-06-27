using System;
using Caliburn.Micro;
using NLog;

namespace HydraBot.Gui.Tools
{
    /// <summary>
    /// Rough NLog adaptor for caliburn micro
    /// </summary>
    public class NLogAdaptor : ILog
    {
        private static Logger _log = NLog.LogManager.GetLogger("CaliburnLogger");

        public void Info(string format, params object[] args)
        {
            _log.Info(format,args);
        }

        public void Warn(string format, params object[] args)
        {
            _log.Warn(format, args);
        }

        public void Error(Exception exception)
        {
            _log.ErrorException("Caliburn pooped!",exception);
        }
    }
}
