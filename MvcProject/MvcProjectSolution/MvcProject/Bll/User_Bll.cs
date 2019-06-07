using MvcProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcProject.Bll
{
    public class User_Bll
    {
        Model1 db = new Model1();

        public User Login(string email, string password)
        {

            var result = db.Users.Any(s => s.Email == email && s.Password == password);
            if (result)
            {
                var current = db.Users.Where(s => s.Email == email && s.Password == password).FirstOrDefault();

                return current;
            }
            else
            {

                return null;
            }

        }
        public void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
        public User GetLastUserAdded()
        {
            var currentUser = (from s in db.Users
                               orderby s.Id descending
                               select s).FirstOrDefault();
            return currentUser;
        }
        public List<User> GetAllUsers()
        {
            var currentUser = (from s in db.Users
                               orderby s.Id
                               select s).ToList();
            return currentUser;
        }
        public User GetUserById(int id)
        {
            var currentUser = (from s in db.Users
                               where s.Id == id
                               select s).FirstOrDefault();
            return currentUser;
        }

        public void BlockUser(int id)
        {


            //try
            //{
            var result = db.Users.Find(id);
            result.Active = false;
            db.SaveChanges();
            //}
            //catch (DbEntityValidationException e)
            //{
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage);
            //        }
            //    }
            //    throw;
            //}



        }
        public void AcceptUser(int id)
        {
            var result = db.Users.Find(id);
            result.Active = true;
            db.SaveChanges();
        }

    }
}