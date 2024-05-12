using App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Repository;
using Repository.Contracts;
using Models;
using Repository.Implementations;
using System.Net;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository ;
        public HomeController(ILogger<HomeController> logger,IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
             
            User usr = _userRepository.GetUser();

            ViewBag.usuario = new User()
            {
                IdUsuario = usr.IdUsuario,
                Name = usr.Name,
                Password = usr.Password                                
            };            
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
