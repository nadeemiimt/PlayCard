namespace CardPlay.Interface
{
    public interface IApplicationLogger<T>
    {
        /// <summary>
        /// Log error message.
        /// </summary>
        /// <param name="message">message.</param>
        /// <param name="obj">optional data</param>
        void Error(string message, object obj = null);

        /// <summary>
        /// Log info message.
        /// </summary>
        /// <param name="message">message.</param>
        /// <param name="obj">optional data</param>
        void Info(string message, object obj = null);

        /// <summary>
        /// Log warning message.
        /// </summary>
        /// <param name="message">message.</param>
        /// <param name="obj">optional data</param>
        void Warning(string message, object obj = null);

        /// <summary>
        /// Log debug message.
        /// </summary>
        /// <param name="message">message.</param>
        /// <param name="obj">optional data</param>
        void Debug(string message, object obj = null);
    }
}
