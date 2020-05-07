using NLog;

namespace BusinessService.Api.Logger
{
    /// <summary>
    /// 
    /// </summary>
    public class LogNLog : ILog
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 
        /// </summary>
        public LogNLog()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void Information(string message)
        {
            logger.Info(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void Warning(string message)
        {
            logger.Warn(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void Debug(string message)
        {
            logger.Debug(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void Error(string message)
        {
            logger.Error(message);
        }
    }
}