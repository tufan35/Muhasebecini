﻿using Microsoft.AspNetCore.Mvc;
using Muhasebecini.Entities;
using Muhasebecini.Models;
using System.Diagnostics;

namespace Muhasebecini.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UnitOfWork.UnitOfWork _unitOfWork;
        private DatabaseContext _context;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _unitOfWork = new UnitOfWork.UnitOfWork(_context);
        }

        public IActionResult Index()
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
    }
}