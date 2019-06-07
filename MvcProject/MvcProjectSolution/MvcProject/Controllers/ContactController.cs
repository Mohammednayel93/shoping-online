using MvcProject.Bll;
using MvcProject.Models;
using System;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            TempData["editUser"] = string.Empty;
            TempData["ChangePassword"] = string.Empty;

            ViewBag.contact = TempData["Contact"];

            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactU contact)
        {
            if (Session["CurrentUser"] != null)
            {
                Contact_Bll contact_Bll = new Contact_Bll();
                contact.User_Id = Convert.ToInt32((Session["CurrentUser"] as User).Id);
                contact_Bll.AddContact(contact);
                TempData["Contact"] = "Message Sent Successfully";

            }
            else
            {
                TempData["Contact"] = "Login First";
            }
            return RedirectToAction("Index");
        }
    }
}