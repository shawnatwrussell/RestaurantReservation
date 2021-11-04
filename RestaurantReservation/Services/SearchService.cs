using RestaurantReservation.Data;
using RestaurantReservation.Models;
using RestaurantReservation.Models.Enums;
using RestaurantReservation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Services
{
    public class SearchService : ISearchService
    {
        private readonly ApplicationDbContext _context;

        public SearchService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IOrderedQueryable<Reservation> SearchContent(string searchString)
        {
            //Step One: Get an IQueryable that contains all the Reservations
            //in the event that the User doesn't supply a search string
            var result = _context.Reservation.Where(
                p => p.ReservationStatuses == ReservationStatuses.Created);
            searchString = searchString.ToLower();

            if (!string.IsNullOrEmpty(searchString))
            {
                //c.Moderated == null &&
                //c.Author.FullName.Contains(searchString)
                //c.Author.Email.Contains(searchString)

                result = result.Where(p => p.Title.ToLower().Contains(searchString) ||
                                           p.Description.ToLower().Contains(searchString)
                                      );

            }

            return result.OrderByDescending(p => p.Created);
        }
    }
}
