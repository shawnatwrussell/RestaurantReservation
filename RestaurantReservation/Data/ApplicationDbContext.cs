using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestaurantReservation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantReservation.Data
{
    public class ApplicationDbContext : IdentityDbContext<RRUser>
    {
        private readonly IConfiguration Configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        public DbSet<RestaurantReservation.Models.Restaurant> Restaurant { get; set; }
        public DbSet<RestaurantReservation.Models.Reservation> Reservation { get; set; }
        public DbSet<RestaurantReservation.Models.Notification> Notification { get; set; }
        public DbSet<RestaurantReservation.Models.ReservationStatus> ReservationStatus { get; set; }


    }
}
