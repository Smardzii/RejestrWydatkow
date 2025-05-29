using Microsoft.AspNetCore.Mvc;
using RejestrWydatkow.Models;
using RejestrWydatkow.Services.Interfaces;
using System.Diagnostics;

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

        public async Task<IActionResult> Index(string sortOrder = "")
        {
            var wydatki = await _wydatekService.ListaWydatkow();
            wydatki = sortOrder switch
            {
                "Id_Desc" => wydatki.OrderByDescending(w => w.Id).ToList(),
                "Opis" => wydatki.OrderBy(w => w.Opis).ToList(),
                "Opis_Desc" => wydatki.OrderByDescending(w => w.Opis).ToList(),
                "Data" => wydatki.OrderBy(w => w.Data).ToList(),
                "Data_Desc" => wydatki.OrderByDescending(w => w.Data).ToList(),
                "Kwota" => wydatki.OrderBy(w => w.Kwota).ToList(),
                "Kwota_Desc" => wydatki.OrderByDescending(w => w.Kwota).ToList(),
                _ => wydatki.OrderBy(w => w.Id).ToList()
            };
            return View(wydatki);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Wydatek wydatek) 
        {
            await _wydatekService.DodajWydatek(wydatek);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromBody] Wydatek wydatek) 
        {
            await _wydatekService.ModyfikujWydatek(id, wydatek);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id) 
        {
            await _wydatekService.UsunWydatek(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
