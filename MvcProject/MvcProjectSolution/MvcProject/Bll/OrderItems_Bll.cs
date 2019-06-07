using MvcProject.Models;

namespace MvcProject.Bll
{
    public class OrderItems_Bll
    {
        Model1 db = new Model1();
        public void AddOrderItems(OrderItem orderItem)
        {
            db.OrderItems.Add(orderItem);
            db.SaveChanges();
        }
    }
}