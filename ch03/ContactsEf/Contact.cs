namespace ContactsEf {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Contact {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}