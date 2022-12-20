using Confectionery.Filters;
using Confectionery.Mapers;
using Confectionery.ViewModels;
using LibraryDatabaseCoffe.Models.DB.Request.Repositories;
using LibraryDatabaseCoffe.Models.DB.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
                CompanyRepository.AddAsync(company);
            }
            else 
            {
                return View("PanelCompany", companyControlView);
            }

            var companiesDB = await CompanyRepository.GetAllAsync();
            List<CompanyViewModel> CompanyList = mapper.MapToViewCompanies(companiesDB.ToList());
            CompanyControlViewModel updateCompanyControlView = new CompanyControlViewModel(CompanyList);

            return View("PanelCompany", updateCompanyControlView);
        }
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var CompanyRepository = HttpContext.RequestServices.GetService<CompanyRepository>();
            var mapper = HttpContext.RequestServices.GetService<Mapsters>();

            CompanyRepository.DeleteAsync(id);

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

                CompanyRepository.UpdateAsync((int)company.CompanyId, company);
            }
            else 
            {
                return View("PanelCompany",companyControlView);
            }
            var companiesDB = await CompanyRepository.GetAllAsync();
            List<CompanyViewModel> CompanyList = mapper.MapToViewCompanies(companiesDB.ToList());
            CompanyControlViewModel updateCompanyControlView = new CompanyControlViewModel(CompanyList);

            return View("PanelCompany", updateCompanyControlView);
        }
        public ActionResult PanelOrder()
        {
            return View();
        }
        public ActionResult PanelStaff()
        {
            return View();
        }
        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
