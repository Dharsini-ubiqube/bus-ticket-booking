using System;
using Azure;
using Azure.Communication.Email;
using Azure.Communication.Email.Models;
using Bus_Ticket_Booking_System.src.Models;
using Bus_Ticket_Booking_System.src.Models.Dto;

namespace Bus_Ticket_Booking_System.src.Services
{
	public class EmailNotification
	{
        static void Main(string[] args, AddTicket addTicket)
        {
            string connectionString = Environment.GetEnvironmentVariable("COMMUNICATION_SERVICES_CONNECTION_STRING");
            EmailClient emailClient = new EmailClient(connectionString);

            //sending email
            EmailContent emailContent = new EmailContent("Welcome to Azure Communication Service Email APIs.");
            emailContent.PlainText = "You are successfully Booked the Bus Ticket. ";
            List<EmailAddress> emailAddresses = new List<EmailAddress> { new EmailAddress(addTicket.userEmail) { DisplayName = "Friendly Display Name" } };
            EmailRecipients emailRecipients = new EmailRecipients(emailAddresses);
            EmailMessage emailMessage = new EmailMessage("donotreply@xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.azurecomm.net", emailContent, emailRecipients);
            SendEmailResult emailResult = emailClient.Send(emailMessage, CancellationToken.None);

            //Getting Message id
            Console.WriteLine($"MessageId = {emailResult.MessageId}");

            //Getting status of the mail
            Response<SendStatusResult> messageStatus = null;
            messageStatus = emailClient.GetSendStatus(emailResult.MessageId);
            Console.WriteLine($"MessageStatus = {messageStatus.Value.Status}");
            TimeSpan duration = TimeSpan.FromMinutes(3);
            long start = DateTime.Now.Ticks;
            do
            {
                messageStatus = emailClient.GetSendStatus(emailResult.MessageId);
                if (messageStatus.Value.Status != SendStatus.Queued)
                {
                    Console.WriteLine($"MessageStatus = {messageStatus.Value.Status}");
                    break;
                }
                Thread.Sleep(10000);
                Console.WriteLine($"...");

            } while (DateTime.Now.Ticks - start < duration.Ticks);
            Console.ReadLine();
        }
    }
}

