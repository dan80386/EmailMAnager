using System;
using System.Net.Mail;

namespace EmailEngine.Model
{
    /// <summary>
    /// A class to hold the results of a SendEmail operation, including any errors
    /// </summary>
    public class SendResults
    {
        /// <summary>
        /// A copy of the MailMessage object which was sent
        /// </summary>
        public MailMessage Message { get; set; }

        /// <summary>
        /// A human-readable message summarizing the operation status,
        /// including any error/exception information
        /// </summary>
        public string ResultsMessage { get; set; }

        /// <summary>
        /// The UTC date/time of when the mail message was sent to the Smtp service
        /// </summary>
        public DateTime SendDate { get; set; }

        /// <summary>
        /// True if any errors occurred during the send operation
        /// </summary>
        public bool ErrorsOccurred { get; set; } = false;
    }
}
