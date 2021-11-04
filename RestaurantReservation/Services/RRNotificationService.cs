using Microsoft.AspNetCore.Identity.UI.Services;
using RestaurantReservation.Models;
using RestaurantReservation.Services.Interfaces;
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

        public Task SaveNotificationAsync(Notification notification)

        public Task AdminNotificationAsync(Notification notification, int restaurantId)
        {
            try
            {
                //Get Restaurant Admin
                List<RRUser> admins = await _infoService.GetMembersInRoleAsync("Admin", restaurantId);

                foreach(RRUser rrUser in admins)
                {
                    notification.RecipientId = rrUser.Id;

                    await EmailNotificationAsync(notification, notification.Title);
                }
            }

            catch
            {
                throw;
            }
        }

        public Task MemberNotificationAsync(Notification notification, List<RRUser> members)

        public Task EmailNotificationAsync(Notification notification, string emailSubject)

        public Task SMSNotificationAsync(Notification notification, string phone)

        public Task<List<Notification>> GetReceivedNotificationsAsync(string userId)

        public Task<List<GetSentNotificationsAsync>>(string userId)






    }
}
