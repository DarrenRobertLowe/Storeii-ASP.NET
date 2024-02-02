using System.ComponentModel.DataAnnotations.Schema;

namespace Storeii.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        // Foreign Keys
        [ForeignKey("Orders_IdNavigation")]
        public int? Orders_Id { get; set; }                   // This is the foreign key
        public Order Orders_IdNavigation { get; set; }      // This is the navigation property

        [ForeignKey("Product_IdNavigation")]
        public int? Product_Id { get; set; }
        public Product Product_IdNavigation { get; set; }
    }
}
