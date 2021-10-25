using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Entity
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string FullName { get; set; }
        
        public DateTime DateOfBirth { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Sex { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Phone { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Account { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Department { get; set; }
    }
}
