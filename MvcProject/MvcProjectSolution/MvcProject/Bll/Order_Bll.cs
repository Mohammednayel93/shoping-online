using MvcProject.Models;
using System.Collections.Generic;
using System.Linq;
namespace MvcProject.Bll
{
    public class Order_Bll
    {
        Model1 db = new Model1();
        public void AddOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }
        public int GetLastOrderId()
        {
            var order = (from s in db.Orders
                         orderby s.Id descending
                         select s).FirstOrDefault();

            return order.Id;
        }
        public List<Order> GetAllOrderByUserId(int id)
        {
            //int count = 1;
            var order = (from s in db.Orders
                         where s.User_Id == id
                         orderby s.Id
                         select s).ToList();
            ////var list = from s in order
            ////           select new
            ////           {
            ////               id = count++,
            ////               OrderId = id,
            ////               UserName = s.User.Name,
            ////               ItemNum = s.OrderItems.Count,
            ////               OrderDate = s.Date
            ////           };
            //return (List<Order>)list;
            return order;
        }
        public List<OrderItem> GetAllOrderItemByOredrId(int id)
        {

            var order = (from s in db.OrderItems
                         where s.Order_Id == id
                         orderby s.Id
                         select s).ToList();
            return order;
        }
        public void AcceptOrder(int id)
        {
            var result = db.Orders.Find(id);
            result.Active = true;
            db.SaveChanges();
        }
        public void RejectOrder(int id)
        {
            var result = db.Orders.Find(id);
            result.Active = false;
            db.SaveChanges();
        }

        public List<Order> GetAllOrder()
        {
            //int count = 1;
            var order = (from s in db.Orders
                         where s.Active == null
                         orderby s.Id descending
                         select s).ToList();

            return order;
        }
    }
}