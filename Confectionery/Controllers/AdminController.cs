using Confectionery.Filters;
using Confectionery.Mapers;
using Confectionery.ViewModels;
using LibraryDatabaseCoffe.Models.DB.Request.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Confectionery.Controllers
{
    [TypeFilter(typeof(FilterAdmin))]
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public AdminController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public async Task<IActionResult> PanelCompany()
        {
            var CompanyRepository = HttpContext.RequestServices.GetService<CompanyRepository>();
            var mapper = HttpContext.RequestServices.GetService<Mapsters>();

            var companiesDB = await CompanyRepository.GetAllAsync();
            List<CompanyViewModel> CompanyList = mapper.MapToViewCompanies(companiesDB.ToList());
            CompanyControlViewModel companyControlView = new CompanyControlViewModel(CompanyList);

            return View(companyControlView);
        }
        public async Task<IActionResult> AddCompany(CompanyControlViewModel companyControlView) 
        {
            var CompanyRepository = HttpContext.RequestServices.GetService<CompanyRepository>();
            var mapper = HttpContext.RequestServices.GetService<Mapsters>();

            if (ModelState.IsValid)
            {
                var company = mapper.MapToCompany(companyControlView.NewCompany);
                await CompanyRepository.AddAsync(company);
            }
            else 
            {
                return View("PanelCompany", companyControlView);
            }

            var companiesDB = await CompanyRepository.GetAllAsync();
            List<CompanyViewModel> CompanyList = mapper.MapToViewCompanies(companiesDB.ToList());
            CompanyControlViewModel updateCompanyControlView = new CompanyControlViewModel(CompanyList);

            return Json(updateCompanyControlView);
        }
        [Route("/DeleteCompany/{IdDeleteCompany:int}")]
        public async Task<IActionResult> DeleteCompany(int IdDeleteCompany)
        {
            var CompanyRepository = HttpContext.RequestServices.GetService<CompanyRepository>();
            var mapper = HttpContext.RequestServices.GetService<Mapsters>();

            await CompanyRepository.DeleteAsync(IdDeleteCompany);

            var companiesDB = await CompanyRepository.GetAllAsync();
            List<CompanyViewModel> CompanyList = mapper.MapToViewCompanies(companiesDB.ToList());
            CompanyControlViewModel updateCompanyControlView = new CompanyControlViewModel(CompanyList);

            return View("PanelCompany", updateCompanyControlView);
        }
        public async Task<IActionResult> ChangeCompany(CompanyControlViewModel companyControlView)
        {
            var CompanyRepository = HttpContext.RequestServices.GetService<CompanyRepository>();
            var mapper = HttpContext.RequestServices.GetService<Mapsters>();

            if (ModelState.IsValid)
            {
                var company = mapper.MapToCompany(companyControlView.NewCompany);

                await CompanyRepository.UpdateAsync((int)company.CompanyId, company);
            }
            else 
            {
                var companiesOld = await CompanyRepository.GetAllAsync();
                List<CompanyViewModel> CompanyListOld = mapper.MapToViewCompanies(companiesOld.ToList());
                CompanyControlViewModel OldCompanyControlView = new CompanyControlViewModel(CompanyListOld);
                return View("PanelCompany", OldCompanyControlView);
            }

            var companiesDB = await CompanyRepository.GetAllAsync();
            List<CompanyViewModel> CompanyList = mapper.MapToViewCompanies(companiesDB.ToList());

            CompanyControlViewModel updateCompanyControlView = new CompanyControlViewModel(CompanyList);

            return View("PanelCompany", updateCompanyControlView);
        }
        public async Task<IActionResult> PanelSweetStaff()
        {
            var SweetStaffRepository = HttpContext.RequestServices.GetService<SweetStaffRepository>();
            var mapper = HttpContext.RequestServices.GetService<Mapsters>();

            var SweetStaffsDB = await SweetStaffRepository.GetAllAsync();
            List<SweetStaffViewModel> SweetStaffList = mapper.MapToViewSweetStaffs(SweetStaffsDB.ToList());
            SweetStaffControlViewModel SweetStaffControlView = new SweetStaffControlViewModel(SweetStaffList);

            return View(SweetStaffControlView);
        }
    }
}
