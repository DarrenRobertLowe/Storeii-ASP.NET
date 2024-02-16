using System.ComponentModel.DataAnnotations.Schema;

namespace Storeii.Models
{
    public class Counties
    {
        public int Id { get; set; }
        public string County { get; set; }

        [ForeignKey("LocationId")]
        public int Location { get; set;}
        public Location LocationId { get; set; }
    }
}
