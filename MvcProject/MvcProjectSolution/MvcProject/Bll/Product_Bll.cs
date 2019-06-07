using MvcProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcProject.Bll
{
    public class Product_Bll
    {
        Model1 db = new Model1();
        public List<Product> GetAllProducts()
        {
            var result = db.Products.OrderByDescending(s => s.Id).ToList();
            return result;
        }
        public Product GetProductById(int id)
        {
            var result = db.Products.Find(id);
            return result;
        }
        public void EditProduct(Product product)
        {
            Product productDb = db.Products.Find(product.Id);
            productDb.Name = product.Name;
            productDb.Description = product.Description;
            productDb.Price = product.Price;
            productDb.Category_Id = product.Category_Id;
            productDb.Image = product.Image;
            db.SaveChanges();

        }
        public void AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }
    }

}