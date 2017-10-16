using System;

namespace EmailEngine.Model
{
    public class SmtpServer
    {
        /// <summary>
        /// Set to true to use an authentication token instead of a password. 
        /// This is typical of using GMail.
        /// </summary>
        public bool UseToken { get; set; }

        /// <summary>
        /// The authentication token for the Smtp service. This property 
        /// must be set to a valid token of the SmtpServer.UseToken property
        /// is set to True.
        /// </summary>
        public string AuthenticationToken { get; set; }

        /// <summary>
        /// The user name to login as
        /// </summary>
        public string AuthenticationUserName { get; set; }

        /// <summary>
        /// Ths password for AuthenticationUserName. This property is not
        /// used if SmtpServer.UseToken is true.
        /// </summary>
        public string AuthenticationPassword { get; set; }

        /// <summary>
        /// The Url of the Smtp service, such as smtp.gmail.net or smtp.sendgrid.net
        /// </summary>
        public string ServerUrl { get; set; }

        /// <summary>
        ///  The port number for the Smtp service. Although a value of 25 is the default
        ///  Smtp port, is is not reliable since it is blocked by many IPs becasue of
        ///  spam. Try values of 587 or 465, or check with your Smtp service provider.
        /// </summary>
        public int SmtpPort { get; set; }

        /// <summary>
        /// The email address to send from. This must be a valid email address on the
        /// sending Smtp service if the SmtpServer.UseToken is set to True;
        /// </summary>
        public string SendFromEmailAddress { get; set; }
    }

}
