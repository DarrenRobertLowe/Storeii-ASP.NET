using System.ComponentModel.DataAnnotations.Schema;

namespace Storeii.Models
{
    public class Suborder
    {
        public int Id { get; set; }
        public int OrderStatus { get; set; }

        [ForeignKey("OrderId")]
        public int Order_Id { get; set; }
        public Orders OrderId {  get; set; }

        [ForeignKey("SupplierId")]
        public int Supplier_Id { get; set; }
        public Orders SupplierId { get; set; }
    }
}
