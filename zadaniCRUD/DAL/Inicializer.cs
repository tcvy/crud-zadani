using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using zadaniCRUD.Models;

namespace zadaniCRUD.DAL
{
    public class Inicializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TestContext>
    {
        protected override void Seed(TestContext context)
        {
            var ac = new List<Account>
            {
                new Account { Name = "zakaznik1"},
                new Account { Name = "zakaznik2"}
            };
            ac.ForEach(a => context.Zakaznici.Add(a));

            var co = new List<Contact>
            {
                new Contact {FirstName="pp", LastName="sv", Email="pp.sv@gmail.com", AccountID=1 },
                new Contact {FirstName="jf", LastName="gh", Email="jf.gh@gmail.com", AccountID=1 },
                new Contact {FirstName="cg", LastName="hl", Email="cg.hl@gmail.com", AccountID=2 },
                new Contact {FirstName="cf", LastName="hl", Email="cf.hl@gmail.com", AccountID=2 },
            };
            co.ForEach(c => context.Kontakty.Add(c));

            context.SaveChanges();
        }
    }
}