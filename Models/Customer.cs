using System.ComponentModel.DataAnnotations.Schema;

namespace Storeii.Models
{
    public class Customer
    {
        public int Id { get; set;}
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public object User { get; internal set; }

        // foreign keys
        [ForeignKey("AddressNavigation")]
        public int? Address { get; set; }                   // This is the foreign key
        public Address AddressNavigation { get; set; }      // This is the navigation property

        [ForeignKey("LocationNavigation")]
        public int? Location { get; set; }                   // This is the foreign key
        public Location LocationNavigation { get; set; }      // This is the navigation property
        
    }
}
