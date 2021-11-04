using RestaurantReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Services.Interfaces
{
    interface IRRRestaurantInfoService
    {
        Task<Restaurant> GetRestaurantInfoByIdAsync(int? restaurantId);

        Task<List<RRUser>> GetAllMembersAsync(int restaurantId);

        Task<List<Reservation>> GetAllReservationsAsync(int restaurantId);

        Task<List<RRUser>> GetMembersInRoleAsync(string roleName, int restaurantId);

    }
}
