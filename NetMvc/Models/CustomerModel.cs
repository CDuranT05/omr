using Microsoft.AspNetCore.Mvc.Rendering;

namespace NetMvc.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public int CountryCode { get; set; }

       public DateTime Create_at { get; set; }

       public List<SelectListItem> Genders { get; set; }

       public List<SelectListItem> Countries { get; set; }

     
        

    }
}
