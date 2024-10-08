using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using NetMvc.Data;
using NetMvc.Models;
using NetMvc.Models.Db;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace NetMvc.Controllers

{
    public class CustomerController : Controller
    {
        StoreDbContext _storeDbContext;
        ExampleDl _exampleDl;

        public CustomerController(StoreDbContext storeDbContext, ExampleDl exampleDl)
        {
            _storeDbContext = storeDbContext;
            _exampleDl = exampleDl;
        }

        //  List<OrdersModel> productos = new List<OrdersModel>()
        static List<OrdersModel> OrderItems = new List<OrdersModel>();
        



        public IActionResult Index()
        {

           // List<CustomerModel> data = new List<CustomerModel>();


            var users = _storeDbContext.Users.ToList();

            

          


           /** MySqlConnection connection = new MySqlConnection("user Id=root;Password=samy1;Host=localhost;Database=academy_net;");
            connection.Open();

            MySqlCommand command = connection.CreateCommand();

            command.CommandText = $"SELECT id, full_name, email, gender, date_of_birth, country_code, create_at FROM users_old;";

            MySqlDataReader reader = command.ExecuteReader();
            

            while (reader.Read())
            {

                data.Add(new CustomerModel
                {
                    Id = reader.GetInt32(0),
                    FullName = reader.GetString(1),
                    Email = reader.GetString(2),
                    Gender = reader.GetString(3),
                    BirthDate = (DateTime)reader["date_of_birth"],
                    CountryCode = reader.GetInt32(5),


                });

            }**/

            return View(users);
        }

        public IActionResult Creation()
        {
            List<SelectListItem> data = new List<SelectListItem>();

            var gender = _storeDbContext.Genders.ToList();

            foreach(var genders in gender)
            {
                data.Add(new SelectListItem
                {
                    Value = genders.Id,
                    Text = genders.Description,
                });
            }

            /* MySqlConnection connection = new MySqlConnection("user Id=root;Password=samy1;Host=localhost;Database=academy_net;");
             connection.Open();

             MySqlCommand command = connection.CreateCommand();

             command.CommandText = $"SELECT gender_id, Description FROM gender_old;";

             MySqlDataReader reader = command.ExecuteReader();


             while (reader.Read())
             {

                
             }
             reader.Close();

             connection = new MySqlConnection("user Id=root;Password=samy1;Host=localhost;Database=academy_net;");
             connection.Open();

             command = connection.CreateCommand();

             command.CommandText = $"SELECT code, name FROM countries_old;";

             reader = command.ExecuteReader();
             List<SelectListItem> dataC = new List<SelectListItem>();

             while (reader.Read())
             {

                 dataC.Add(new SelectListItem
                 {
                     Value = reader.GetInt32(0).ToString(),
                     Text = reader.GetString(1),



                 });
             }*/
            List<SelectListItem> dataC = new List<SelectListItem>();
            var countries = _storeDbContext.Countries.ToList();

            foreach (var country in countries)
            {
                dataC.Add(new SelectListItem
                {
                    Value = country.Code.ToString(),
                    Text = country.Name,
                });
            }


            return View(new CustomerModel
            {
                Genders = data,
                Countries = dataC
            });

        }

        public IActionResult Save(CustomerModel customer)
        {

            _storeDbContext.Users.Add(new Models.Db.User
            {
               BirthDate = customer.BirthDate,
               Gender = customer.Gender,
               FullName = customer.FullName,
               Email= customer.Email,
               CountryCode = customer.CountryCode


            });

            _storeDbContext.SaveChanges();


           //**//   MySqlConnection connection = new MySqlConnection("user Id=root;Password=samy1;Host=localhost;Database=academy_net;");
            //  connection.Open();

            //   MySqlCommand command = new MySqlCommand();
            //   command.Connection = connection;

            //  command.CommandText = $"INSERT INTO `academy_net`.`users` (full_name, email, gender, date_of_birth, country_code, create_at) VALUES (?Name, ?Mail, ?Gender, ?Birth, ?Country, ?Creation);";

            // command.Parameters.Add("?Name", MySqlDbType.VarChar).Value = customer.FullName;
            // command.Parameters.Add("?Mail", MySqlDbType.VarChar).Value = customer.Email;
            // command.Parameters.Add("?Gender", MySqlDbType.VarChar).Value = customer.Gender;
            // command.Parameters.Add("?Birth", MySqlDbType.DateTime).Value = customer.BirthDate;
            //command.Parameters.Add("?Country", MySqlDbType.Int32).Value = customer.CountryCode;
            // command.Parameters.Add("?Creation", MySqlDbType.DateTime).Value = DateTime.Now;


            // command.CommandText = $"INSERT INTO `academy_net`.`users` (`full_name`, `email`, `gender`, `date_of_birth`, `country_code`, `create_at`) VALUES ('{customer.FullName}', '{customer.Email}', '{customer.Gender}', '{customer.BirthDate.ToString("yyyy-MM-dd HH:mm-ss")}', '{customer.CountryCode}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm-ss")}');";
            // command.ExecuteNonQuery();**/


            //Customer.Add(customer);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int customerId)
        {

            var p = _storeDbContext.Users.First(x => x.Id == customerId);
            CustomerModel selectedCustomer = new CustomerModel { 
                BirthDate = p.BirthDate,
                CountryCode = p.CountryCode,
                Email = p.Email,
                FullName = p.FullName,
                Id = p.Id
            } ;

            /*
             MySqlConnection connection = new MySqlConnection("user Id=root;Password=samy1;Host=localhost;Database=academy_net;");
             connection.Open();

             MySqlCommand command = connection.CreateCommand();

             command.CommandText = $"SELECT id, full_name, email, gender, date_of_birth, country_code, create_at FROM users where id = ?id;";

             command.Parameters.Add("?id", MySqlDbType.Int32).Value = customerId;

             MySqlDataReader reader = command.ExecuteReader();

             if (reader.Read())
             {
                 selectedCustomer = new CustomerModel
                 {
                     Id = reader.GetInt32(0),
                     FullName = reader.GetString(1),
                     Email = reader.GetString(2),
                     Gender = reader.GetString(3),
                     BirthDate = (DateTime)reader["date_of_birth"],
                     CountryCode = reader.GetInt32(5),


                 };
             }
             reader.Close();


             List<SelectListItem> data = new List<SelectListItem>();
             command = connection.CreateCommand();
             command.CommandText = $"SELECT gender_id, Description FROM gender;";
             reader = command.ExecuteReader();

             while (reader.Read())
             {

                 data.Add(new SelectListItem
                 {
                     Value = reader.GetChar(0).ToString(),
                     Text = reader.GetString(1),



                 });
             }
             reader.Close();


             List<SelectListItem> dataC = new List<SelectListItem>();
             command = connection.CreateCommand();
             command.CommandText = $"SELECT code, name FROM countries;";
             reader = command.ExecuteReader();

             while (reader.Read())
             {

                 dataC.Add(new SelectListItem
                 {
                     Value = reader.GetInt32(0).ToString(),
                     Text = reader.GetString(1),



                 });
             }*/

            List<SelectListItem> data = new List<SelectListItem>();

            var gender = _storeDbContext.Genders.ToList();

            foreach (var genders in gender)
            {
                data.Add(new SelectListItem
                {
                    Value = genders.Id,
                    Text = genders.Description,
                });
            }
            List<SelectListItem> dataC = new List<SelectListItem>();
            var countries = _storeDbContext.Countries.ToList();

            foreach (var country in countries)
            {
                dataC.Add(new SelectListItem
                {
                    Value = country.Code.ToString(),
                    Text = country.Name,
                });
            }

            if (selectedCustomer != null)
            {
                selectedCustomer.Genders = data;
                selectedCustomer.Countries = dataC;
            }




            return View(selectedCustomer);
        }
        public IActionResult EditSave(CustomerModel customer)
        {
            var user = _storeDbContext.Users.First(x => x.Id == customer.Id);

            user.Email = customer.Email;
            user.FullName = customer.FullName;
            user.CountryCode = customer.CountryCode;
            user.BirthDate = customer.BirthDate;
            user.Gender = customer.Gender;
            user.Id = customer.Id;

            _storeDbContext.Users.Update(user);
            _storeDbContext.SaveChanges();




            // MySqlConnection connection = new MySqlConnection("user Id=root;Password=samy1;Host=localhost;Database=academy_net;");
            //connection.Open();

            //MySqlCommand command = new MySqlCommand();
            //command.Connection = connection;

            //command.CommandText = $"UPDATE `academy_net`.`users` SET full_name=?Name, email=?Mail, gender=?Gender, date_of_birth=?Birth, country_code=?Country where id = ?id";

            //command.Parameters.Add("?Name", MySqlDbType.VarChar).Value = customer.FullName;
            //command.Parameters.Add("?Mail", MySqlDbType.VarChar).Value = customer.Email;
            //command.Parameters.Add("?Gender", MySqlDbType.VarChar).Value = customer.Gender;
            //command.Parameters.Add("?Birth", MySqlDbType.DateTime).Value = customer.BirthDate;
            //command.Parameters.Add("?Country", MySqlDbType.Int32).Value = customer.CountryCode;
            //command.Parameters.Add("?id", MySqlDbType.Int32).Value = customer.Id;


            // command.CommandText = $"INSERT INTO `academy_net`.`users` (`full_name`, `email`, `gender`, `date_of_birth`, `country_code`, `create_at`) VALUES ('{customer.FullName}', '{customer.Email}', '{customer.Gender}', '{customer.BirthDate.ToString("yyyy-MM-dd HH:mm-ss")}', '{customer.CountryCode}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm-ss")}');";
            //command.ExecuteNonQuery();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            var user = _storeDbContext.Users.First(x => x.Id == Id);

            _storeDbContext.Users.Remove(user);

            _storeDbContext.SaveChanges();

            // MySqlConnection connection = new MySqlConnection("user Id=root;Password=samy1;Host=localhost;Database=academy_net;");
            //connection.Open();

            //            MySqlCommand command = new MySqlCommand();
            //          command.Connection = connection;

            //        command.CommandText = $"DELETE FROM `academy_net`.`users` where id = ?id;";
            //      command.Parameters.Add("?id", MySqlDbType.Int32).Value = Id;



            //    command.ExecuteNonQuery();




            return RedirectToAction("Index");
        }

        public IActionResult Orders()
        {
            MySqlConnection connection = new MySqlConnection("user Id=root;Password=samy1;Host=localhost;Database=academy_net;");
            connection.Open();

            MySqlCommand command = connection.CreateCommand();

            command.CommandText = $"SELECT ord.id,ord.user_id,ord.status,ord.created_at,us.full_name FROM academy_net.users us inner join academy_net.orders ord on us.id = ord.user_id;";
            List<OrdersModel> data = new List<OrdersModel>();
            MySqlDataReader reader = command.ExecuteReader();
            

            while (reader.Read())
            {

                data.Add(new OrdersModel
                {
                    Id = reader.GetInt32(0),
                    UserId = reader.GetInt32(1),
                    Status = reader.GetString(2),
                    Create_at =reader.GetDateTime(3),
                    UserName = reader.GetString(4)
                    

                });

            }
            reader.Close();

            command.CommandText = $"SELECT id, name FROM academy_net.products";
            reader = command.ExecuteReader();
            List<SelectListItem> produts = new List<SelectListItem>();

            while (reader.Read())
            {

                produts.Add(new SelectListItem
                {
                    Value = reader.GetInt32(0).ToString(),
                    Text = reader.GetString(1),



                });
            }



            return View(new OrdersModel
            {
                Products = produts,
                OrderItems = OrderItems,
                Data = data

            });
            

        }

        
       

        public IActionResult OrderSave(OrdersModel order)
        {

            MySqlConnection connection = new MySqlConnection("user Id=root;Password=samy1;Host=localhost;Database=academy_net;");
            connection.Open();

            MySqlCommand command = connection.CreateCommand();

            command.CommandText = $"SELECT name FROM academy_net.products where id = ?id;";
            command.Parameters.Add("?id", MySqlDbType.Int32).Value = order.Product;

            MySqlDataReader reader = command.ExecuteReader();

            string product = null;

            if (reader.Read())
            {
                product = reader.GetString(0);
            }


            OrderItems.Add(new OrdersModel
            {
                Product = product,
                ProductQuanty = order.ProductQuanty
            });
            return RedirectToAction("Orders");


        }
        public IActionResult SaveOrder(OrdersModel order)
        {
            MySqlConnection connection = new MySqlConnection("user Id=root;Password=samy1;Host=localhost;Database=academy_net;");
            connection.Open();

            MySqlCommand command = connection.CreateCommand();

            command.CommandText = $"INSERT INTO `academy_net`.`orders` (user_id, status, created_at) VALUES ('3', 'Pagada', ?Creation);SELECT LAST_INSERT_ID()";

            command.Parameters.Add("3", MySqlDbType.Int32).Value = order.UserId;
            command.Parameters.Add("Pagada", MySqlDbType.VarChar).Value = order.Status;
            command.Parameters.Add("?Creation", MySqlDbType.DateTime).Value = DateTime.Now;

            int idO = 0;

            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                idO = reader.GetInt32(0);
            }
            reader.Close();
                
            int idProduct = 0;
            int quanty = 0;

            foreach (var i in OrderItems){
                command = connection.CreateCommand();
                command.CommandText = $"SELECT id FROM academy_net.products where name = ?name";
                command.Parameters.Add("?name", MySqlDbType.VarChar).Value = i.Product;

                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    idProduct = reader.GetInt32(0);
                }
                quanty = i.ProductQuanty;

                command.CommandText = $"INSERT INTO `academy_net`.`orders_items` (order_id, product_id, quanty) VALUES (?id, ?product_id, ?quanty);";

                command.Parameters.Add("?id", MySqlDbType.Int32).Value = idO;
                command.Parameters.Add("?product_id", MySqlDbType.Int32).Value = idProduct;
                command.Parameters.Add("?quanty", MySqlDbType.Int32).Value = quanty;

                reader.Close();
                command.ExecuteNonQuery();

            };
            OrderItems.Clear();



            return RedirectToAction("Orders");
        }
    }
}
