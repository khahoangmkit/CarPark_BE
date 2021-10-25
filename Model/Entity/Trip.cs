using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Entity
{
    public class Trip
    {
        [Required]
        public int Id { get; set; }
        public int BookedTicketNumber { get; set; }
        public string CarType { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public string Driver { get; set; }
        public int MaximumOnlineTicketNumber { get; set; }
    }
}
