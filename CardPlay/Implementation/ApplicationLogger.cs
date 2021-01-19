using System;
using System.Collections.Generic;
using System.Text;
using CardPlay.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CardPlay.Implementation
{
    public class ApplicationLogger<T> : IApplicationLogger<T>
    {
        private readonly ILogger<T> _logger;

        public ApplicationLogger()
        {
            var services = new ServiceCollection()
                .AddLogging(logBuilder => logBuilder.SetMinimumLevel(LogLevel.Debug))
                .BuildServiceProvider();


            _logger = services.GetService<ILoggerFactory>()
                .AddLog4Net()
                .CreateLogger<T>();
        }

        /// <summary>
        /// Log error message.
        /// </summary>
        /// <param name="message">message.</param>
        /// <param name="obj">optional data</param>
        public void Error(string message, object obj = null)
        {
            this._logger.LogError(message, obj);
        }

        /// <summary>
        /// Log info message.
        /// </summary>
        /// <param name="message">message.</param>
        /// <param name="obj">optional data</param>
        public void Info(string message, object obj = null)
        {
            this._logger.LogInformation(message, obj);
        }

        /// <summary>
        /// Log warning message.
        /// </summary>
        /// <param name="message">message.</param>
        /// <param name="obj">optional data</param>
        public void Warning(string message, object obj = null)
        {
            this._logger.LogWarning(message, obj);
        }

        /// <summary>
        /// Log debug message.
        /// </summary>
        /// <param name="message">message.</param>
        /// <param name="obj">optional data</param>
        public void Debug(string message, object obj = null)
        {
            this._logger.LogDebug(message, obj);
        }
    }
}
