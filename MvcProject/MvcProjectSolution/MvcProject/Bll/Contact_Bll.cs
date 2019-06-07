using MvcProject.Models;

namespace MvcProject.Bll
{
    public class Contact_Bll
    {
        Model1 db = new Model1();
        public void AddContact(ContactU contact)
        {
            db.ContactUs.Add(contact);
            db.SaveChanges();
        }
    }
}