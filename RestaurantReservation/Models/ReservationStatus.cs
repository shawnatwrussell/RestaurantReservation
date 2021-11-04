using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Models
{
    public class ReservationStatus
    {
        //Primary Key
        public int Id { get; set; }

        [DisplayName("Reservation Status")]
        public string Name { get; set; }

    }
}
