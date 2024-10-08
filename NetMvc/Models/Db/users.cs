using System.ComponentModel.DataAnnotations;

namespace NetMvc.Models.Db
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public int CountryCode { get; set; }

        public DateTime Create_at { get; set; }

    }
}
