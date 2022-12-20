using LibraryDatabaseCoffe.Models.DB.Tables;

namespace Confectionery.ViewModels
{
    public class CompanyControlViewModel
    {
        public CompanyViewModel? NewCompany { get; set; }
        public List<CompanyViewModel> CompanyList { get; set; } = new List<CompanyViewModel>();

        public CompanyControlViewModel(List<CompanyViewModel> companyList)
        {
            CompanyList = companyList;
        }

        public CompanyControlViewModel()
        {
        }
    }
}
