namespace ContactsEf.Controllers {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class HomeController : Controller {
        public ActionResult Index() {
            List<Contact> contacts = null;
            using (var ctx = new ContactsContext()) {
                contacts = (from c in ctx.Contacts
                            select c).ToList();
            }

            if (contacts == null) { contacts = new List<Contact>(); }

            return View(contacts);
        }

        public ActionResult AddContact(Contact contact) {
            if (contact != null) {
                using (var ctx = new ContactsContext()) {
                    ctx.Contacts.Add(contact);
                    ctx.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
