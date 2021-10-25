using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Entity
{
    public class Car
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string LicensePlate { get; set; }
        public string CarColor { get; set; }
        public string CarType { get; set; }
        public string Company { get; set; }
        
        public ParkingLot ParkingLot { get; set; }
    }
}
