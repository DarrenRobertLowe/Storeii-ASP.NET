using System.ComponentModel.DataAnnotations.Schema;

namespace Storeii.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string Role { get; set; }

        [ForeignKey("CustomerId")]
        public int Customer { get; set; }
        public Customer CustomerId { get; set; }

        [ForeignKey("DriverId")]
        public int Driver { get; set; }
        public Driver DriverId { get; set; }

        [ForeignKey("SupplierId")]
        public int Supplier { get; set; }
        public Supplier SupplierId { get; set; }

    }
}
