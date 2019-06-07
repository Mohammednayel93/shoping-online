using MvcProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcProject.Bll
{
    public class Category_Bll
    {
        Model1 db = new Model1();
        public List<Category> GetAllCategories()
        {
            var result = db.Categories.ToList();
            return result;
        }
    }
}