using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using zadaniCRUD.DAL;
using zadaniCRUD.Models;

namespace zadaniCRUD.Controllers
{
    public class AccountsController : Controller
    {
        private TestContext db = new TestContext();

        // GET: Accounts
        public ActionResult list()
        {
            return View(db.Zakaznici.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Form(int? id,[Bind(Include ="Name,Kontakty")] Account account)
        {
            bool pridanKontakt = true;
            if (account.Kontakty.Last().LastName == null && (account.Kontakty.Last().FirstName == null && account.Kontakty.Last().Email == null))
            {                  
                account.Kontakty.RemoveAt(account.Kontakty.Count - 1);
                ModelState.Clear();
                TryValidateModel(account);
                pridanKontakt = false;
            }

            if (id == null || id==0)
            {               
                if (ModelState.IsValid)
                {
                    db.Zakaznici.Add(account);
                    db.SaveChanges();
                    return RedirectToAction("list");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {                   
                    for (int i = 0; i < account.Kontakty.Count; i++)
                    {
                        if (i != (account.Kontakty.Count-1) || !pridanKontakt)
                        {
                            db.Entry(account.Kontakty[i]).State = EntityState.Modified;
                        }
                    }

                    if (pridanKontakt)
                    {
                        account.Kontakty.Last().AccountID = (int)id;
                        db.Kontakty.Add(account.Kontakty.Last());
                    }
                    account.ID = (int)id;
                    db.Entry(account).State = EntityState.Modified;

                    db.SaveChanges();

                    return RedirectToAction("list");
                }
            }
            return View(account);
        }
             
        // GET: Accounts/Form/5
        public ActionResult Form(int? id)
        {
            if (id == null)
            {
                var prazdnyAccount = new Account {Name = null, Kontakty= new List<Contact>()  };
                 prazdnyAccount.Kontakty.Add(new Contact());
                 return View(prazdnyAccount);
                
            }
            Account account = db.Zakaznici
                .Find(id);
            
            
            
            if (account == null)
            {
                return HttpNotFound();
            }
            account.Kontakty.Add(new Contact());
            return View(account);
        }  

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
