using System.ComponentModel.DataAnnotations.Schema;

namespace Storeii.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        // foreign keys
        [ForeignKey("Customer_IdNavigation")]
        public int? Customer_Id{ get; set; }                  // This is the foreign key
        public Customer Customer_IdNavigation { get; set; }     // This is the navigation property

        [ForeignKey("Product_IdNavigation")]
        public int? Product_Id { get; set; }
        public Product Product_IdNavigation { get; set; }
    }
}
