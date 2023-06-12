using BuscaCEP.Models;
using BuscaCEP.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuscaCEP.Services;


namespace BuscaCEP.Controllers
{
    public class CepController : Controller
    {
             
        private readonly CorreiosServices _correiosServices;

        public CepController(CorreiosServices correiosServices)
        {
            _correiosServices = correiosServices;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

  

