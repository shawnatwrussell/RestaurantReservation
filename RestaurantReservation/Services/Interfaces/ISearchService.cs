using RestaurantReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Services.Interfaces
{
    interface ISearchService
    {
        public IOrderedQueryable<Reservation> SearchContent(string searchString);
    }
}
