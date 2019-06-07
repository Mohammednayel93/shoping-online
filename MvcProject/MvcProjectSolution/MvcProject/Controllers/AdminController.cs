using MvcProject.Bll;
using MvcProject.Models;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            Product_Bll bll = new Product_Bll();
            var result = bll.GetAllProducts();
            return View(result);
        }
        public ActionResult Accept(int id)
        {
            Order_Bll order_Bll = new Order_Bll();
            order_Bll.AcceptOrder(id);
            return RedirectToAction("Orders");
        }
        public ActionResult Reject(int id)
        {
            Order_Bll order_Bll = new Order_Bll();
            order_Bll.RejectOrder(id);
            return RedirectToAction("Orders");
        }
        public ActionResult Users()
        {
            User_Bll bll = new User_Bll();
            var result = bll.GetAllUsers();
            ViewBag.userlist = result;
            return View();
        }
        public ActionResult Block(int id)
        {
            User_Bll user_Bll = new User_Bll();
            user_Bll.BlockUser(id);
            return RedirectToAction("Users");
        }
        public ActionResult AcceptUser(int id)
        {
            User_Bll user_Bll = new User_Bll();
            user_Bll.AcceptUser(id);
            return RedirectToAction("Users");
        }

        public ActionResult EditProduct(int id)
        {
            Product_Bll product_Bll = new Product_Bll();

            var result = product_Bll.GetProductById(id);
            Category_Bll category_Bll = new Category_Bll();
            var categoryList = category_Bll.GetAllCategories();
            SelectList items = new SelectList(categoryList, "Id", "Name");
            ViewBag.category = items;
            return PartialView(result);
        }
        [HttpPost]
        public ActionResult EditProduct(Product product, HttpPostedFileBase ImagePath)
        {

            Product_Bll product_Bll = new Product_Bll();
            Product oldproduct = product_Bll.GetProductById(product.Id);
            if (ImagePath != null)
            {
                ImagePath.SaveAs(Server.MapPath("~/images/" + ImagePath.FileName));
                product.Image = "~/images/" + ImagePath.FileName;
            }
            else
            {
                product.Image = oldproduct.Image;
            }
            product_Bll.EditProduct(product);

            return RedirectToAction("Index");
        }
        public ActionResult AddProduct()
        {
            Category_Bll category_Bll = new Category_Bll();
            var categoryList = category_Bll.GetAllCategories();
            SelectList items = new SelectList(categoryList, "Id", "Name");
            ViewBag.category = items;
            return PartialView();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product, HttpPostedFileBase ImagePath)
        {

            Product_Bll product_Bll = new Product_Bll();

            if (ImagePath != null)
            {
                ImagePath.SaveAs(Server.MapPath("~/images/" + ImagePath.FileName));
                product.Image = "~/images/" + ImagePath.FileName;
            }
            else
            {
                product.Image = "~/images/item-cart-01.jpg";
            }
            product_Bll.AddProduct(product);

            return RedirectToAction("Index");
        }
        public ActionResult Orders()
        {
            Order_Bll order_Bll = new Order_Bll();
            var orderlist = order_Bll.GetAllOrder();
            ViewBag.OrderList = orderlist;
            return View();
        }
    }
}