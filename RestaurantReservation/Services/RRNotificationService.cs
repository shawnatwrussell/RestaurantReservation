using Microsoft.AspNetCore.Identity.UI.Services;
using RestaurantReservation.Models;
using RestaurantReservation.Data;
using RestaurantReservation.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Services
{
    public class RRNotificationService : IRRNotificationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailService;
        private readonly IRRRestaurantInfoService _infoService;

        public RRNotificationService(ApplicationDbContext context, 
            IEmailSender emailService,
            IRRRestaurantInfoService infoService)
        {
            _context = context;
            _emailService = emailService;
            _infoService = infoService;
        }

        //send a notification to a specific company's Admin, to let them know a ticket was created
        public async Task AdminsNotificationAsync(Notification notification, int restaurantId)
        {
            try
            {
                //Get company admin
                List<RRUser> admins = await _infoService.GetMembersInRoleAsync("Admin", restaurantId);

                foreach (RRUser rrUser in admins)
                {
                    notification.RecipientId = rrUser.Id;

                    await EmailNotificationAsync(notification, notification.Message);
                }
            }

            catch
            {
                throw;
            }
        }

        public async Task EmailNotificationAsync(Notification notification, string emailSubject)
        {
            RRUser rrUser = await _context.Users.FindAsync(notification.RecipientId);

            //Send Email
            string rrUserEmail = rrUser.Email;
            string message = notification.Message;

            try
            {
                await _emailService.SendEmailAsync(rrUserEmail, emailSubject, message);
            }

            catch
            {
                throw;
            }
        }

        public async Task<List<Notification>> GetReceivedNotificationsAsync(string userId)
        {
            List<Notification> notifications = await _context.Notification
                                                                     .Include(n => n.Recipient)
                                                                     .Include(n => n.Sender)
                                                                     .Include(n => n.Date)
                                                                     .Where(n => n.RecipientId == userId).ToListAsync();
            return notifications;
        }

        public async Task<List<Notification>> GetSentNotificationsAsync(string userId)
        {
            List<Notification> notifications = await _context.Notification
                                                         .Include(n => n.Recipient)
                                                         .Include(n => n.Sender)
                                                         .Include(n => n.Date)
                                                         .Where(n => n.SenderId == userId).ToListAsync();
            return notifications;

        }

        public Task MembersNotificationAsync(Notification notification, List<RRUser> members)
        {
            throw new NotImplementedException();
        }

        public async Task SaveNotificationAsync(Notification notification)
        {
            try
            {
                await _context.AddAsync(notification);
                await _context.SaveChangesAsync();
            }

            catch
            {
                throw;
            }
        }

        public Task SMSNotificationAsync(string phone, Notification notification)
        {
            throw new NotImplementedException();
        }
    }
}
