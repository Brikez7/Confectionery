using System.ComponentModel.DataAnnotations;

namespace LibraryDatabaseCoffe.Models.DB.Tables
{
    public class Company
    {
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Owner { get; set; }
        public string Telephone { get; set; }
        public long BankingAccount { get; set; }
        public Company(string company_name, string owner, string telephone, long banking_account)
        {
            CompanyName = company_name;
            Owner = owner;
            Telephone = telephone;
            BankingAccount = banking_account;
        }
        public Company(int? companyId, string company_name, string owner, string telephone, long banking_account)
        {
            CompanyId = companyId;
            CompanyName = company_name;
            Owner = owner;
            Telephone = telephone;
            BankingAccount = banking_account;
        }

        public List<SweetStaff> Staffs { get; set; } = new List<SweetStaff>();
        public Company(int? companyId, string company_name, string owner, string telephone, long banking_account, List<SweetStaff> staffs) : this(companyId, company_name, owner, telephone, banking_account)
        {
            Staffs = staffs;
        }
    }
}
