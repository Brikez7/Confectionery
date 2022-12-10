﻿namespace LibraryDatabaseCoffe.Models.DB.Tables
{
    public enum StatusUser 
    {
        Admin,
        Manager,
        User
    }
    public class User 
    {
        public int? UserId { get; set; }
        public string NameUser { get; set; }
        public string EmailUser { get; set; }
        public string Password { get; set; }
        public StatusUser Status { get; set; } = StatusUser.User;
        public float TotalSpent { get; set; } = 0;
        public User(int? user_id, string user_name, string email, string password, StatusUser status)
        {
            UserId = user_id;
            NameUser = user_name;
            EmailUser = email;
            Password = password;
            Status = status;
        }
        //(System.Int32 user_id, System.String user_name, System.String email, System.String password, System.Int16 status, System.Single total)
        public User(int user_id, string user_name, string email, string password, short status, float total)
        {
            UserId = user_id;
            NameUser = user_name;
            EmailUser = email;
            Password = password;
            Status = (StatusUser)status;
            TotalSpent = total;
        }
        public User(int? user_id, string user_name, string email, string password, StatusUser status, float total)
        {
            UserId = user_id;
            NameUser = user_name;
            EmailUser = email;
            Password = password;
            Status = status;
            TotalSpent = total;
        }
        public int OrderId { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public User(int? user_id, string user_name, string email, string password, StatusUser status, float total, int orderId, List<Order> orders) : this(user_id, user_name, email, password, status, total)
        {
            OrderId = orderId;
            Orders = orders;
        }

        public User(string user_name, string email, string password)
        {
            NameUser = user_name;
            EmailUser = email;
            Password = password;
        }
    }
}
