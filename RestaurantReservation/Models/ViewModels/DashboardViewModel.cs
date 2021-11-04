using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Models.ViewModels
{
    public class DashboardViewModel
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int ReservationId { get; set; }


        public Restaurant Restaurant { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<RRUser> Members { get; set; }
        public RRUser CurrentUser { get; set; }
        public List<Notification> Notifications { get; set; }

    }
}
