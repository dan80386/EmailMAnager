using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using EmailEngine.Model;

namespace EmailEngine
{


    public class SmtpManager
    {
        #region Properties and constructor

        EmailEngine.Model.SmtpServer _smtpServer;
        EmailEngine.Model.SendResults _sendResults;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="smtpServer">SmtpServer object with required server credentials and path</param>
        public SmtpManager(SmtpServer smtpServer)
        {
            _smtpServer = smtpServer;
            _sendResults = new SendResults();
        }

        #endregion

        #region Pubic methods

        /// <summary>
        /// Send an email using SMTP
        /// </summary>
        /// <param name="msg">System.Net.Mail.MailMessageobject</param>
        /// <returns>SendResults object with the results of the send operation, including errors if any</returns>
        public SendResults SendEmail(System.Net.Mail.MailMessage msg)
        {
            try
            {
                SendResults results = new SendResults();
                msg.From = new MailAddress(_smtpServer.SendFromEmailAddress);

                SmtpClient smtpClient = new SmtpClient(_smtpServer.ServerUrl, _smtpServer.SmtpPort);
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                if (_smtpServer.UseToken)
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(_smtpServer.SendFromEmailAddress, _smtpServer.AuthenticationToken);                    
                }
                else
                {
                    smtpClient.Credentials = new NetworkCredential(_smtpServer.AuthenticationUserName, _smtpServer.AuthenticationPassword);
                }

                smtpClient.Send(msg);

                results.Message = msg;
            }

            catch (SmtpException ex)
            {
                _sendResults.ErrorsOccurred = true;
                _sendResults.ResultsMessage += "Exception caught: " + Utility.ExceptionToString(ex, true);
            }
            catch (Exception ex)
            {
                _sendResults.ErrorsOccurred = true;
                _sendResults.ResultsMessage += "Exception caught: " + Utility.ExceptionToString(ex, true);
            }

            _sendResults.ResultsMessage = "Email message sent.";
            _sendResults.SendDate = System.DateTime.UtcNow;

            return _sendResults;
        }

    }

    #endregion

}
