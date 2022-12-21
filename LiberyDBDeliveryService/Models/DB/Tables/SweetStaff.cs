﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryDatabaseCoffe.Models.DB.Tables
{
    public class SweetStaff
    {
        public int? StaffId { get; set; }
        public string StaffName { get; set; }
        public DateTime DateDeliver { get; set; }
        public float Weight { get; set; }
        public float Price { get; set; }
        public float Calories { get; set; }
        public string Classification { get; set; }
        
        public SweetStaff(int? staff_id, string staff_name, DateTime date_receipt, float weight, float price, float calories, string classification,int? company_id)
        {
            StaffId = staff_id;
            StaffName = staff_name;
            DateDeliver = date_receipt;
            Weight = weight;
            Price = price;
            Calories = calories;
            Classification = classification;
            CompanyId = company_id;
        }
        public SweetStaff(int? staff_id, string staff_name, DateTime date_receipt, float weight, float price, float calories, string classification)
        {
            StaffId = staff_id;
            StaffName = staff_name;
            DateDeliver = date_receipt;
            Weight = weight;
            Price = price;
            Calories = calories;
            Classification = classification;
        }

        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        public SweetStaff(int? staff_id, string staff_name, DateTime date_receipt, float weight, float price, float calories, string classification, int? company_id, Company? company) : this(staff_id, staff_name, date_receipt, weight, price, calories, classification)
        {
            CompanyId = company_id;
            Company = company;
        }
    }
}
