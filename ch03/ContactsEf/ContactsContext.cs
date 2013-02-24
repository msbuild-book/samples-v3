namespace ContactsEf {
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;

    public class ContactsContext : DbContext {
        public DbSet<Contact> Contacts { get; set; }
    }
}