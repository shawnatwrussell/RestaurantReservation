using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName{"RestaurantName"]
    }
}
