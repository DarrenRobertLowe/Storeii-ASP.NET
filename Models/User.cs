using System.ComponentModel.DataAnnotations.Schema;

namespace Storeii.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName {  get; set; }
        public string UserPass { get; set; }
        public string Role { get; set; }


        /* A User can be a Customer a Driver or a Supplier, or maybe even all three,
         * so we have their corresponding foreign key ids here.
        */
        //[ForeignKey("Customer")]
        public int? Customer { get; set; }
        public Customer CustomerNavigation { get; set; }

        //[ForeignKey("Driver")]
        public int? Driver { get; set; }
        public Driver DriverNavigation { get; set; }

        //[ForeignKey("Supplier")]
        public int? Supplier { get; set; }
        public Supplier SupplierNavigation { get; set; }
    }
}
