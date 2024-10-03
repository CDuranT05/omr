using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetMvc.Models.Db
{
    public class Product
    {
        public int Id { get; set; }

        public int MerchantId { get; set; }

        public virtual Merchant Merchant { get; set; }

        [StringLength(45)]
        public string Name { get; set; }

        [Column(TypeName = "Decimal(12,2)")]
        public decimal Price { get; set; }

        public bool Status { get; set; }

        public DateTime CreatAt { get; set; }
    }
}
