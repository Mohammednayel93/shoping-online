using MvcProject.Bll;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            TempData["editUser"] = string.Empty;
            TempData["ChangePassword"] = string.Empty;
            TempData["Contact"] = string.Empty;
            Product_Bll bll = new Product_Bll();
            var result = bll.GetAllProducts();
            return View(result);
        }
    }
}