using System.ComponentModel.DataAnnotations.Schema;

namespace Storeii.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }

        // foreign keys
        [ForeignKey("AddressNavigation")]
        public int? Address { get; set; }     // This is the foreign key
        public Address AddressNavigation { get; set; }    // This is the navigation property

 
    }
}
