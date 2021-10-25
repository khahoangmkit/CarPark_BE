using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Entity
{
    public class BookingOffice
    {
        [Required]
        public int Id { get; set; }
        public DateTime EndContractDeadline { get; set; }
        public DateTime StartContractDeadline { get; set; }
        public string OfficeName { get; set; }
        public string OfficePhone { get; set; }
        public string OfficePlace { get; set; }
        public int OfficePrime { get; set; }
        
        public Trip Trip { get; set; }
    }   
}
