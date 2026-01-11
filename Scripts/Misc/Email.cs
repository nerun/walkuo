/* ***************************************************************************
 * Email.cs
 *
 * RunUO is an open-source server emulator for Ultima Online.
 * Copyright (C)  The RunUO Software Team
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License along
 * with this program; if not, see <https://www.gnu.org/licenses/>.
 ***************************************************************************/
using System;
using System.Text.RegularExpressions;
using System.Threading;
using Server;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Server.Misc
{
    public class Email
    {
        /* In order to support emailing, fill in EmailServer and FromAddress:
         * Example:
         *  public static readonly string EmailServer = "mail.domain.com";
         *  public static readonly string FromAddress = "mail@domain.com";
         * 
         * If you want to add crash reporting emailing, fill in CrashAddresses:
         * Example:
         *  public static readonly string CrashAddresses = "first@email.here,second@email.here,third@email.here";
         * 
         * If you want to add speech log page emailing, fill in SpeechLogPageAddresses:
         * Example:
         *  public static readonly string SpeechLogPageAddresses = "first@email.here,second@email.here,third@email.here";
         */
        
        public static readonly string EmailServer = null;
        public static readonly int EmailPort = 25;

        public static readonly string FromAddress = null;
        public static readonly string EmailUsername = null;
        public static readonly string EmailPassword = null;

        public static readonly string CrashAddresses = null;
        public static readonly string SpeechLogPageAddresses = null;

        private static Regex _pattern = new Regex(
            @"^[a-z0-9.+_-]+@([a-z0-9-]+\.)+[a-z]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase
        );

        public static bool IsValid(string address)
        {
            if (address == null || address.Length > 320)
            {
                return false;
            }

            return _pattern.IsMatch(address);
        }

        private static readonly object _lock = new object();

        public static void Configure()
        {
            // Nothing to configure on MailKit side; kept for RunUO compatibility.
        }

        public static bool Send(MimeMessage message)
        {
            try
            {
                DateTime now = DateTime.UtcNow;
                string messageID = string.Format(
                    "<{0}.{1}@{2}>",
                    now.ToString("yyyyMMdd"),
                    now.ToString("HHmmssff"),
                    EmailServer
                );

                message.Headers.Add("Message-ID", messageID);
                message.Headers.Add("X-Mailer", "WalkUO");

                lock (_lock)
                {
                    using (var client = new SmtpClient())
                    {
                        client.Connect(EmailServer, EmailPort, SecureSocketOptions.Auto);

                        if (EmailUsername != null)
                        {
                            client.Authenticate(EmailUsername, EmailPassword);
                        }

                        client.Send(message);
                        client.Disconnect(true);
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static void AsyncSend(MimeMessage message)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(SendCallback), message);
        }

        private static void SendCallback(object state)
        {
            MimeMessage message = (MimeMessage)state;

            if (Send(message))
            {
                Console.WriteLine(
                    "Sent e-mail '{0}' to '{1}'.",
                    message.Subject,
                    string.Join(", ", message.To)
                );
            }
            else
            {
                Console.WriteLine(
                    "Failure sending e-mail '{0}' to '{1}'.",
                    message.Subject,
                    string.Join(", ", message.To)
                );
            }
        }
    }
}
