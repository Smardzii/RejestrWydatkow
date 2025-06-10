using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return View(wydatek); // lub inna strona/formularz dodawania z b��dami
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Wydatek wydatek)
        {
            if (id != wydatek.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _wydatekService.ModyfikujWydatek(id, wydatek);
                return RedirectToAction(nameof(Index));
            }
            return View(wydatek); // lub strona edycji z b��dami
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _wydatekService.UsunWydatek(id);
            return RedirectToAction(nameof(Index));
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
