using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zadaniCRUD.Models
{
    public class Account
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Toto pole je povinne")]
        [RegularExpression("[a-zA-Z0-9]*", ErrorMessage = "Povolena pouze pismena")]
        public string Name { get; set; }

        public virtual IList<Contact> Kontakty { get; set; }

    }
}