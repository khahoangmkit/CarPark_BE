using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }
        public string Name { get; set; }

        public Address Address { get; set; }
    }
}