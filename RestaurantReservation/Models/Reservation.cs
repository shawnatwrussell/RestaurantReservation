using Microsoft.AspNetCore.Http;
using RestaurantReservation.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public int? RestaurantId { get; set; }

        [DisplayName("Team Member")]
        public string UserId { get; set; }

        [DisplayName("Ticket Status")]
        public int TicketStatusId { get; set; }

        [DisplayName("Ticket Owner")]
        public string OwnerUserId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Restaurant Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }


        [DataType(DataType.Date)]
        [DisplayName("Date Created")]
        public DateTimeOffset Created { get; set; }

        [DisplayName("Archived")]
        public bool Archived { get; set; }


        //Image File Properties
        [NotMapped]
        [DataType(DataType.Upload)]
        //[MaxFileSize(1024 * 1024)]
        //[AllowedExtensions(new string[] {".jpg", ",png"})]
        [DisplayName("Choose a File")]
        public IFormFile ImageFormFile { get; set; }

        [DisplayName("File Name")]
        public string ImageFileName { get; set; }
        public byte[] ImageFileData { get; set; }

        [DisplayName("File Extension")]
        public string ImageFileContentType { get; set; }


        [Required] //selection on drop-down needed
        [Display(Name = "Reservation Status")]
        public ReservationStatuses ReservationStatuses { get; set; } //link to enum

        [DataType(DataType.Date)]
        [DisplayName("Date Archived")]
        public DateTimeOffset? ArchivedDate { get; set; }




        //Navigational Properties
        public virtual Restaurant Restaurant { get; set; }

        public virtual RRUser User { get; set; }
        public virtual RRUser OwnerUser { get; set; }

        public virtual ReservationStatus ReservationStatus { get; set; }


        public virtual ICollection<Notification> Notifications { get; set; } =
            new HashSet<Notification>();


        public virtual ICollection<RRUser> Members { get; set; } =
            new HashSet<RRUser>();

    }
}
