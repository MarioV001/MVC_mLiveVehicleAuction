using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using mVehAuction.Models;
using Microsoft.EntityFrameworkCore;
using mVehAuction.Data;
using System;

namespace mVehAuction.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IWebHostEnvironment weben)
        {
            _logger = logger;
            _context = context;
            _environment = weben;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _context.Vehicle.ToListAsync());
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

        public IActionResult GetLastItems()
        {
            return View();
        }
    }
}