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
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository ;
        public UserController(ILogger<UserController> logger,IUserRepository userRepository)
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
        public IActionResult Create()
        {            
            return View();
        }
        [HttpPost]
        public IActionResult Create(User usuario)
        {
            _userRepository.CreateUser(usuario);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
