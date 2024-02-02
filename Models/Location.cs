using System.ComponentModel.DataAnnotations.Schema;

namespace Storeii.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string LocationName { get; set; }

        [ForeignKey("Driver_IdNavigation")]
        public int? Driver_Id { get; set; }                   // This is the foreign key
        public Driver Driver_IdNavigation { get; set; }      // This is the navigation property

    }
}
