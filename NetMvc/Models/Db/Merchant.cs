using System.ComponentModel.DataAnnotations;

namespace NetMvc.Models.Db
{
    public class Merchant
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string MerchantName { get; set; }


        public int AdminId { get; set; }

        public int CountryCode { get; set; }

        public DateTime CreatAt { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
