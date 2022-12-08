using System.ComponentModel.DataAnnotations;
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
        //(System.Int32 staff_id, System.String staff_name, System.DateTime date_receipt, System.Int32 company_id, System.Single weight, System.String classification, System.Single price, System.Single calories)
        //(System.Single calories, System.Int32 company_id, System.String company_name, System.String owner, System.String telephone, System.Int64 banking_account)
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
        public SweetStaff(int staff_id, string staff_name, DateTime date_receipt, Single weight, Single price, Single calories, string classification)
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
        public SweetStaff(int? staff_id, string staff_name, DateTime date_receipt, int? company_id, float weight, string classification, float price, float calories) : this(staff_id, staff_name, date_receipt, weight, price, calories, classification)
        {
            CompanyId = company_id;
        }

        public SweetStaff(int? staff_id, string staff_name, DateTime date_receipt, float weight, float price, float calories, string classification, int? company_id, Company? company) : this(staff_id, staff_name, date_receipt, weight, price, calories, classification)
        {
            CompanyId = company_id;
            Company = company;
        }
    }
}
