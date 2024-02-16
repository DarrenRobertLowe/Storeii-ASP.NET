using System.ComponentModel.DataAnnotations.Schema;

namespace Storeii.Models
{
    public class Suborder_Items
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("SubOrderId")]
        public int SubOrder_Id { get; set; }
        public Suborder SubOrderId { get; set; }

        [ForeignKey("ProductId")]
        public int Product_Id { get; set; }
        public Product ProductId { get; set; }
    }
}
