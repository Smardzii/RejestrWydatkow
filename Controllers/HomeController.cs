using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using RejestrWydatkow.Models;
using RejestrWydatkow.Services.Interfaces;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RejestrWydatkow.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWydatekService _wydatekService;

        public HomeController(ILogger<HomeController> logger, IWydatekService wydatekService)
        {
            _logger = logger;
            _wydatekService = wydatekService;
        }

        public async Task<IActionResult> Index(string sortOrder)
        {
            var wydatki = await _wydatekService.ListaWydatkow();

            wydatki = sortOrder switch
            {
                "Opis" => wydatki.OrderBy(w => w.Opis).ToList(),
                "Opis_Desc" => wydatki.OrderByDescending(w => w.Opis).ToList(),
                "Kwota" => wydatki.OrderBy(w => w.Kwota).ToList(),
                "Kwota_Desc" => wydatki.OrderByDescending(w => w.Kwota).ToList(),
                "Data" => wydatki.OrderBy(w => w.Data).ToList(),
                "Data_Desc" => wydatki.OrderByDescending(w => w.Data).ToList(),
                "Kategoria" => wydatki.OrderBy(w => w.Kategoria).ToList(),
                "Kategoria_Desc" => wydatki.OrderByDescending(w => w.Kategoria).ToList(),
                "Id" => wydatki.OrderBy(w => w.Id).ToList(),
                "Id_Desc" => wydatki.OrderByDescending(w => w.Id).ToList(),
                _ => wydatki.OrderBy(w => w.Id).ToList()
            };

            return View(wydatki);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Wydatek wydatek)
        {
            if (ModelState.IsValid)
            {
                await _wydatekService.DodajWydatek(wydatek);
                return RedirectToAction(nameof(Index));
            }
            return View(wydatek);
        }

        public async Task<IActionResult> Summary()
        {
            var kategorie = await _wydatekService.Podsumowanie();
            return View(kategorie);
        }

        public async Task<IActionResult> Category(string kategoria)
        {
            if (kategoria == null)
                return RedirectToAction("Index");
            
            var dane = await _wydatekService.Podsumowanie(kategoria);
            return View(dane);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) 
        {
            var wydatek = await _wydatekService.ZnajdzWydatek(id);
            return View(wydatek);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Wydatek wydatek)
        {
            await _wydatekService.ModyfikujWydatek(wydatek);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _wydatekService.UsunWydatek(id);
            return RedirectToAction("Index");
        }

        public IActionResult Authors()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Autor()
        {
            return View();
        }
    }
}
