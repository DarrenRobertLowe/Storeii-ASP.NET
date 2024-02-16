using System.ComponentModel.DataAnnotations.Schema;

namespace Storeii.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public int OrderStatus { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }


        // foreign keys
        [ForeignKey("CustomerId")]
        public int Customer_Id { get; set; }
        public Customer CustomerId { get; set; }

        [ForeignKey("AddressId")]
        public int Address_Id { get; set; }
        public Address AddressId { get; set; }

        [ForeignKey("DriverId")]
        public int Driver_Id { get; set; }
        public Driver DriverId { get; set; }

        [ForeignKey("LocationId")]
        public int Location_Id {  get; set; }
        public Location LocationId { get; set; }


    }
}
