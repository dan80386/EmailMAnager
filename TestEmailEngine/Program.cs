using System;
using System.Net.Mail;
using EmailEngine;

namespace TestEmailEngine
{
    class Program
    {
        /// <summary>
        /// A simple test program to send an email using the EmailManager classes
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Sending test email!");

            try
            {
                // Put your test values into the following constants
                const string AUTH_TOKEN = "Put your smtp service authentication token here, or use your email address/password";
                const string SEND_TO = "a_valid_user@somedomain.com";
                const string REPLY_TO = "a_value_email_address@wat.com";               

                // Set up the objects
                MailMessage msg = new MailMessage();
                EmailEngine.Model.SmtpServer smtpServer = new EmailEngine.Model.SmtpServer();
                smtpServer.AuthenticationToken = AUTH_TOKEN;
                smtpServer.UseToken = true;
                smtpServer.SmtpPort = 587;
                smtpServer.ServerUrl = "smtp.gmail.com";

                // Create an email message
                smtpServer.SendFromEmailAddress = REPLY_TO;
                msg.To.Add(SEND_TO);
                msg.From = new MailAddress(REPLY_TO);
                msg.Body = "Hey there! Here is an email message.";
                msg.Subject = "Test subject";                
                msg.IsBodyHtml = true;

                // Set up the mail engine and attempt to send the message
                EmailEngine.SmtpManager smtpManager = new SmtpManager(smtpServer);
                EmailEngine.Model.SendResults results = smtpManager.SendEmail(msg);

                // Check the returned value
                if (!results.ErrorsOccurred)
                {
                    Console.WriteLine("The test message was sent.");
                }
                else
                {
                    Console.WriteLine("An exception occurred in SmtpManager: " + results.ResultsMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred when trying to send the test email: " + ex.Message);
            }
        }      
    }
}
