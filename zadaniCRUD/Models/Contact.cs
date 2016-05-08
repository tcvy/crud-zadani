using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zadaniCRUD.Models
{
    public class Contact
    {
        public int ID { get; set; }
        public int AccountID  { get; set; }
        [RegularExpression("[a-zA-Z]*", ErrorMessage = "Povolena pouze pismena")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Toto pole je povinne")]
        [RegularExpression("[a-zA-Z]*", ErrorMessage = "Povolena pouze pismena")]
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Neplatny email")]
        public string Email { get; set; }

        public virtual Account Account { get; set; }
    

    }
}