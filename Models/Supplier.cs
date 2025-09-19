using System.ComponentModel.DataAnnotations.Schema;

namespace Storeii.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public User User { get; internal set; }


        // Foreign Keys
        [ForeignKey("Address_IdNavigation")]
        public int Address_Id { get; set;}
        public Address Address_IdNavigation { get; set; }

        [ForeignKey("Location_IdNavigation")]
        public int Location_Id { get; set; }
        public Location Location_IdNavigation { get; set; }
        
    }
}
