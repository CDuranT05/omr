using System.ComponentModel.DataAnnotations;

namespace NetMvc.Models.Db
{
    public class Gender
    {
        [StringLength(1)]
        public string Id { get; set; }

        [StringLength(45)]
        public string Description { get; set; }
    }
}
