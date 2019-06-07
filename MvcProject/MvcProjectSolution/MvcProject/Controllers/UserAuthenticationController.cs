using MvcProject.Bll;
using MvcProject.Models;
using MvcProject.ViewModel;
using System.Linq;
using System.Web.Mvc;
namespace MvcProject.Controllers
{
    public class UserAuthenticationController : Controller
    {
        // GET: UserAuthentication
        [HttpGet]
        public PartialViewResult Login() => PartialView();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user_Info)
        {


            User_Bll securityUser_BLL = new User_Bll();

            var current = securityUser_BLL.Login(user_Info.Email, user_Info.Password);
            if (current != null)
            {

                if (current.Role_Id == 1)
                {
                    if (current.Active == false)
                    {
                        TempData["LoginError"] = "You are Blocked";
                        return Redirect("~/Home/Index");
                    }
                    else
                    {
                        //Success
                        Session["CurrentUser"] = current;
                        TempData["LoginError"] = string.Empty;
                        return Redirect("/");
                    }

                }
                else
                {
                    return Redirect("/Admin/Index");
                }

            }
            else
            {
                TempData["LoginError"] = "Wrong Password or Email";
                return Redirect("~/Home/Index");
            }

        }
        public ActionResult Logout()
        {
            TempData["profile"] = string.Empty;
            TempData["profile"] = null;
            Session["CurrentUser"] = null;
            Session["cart"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(User_VM user_vm)
        {


            //var currentObj = AutoMapper.Mapper.Map<User_VM, User>(user_vm);
            //AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<User_VM, User>());
            User user = new User();
            user.Name = user_vm.Name;
            user.Email = user_vm.Email;
            user.Password = user_vm.Password;
            if (user_vm.ImagePath != null)
            {
                user_vm.ImagePath.SaveAs(Server.MapPath("~/images/" + user_vm.ImagePath.FileName));
                user.Image = "~/images/" + user_vm.ImagePath.FileName;
            }
            else
            {
                user.Image = "~/images/default.jpg";
            }

            user.Address = user_vm.Address;
            user.Role_Id = 1;
            user.Active = true;
            user.Gender = user_vm.Gender;

            User_Bll bll = new User_Bll();
            bll.AddUser(user);
            var currentuser = bll.GetLastUserAdded();
            Session["CurrentUser"] = currentuser;
            TempData["rigster"] = "Registration Successfully";
            return Redirect("/");
        }
        [HttpGet]
        public new ActionResult Profile()
        {

            User_Bll bll = new User_Bll();
            if (Session["CurrentUser"] != null)
            {
                var CurrentUser = Session["CurrentUser"] as User;
                var user = bll.GetUserById(CurrentUser.Id);
                TempData["profile"] = string.Empty;
                TempData["profile"] = null;
                ViewBag.changePassword = TempData["ChangePassword"];
                ViewBag.editUser = TempData["editUser"];
                Order_Bll order_Bll = new Order_Bll();
                var orderlist = order_Bll.GetAllOrderByUserId(CurrentUser.Id);
                ViewBag.OrderList = orderlist;
                return View(user);
            }
            else
            {
                ViewBag.editUser = string.Empty;
                TempData["profile"] = "you don't have privilage to show this page";
                return RedirectToAction("Index", "Home");
            }

        }
        public ActionResult OrderItem(int id)
        {
            Order_Bll order_Bll = new Order_Bll();
            var List = order_Bll.GetAllOrderItemByOredrId(id);
            return PartialView(List);

        }
        public ActionResult EditUser()
        {
            User_Bll bll = new User_Bll();
            var CurrentUser = Session["CurrentUser"] as User;

            var user = bll.GetUserById(CurrentUser.Id);
            User_VM user_VM = new User_VM();
            user_VM.Id = user.Id;
            user_VM.Name = user.Name;
            user_VM.Email = user.Email;
            user_VM.Password = user.Password;
            user_VM.Image = user.Image;
            user_VM.Address = user.Address;
            user_VM.Gender = user.Gender;
            ViewBag.TitlePage = "Edit Profile";
            return PartialView(user_VM);
        }
        [HttpPost]
        public ActionResult EditUser(User_VM user_vm)
        {
            using (Model1 db = new Model1())
            {
                User_Bll bll = new User_Bll();
                var CurrentUser = Session["CurrentUser"] as User;
                User user = db.Users.FirstOrDefault(m => m.Id == CurrentUser.Id);
                user.Name = user_vm.Name;
                user.Email = user_vm.Email;
                user.Password = user.Password;
                if (user_vm.ImagePath != null)
                {
                    user_vm.ImagePath.SaveAs(Server.MapPath("~/images/" + user_vm.ImagePath.FileName));
                    user.Image = "~/images/" + user_vm.ImagePath.FileName;
                }
                else
                {
                    user.Image = "~/images/default.jpg";
                }
                user.Address = user_vm.Address;
                user.Role_Id = 1;
                user.Active = true;
                user.Gender = user_vm.Gender;
                db.SaveChanges();
                TempData["ChangePassword"] = string.Empty;
                TempData["editUser"] = "Updated Successfully";
                return RedirectToAction("Profile");
            }

        }

        public ActionResult ChangePassword()
        {
            //User_Bll bll = new User_Bll();
            //var CurrentUser = Session["CurrentUser"] as User;

            //var user = bll.GetUserById(CurrentUser.Id);
            //User_VM user_VM = new User_VM();
            //user_VM.Id = user.Id;
            //user_VM.Name = user.Name;
            //user_VM.Email = user.Email;
            //user_VM.Password = user.Password;
            //user_VM.Image = user.Image;
            //user_VM.Address = user.Address;
            //user_VM.Gender = user.Gender;
            ViewBag.TitlePage = "Change Password";
            return PartialView();
        }
        [HttpPost]
        public ActionResult ChangePassword(User_VM user_vm)
        {
            User_Bll bll = new User_Bll();
            var CurrentUser = Session["CurrentUser"] as User;

            var user = bll.GetUserById(CurrentUser.Id);
            if (user_vm.OldPassword != user.Password)
            {
                TempData["editUser"] = string.Empty;
                TempData["ChangePassword"] = "Invaild Password";
                return RedirectToAction("Profile");
            }
            else
            {
                using (Model1 db = new Model1())
                {
                    User userObject = db.Users.FirstOrDefault(m => m.Id == CurrentUser.Id);
                    userObject.Password = user_vm.NewPassword;
                    db.SaveChanges();
                }
                TempData["editUser"] = string.Empty;
                TempData["ChangePassword"] = "Password Changed Successfully";
                return RedirectToAction("Profile");
            }
        }
    }
}
