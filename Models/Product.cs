using System.ComponentModel.DataAnnotations.Schema;

namespace Storeii.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; } = string.Empty; // or could be "", makes it so it's never null and means string methods can be used safely.
        public string Image { get; set; }
        public string Category { get; set; }
        public string Identifier { get; set; }

        public decimal Price { get; set; } // always use decimal for money!
        public int Stock { get; set; }

        // Foreign Keys
        [ForeignKey("Supplier_IdNavigation")]
        public int? Supplier_Id { get; set; }
        public Supplier Supplier_IdNavigation { get; set; }
    }
}
