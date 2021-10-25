using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entity
{
    public class Address
    {
        [Key, ForeignKey("Person")]
        public int PersonID { get; set; }

        public string City { get; set; }
    }
}