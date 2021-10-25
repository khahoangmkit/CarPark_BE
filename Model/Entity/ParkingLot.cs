using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Entity
{
    public class ParkingLot
    {
     
        [Required]
        public int Id { get; set; }
        
        
        [Required]
        public int ParkArea { get; set; }
        
        [Required]
        public string ParkName { get; set; }
        
        public string ParkPlace { get; set; }
        
        public int ParkPrice { get; set; }

        public string ParkStratus { get; set; }
    }
}
