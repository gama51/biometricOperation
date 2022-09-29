using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iddk2000DotNet;

namespace IiritechMono
{
    /// <summary>
    /// <c>IriException</c> is the common base class.
    /// </summary>
    public class IriException : Exception
    {
        /// <summary>
        /// Detail result code explains the cause of error.
        /// </summary>
        public IddkResult ResultCode = IddkResult.Failed;

        /// <summary>
        /// Constructor
        /// </summary>
        public IriException()
            : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="retCode">Result code</param>
        public IriException(string message, IddkResult retCode)
            : base(message)
        {
            this.ResultCode = retCode;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Formatted message</param>
        /// <param name="args">Arguments for formatted message</param>
        public IriException(string message, params object[] args)
            : base(string.Format(message, args)) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Formatted message</param>
        /// <param name="retCode">Result code</param>
        /// <param name="args">Arguments for formatted message</param>
        public IriException(string message, IddkResult retCode,
                            params object[] args)
            : base(string.Format(message, args))
        {
            this.ResultCode = retCode;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="innerException">Inner exception</param>
        public IriException(string message, Exception innerException)
            : base(message, innerException) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="retCode">Result code</param>
        /// <param name="innerException">Inner exception</param>
        public IriException(string message, IddkResult retCode,
                            Exception innerException)
            : base(message, innerException)
        {
            this.ResultCode = retCode;
        }
    }
}
