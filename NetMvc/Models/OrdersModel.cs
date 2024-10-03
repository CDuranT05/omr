using Microsoft.AspNetCore.Mvc.Rendering;
using Org.BouncyCastle.Utilities.IO;

namespace NetMvc.Models
{
    public class OrdersModel
    {
        public int Id {  get; set; }


        public int UserId { get; set; }

        public string Status { get; set; }

        public DateTime Create_at { get; set; }
        public string UserName { get; set; }
        public string Product { get; set; } 
        public int ProductQuanty { get; set; }
        public List<OrdersModel> Data { get; set; } = new List<OrdersModel>();

        public List<SelectListItem> Products { get; set; }

        public List<OrdersModel> OrderItems { get; set; } = new List<OrdersModel>();


    }
}
