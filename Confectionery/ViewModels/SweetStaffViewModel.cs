namespace Confectionery.ViewModels
{
    public class SweetStaffViewModel
    {
        public int? StaffId { get; set; }
        public string StaffName { get; set; }
        public DateTime DateDeliver { get; set; }
        public float Weight { get; set; }
        public float Price { get; set; }
        public float Calories { get; set; }
        public string Classification { get; set; }
        public int? CompanyId { get; set; }

        public SweetStaffViewModel(int? staffId, string staffName, DateTime dateDeliver, float weight, float price, float calories, string classification, int? companyId)
        {
            StaffId = staffId;
            StaffName = staffName;
            DateDeliver = dateDeliver;
            Weight = weight;
            Price = price;
            Calories = calories;
            Classification = classification;
            CompanyId = companyId;
        }
    }
}
