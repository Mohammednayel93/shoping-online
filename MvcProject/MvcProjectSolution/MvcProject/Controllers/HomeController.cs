using MvcProject.Bll;
using MvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TempData["Contact"] = string.Empty;
            ViewBag.order = TempData["order"];
            ViewBag.errorLogin = TempData["LoginError"];
            ViewBag.register = TempData["rigster"];
            ViewBag.profile = TempData["profile"];
            TempData["editUser"] = string.Empty;
            TempData["ChangePassword"] = string.Empty;
            Product_Bll bll = new Product_Bll();
            var result = bll.GetAllProducts();
            Category_Bll category_bll = new Category_Bll();
            var categoryList = category_bll.GetAllCategories();
            ViewBag.categoryList = categoryList;
            return View(result);
        }
        public ActionResult GetAllProduct()
        {
            Product_Bll bll = new Product_Bll();
            var result = bll.GetAllProducts();
            return PartialView(result);
        }
        public ActionResult GetProductById(int id)
        {
            Product_Bll bll = new Product_Bll();
            var result = bll.GetAllProducts().Where(s => s.Category_Id == id);
            return PartialView(result);
        }
        public ActionResult AddToCart(int id)
        {
            Product_Bll bll = new Product_Bll();
            if (Session["CurrentUser"] != null)
            {


                if (Session["cart"] == null)
                {
                    List<ItemCart> list = new List<ItemCart>();
                    list.Add(new ItemCart { Product = bll.GetProductById(id), Quantity = 1 });
                    Session["cart"] = list;

                }
                else
                {
                    List<ItemCart> list = Session["cart"] as List<ItemCart>;
                    int index = isExist(id);
                    if (index != -1)
                    {
                        list[index].Quantity++;
                    }
                    else
                    {
                        list.Add(new ItemCart { Product = bll.GetProductById(id), Quantity = 1 });

                    }
                    Session["cart"] = list;
                }
            }
            return RedirectToAction("Index");
        }
        public int isExist(int id)
        {
            List<ItemCart> cart = (List<ItemCart>)Session["cart"];
            if (cart != null)
            {
                for (int i = 0; i < cart.Count; i++)
                    if (cart[i].Product.Id.Equals(id))
                        return i;
                return -1;

            }
            else
            {
                return -1;
            }

        }
        public ActionResult Cart()
        {
            if (Session["CurrentUser"] != null)
            {
                List<ItemCart> itemCarts = Session["cart"] as List<ItemCart>;
                return View(itemCarts);
            }
            return View();

        }
        public ActionResult CartMenu()
        {
            if (Session["CurrentUser"] != null)
            {
                List<ItemCart> itemCarts = Session["cart"] as List<ItemCart>;
                return PartialView(itemCarts);
            }
            return View();

        }
        public ActionResult ApplyCart()
        {
            //Add Order
            Order_Bll order_bll = new Order_Bll();
            Order order = new Order();
            order.User_Id = Convert.ToInt32((Session["CurrentUser"] as User).Id);
            order.Date = DateTime.Now;
            order.Active = null;
            order_bll.AddOrder(order);
            // Add Item Order
            OrderItems_Bll orderItems_Bll = new OrderItems_Bll();
            List<ItemCart> itemCarts = Session["cart"] as List<ItemCart>;
            foreach (var item in itemCarts)
            {
                OrderItem orderItem = new OrderItem();
                orderItem.Order_Id = order_bll.GetLastOrderId();
                orderItem.Product_Id = item.Product.Id;
                orderItem.Quantity = item.Quantity;
                orderItems_Bll.AddOrderItems(orderItem);
            }
            Session["cart"] = null;
            TempData["order"] = "Order Added Successfully, Wait Response...";
            return RedirectToAction("Index");
        }
        public ActionResult Remove(int id)
        {
            List<ItemCart> cart = (List<ItemCart>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Cart");
        }
        public ActionResult notification()
        {
            if (Session["cart"] != null)
            {
                List<ItemCart> cart = (List<ItemCart>)Session["cart"];
                return Json(new { count = cart.Count }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { count = 0 }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}