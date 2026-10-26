using CCED_Sample_App.Data_Access;
using CCED_Sample_App.Models;
using CCED_Sample_App.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

namespace CCED_Sample_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly LicenseDbContext _context;
        public HomeController(LicenseDbContext context)
        {
            
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new LicenseSearchViewModel();
            var licenses = await _context.License.ToListAsync();
            viewModel.Licenses = licenses;
            return View(viewModel);
        }

        public async Task<IActionResult> DetailsAsync(int id)
        {
            var license = await _context.License.FirstOrDefaultAsync(x => x.Id == id); 
            return View(license);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var license = await _context.License.FirstOrDefaultAsync(x => x.Id == id);
            return View(license);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Models.License license)
        {
            try
            {
                _context.License.Update(license);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Success!";

                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Unable to save your changes. Please try again."
                );
            }
            return View(license);
        }

        public IActionResult Create()
        {
            var license = new Models.License();
            return View(license);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.License license)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _context.License.Add(license);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Success!";
                    return RedirectToAction("Index");
                }
                catch(DbUpdateException) {
                    ModelState.AddModelError("LicenseNumber", "This license number is already in use.");
                    return View(license);
                }

                
            }
            else
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Unable to save your changes. Please try again.");
            }
            return View(license);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
