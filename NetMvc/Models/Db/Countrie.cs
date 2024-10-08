using System.ComponentModel.DataAnnotations;
namespace NetMvc.Models.Db
{
    public class Countrie
    {
        [Key]
        public int Code { get; set; }

        [StringLength(45)]
        public string Name { get; set; }

        [StringLength(45)]
        public string ContinentName { get; set; }
    }
}
