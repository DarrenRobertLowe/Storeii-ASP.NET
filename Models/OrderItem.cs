using System.ComponentModel.DataAnnotations.Schema;

namespace Storeii.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        // Foreign Keys
        [ForeignKey("OrderId")]
        public int? Order_Id { get; set; }                     // This is the foreign key
        public Orders OrderId { get; set; }          // This is the navigation property

        [ForeignKey("ProductId")]
        public int? Product_Id { get; set; }
        public Product ProductId { get; set; }
    }
}
