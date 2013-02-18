namespace ContactsSample.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            List<Contact> contacts = null;
            using (var ctx = new ContactsSampleDbEntities()) {
                contacts = (from c in ctx.Contacts
                            select c).ToList();
            }
            return View(contacts);
        }

        public ActionResult Insert(Contact contact) {
            string name = "foo";

            if (contact != null) {
                using (var ctx = new ContactsSampleDbEntities()) {
                    ctx.Contacts.Add(contact);
                    ctx.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

    }
}
