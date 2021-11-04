using Microsoft.AspNetCore.Identity.UI.Services;
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






    }
}
