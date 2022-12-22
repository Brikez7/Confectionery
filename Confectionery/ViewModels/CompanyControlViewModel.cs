using LibraryDatabaseCoffe.Models.DB.Tables;

namespace Confectionery.ViewModels
{
    public class CompanyControlViewModel
    {
        public CompanyViewModel? NewCompany { get; set; }
        public List<CompanyViewModel> CompanyList { get; set; } = new List<CompanyViewModel>();
        public AccountViewModel? User { get; set; }

        public CompanyControlViewModel()
        {
        }

        public CompanyControlViewModel(List<CompanyViewModel> companyList, AccountViewModel user)
        {
            CompanyList = companyList;
            User = user;
        }
    }
}
