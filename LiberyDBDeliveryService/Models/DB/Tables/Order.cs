﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryDatabaseCoffe.Models.DB.Tables
{
    public enum StatusOrder 
    {
        error = -1,
        expectation = 0,
        success = 1,
    }
    public class Order
    {
        public int? OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime DateOrder { get; set; }
        public long Total { get; set; } = 0;
        public StatusOrder StatusOrder { get; set; } = StatusOrder.error;
        public Order(int userId, DateTime dateORder, long total)
        {
            UserId = userId;
            DateOrder = dateORder;
            Total = total;
        }
        public Order(int? orderId, int userId, DateTime dateOrder, long total)
        {
            OrderId = orderId;
            UserId = userId;
            DateOrder = dateOrder;
            Total = total;
        }

        public User? User { get; set; }
        public Order(int? orderId, int userId, DateTime dateOrder, long total, User? user) : this(orderId, userId, dateOrder, total)
        {
            User = user;
        }

        public Order(int userId, DateTime now)
        {
            UserId = userId;
            Now = now;
            Total = 0;
        }
    }
}
