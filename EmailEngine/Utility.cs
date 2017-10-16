using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailEngine
{
    /// <summary>
    /// Utility and helper mehods
    /// </summary>
    public static class Utility
    {

        /// <summary>
        /// Return a human-readable string containing the exception message and any of
        /// of its inner exception messages, and optionally the stack track of each exception.
        /// </summary>
        /// <param name="ex">Exception to extract the message from</param>
        /// <param name="includeStackTrace">True to include the exception's stack trace</param>
        /// <param name="messages">message text for recursion</param>
        /// <returns>string of exception message(s) and optionally, stack trace(s)</returns>
        public static string ExceptionToString(Exception ex, bool includeStackTrace, string messages = "")
        {
            if (ex == null)
                return string.Empty;

            if (messages == string.Empty)
                messages += ex.Message + "(HResult:" + ex.HResult + ")";

            if (includeStackTrace)
                messages += ex.StackTrace;

            if (ex.InnerException != null)
                messages += System.Environment.NewLine + ExceptionToString(ex.InnerException, includeStackTrace);

            return messages;
        }
    }
}
