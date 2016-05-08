using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using zadaniCRUD.Models;


namespace zadaniCRUD.DAL
{
    public class TestContext : DbContext
    {
        public TestContext() : base("testcontext")
        { }

        public DbSet<Account> Zakaznici { get; set; }
        public DbSet<Contact> Kontakty { get; set; }

    
    }
}