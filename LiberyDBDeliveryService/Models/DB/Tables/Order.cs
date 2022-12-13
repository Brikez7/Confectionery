using System.Configuration;
using System.Diagnostics;

namespace LibraryDatabaseCoffe.Models.DB.Tables
{
    public enum StatusOrder
    {
        error = -1,
        expectation = 0,
        success = 1
    }
    public class Order
    {
        public int? OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime DateOrder { get; set; }
        public long Total { get; set; } = 0;
        public StatusOrder StatusOrder { get; set; } = StatusOrder.error;
        public Order(int userId, StatusOrder statusOrder)
        {
            UserId = userId;
            StatusOrder = statusOrder;
        }
        //(System.Int32 order_id, System.Int32 user_id, System.DateTime order_date, System.Single total, System.Int16 status_order)
        public User? User { get; set; }
        public List<DescriptionOrder> DescriptionOrders { get; set; } = new List<DescriptionOrder>();
        public Order(int order_id, int user_id, DateTime order_date, float total, short status_order)
        {
            OrderId = order_id;
            UserId = user_id;
            DateOrder = order_date;
            Total = (long)total;
            StatusOrder = (StatusOrder)status_order;
        }
    }
}
