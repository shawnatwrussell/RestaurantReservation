using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Data;
using RestaurantReservation.Models;
using RestaurantReservation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Services
{
    public class RRRestaurantInfoService : IRRRestaurantInfoService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<RRUser> _userManager;

        public RRRestaurantInfoService(ApplicationDbContext context,
            UserManager<RRUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //Get a List of all the Users in a Company
        public async Task<List<RRUser>> GetAllMembersAsync(int restaurantId)
        {
            List<RRUser> rrUsers = new();

            rrUsers = await _context.Users.Where(u => u.RestaurantId == restaurantId).ToListAsync();

            return rrUsers;
        }

        //Get a List of all the Projects in a Company
        public async Task<List<Reservation>> GetAllReservationsAsync(int restaurantId)
        {
            List<Reservation> reservations = new();

            reservations = await _context.Reservation.Include(p => p.Members)
                                             .Where(p => p.RestaurantId == restaurantId).ToListAsync();

            return reservations;
        }


        //Get Specified info related to a Specific Company
        public async Task<Restaurant> GetRestaurantInfoByIdAsync(int? restaurantId)
        {
            Restaurant restaurant = new();

            if (restaurantId != null)
            {
                restaurant = await _context.Restaurant
                                         .Include(c => c.Members)
                                         .Include(c => c.Reservations)
                                         .FirstOrDefaultAsync(c => c.Id == restaurantId);
            }

            return restaurant;
        }

        //Get a List of Members Assigned to a Specific Role
        public async Task<List<RRUser>> GetMembersInRoleAsync(string roleName, int restaurantId)
        {
            List<RRUser> users = (await _userManager.GetUsersInRoleAsync(roleName)).ToList();

            List<RRUser> roleUsers = users.Where(u => u.RestaurantId == restaurantId).ToList();

            return roleUsers;

        }
    }
}