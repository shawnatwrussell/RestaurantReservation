using RestaurantReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Services.Interfaces
{
    interface IRRNotificationService
    {
        public Task SaveNotificationAsync(Notification notification);

        public Task AdminNotificationAsync(Notification notification, int restaurantId);

        public Task MemberNotificationAsync(Notification notification, List<RRUser> members);

        public Task EmailNotificationAsync(Notification notification, string emailSubject);

        public Task SMSNotificationAsync(Notification notification, string phone);

        public Task<List<Notification>> GetReceivedNotificationsAsync(string userId);

        public Task<List<Notification>> GetSentNotificationsAsync(string userId);

    }
}
