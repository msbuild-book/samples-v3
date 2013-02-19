namespace ContactsSample.Controllers
{
    using ContactsSample.Models;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(GetContacts());
        }

        public ActionResult Insert(Contact contact) {
            string name = "foo";
            string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string insertStmt = @"Insert into Contact(FirstName,LastName) Values(@FirstName,@LastName)";

            if (contact != null) {
                using (var connection = new SqlConnection(conString))
                using (var cmd = new SqlCommand(insertStmt, connection)) {
                    connection.Open();

                    cmd.Parameters.Add("@FirstName", contact.FirstName);
                    cmd.Parameters.Add("@LastName", contact.LastName);

                    int result = cmd.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index");
        }

        private List<Contact> GetContacts() {
            List<Contact> contacts = new List<Contact>();

            string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string query = @"select id,FirstName,LastName from Contact";

            using (var connection = new SqlConnection(conString)) 
            using(var cmd = new SqlCommand(query,connection)){
                connection.Open();
                
                cmd.CommandType = System.Data.CommandType.Text;

                var reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    Contact contact = new Contact();
                    contact.Id = (int)reader["Id"];
                    
                    if(reader["FirstName"] != null)
                        contact.FirstName = (string)reader["FirstName"];

                    if (reader["LastName"] != null)
                        contact.LastName = (string)reader["LastName"];

                    contacts.Add(contact);
                }

                
            }

            return contacts;
        }
    }
}
