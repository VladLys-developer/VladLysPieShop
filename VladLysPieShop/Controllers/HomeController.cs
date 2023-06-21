using VladLysPieShop.Models;
using VladLysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace VladLysPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public ViewResult Index()
        {
            var piesOfTheWeek = _pieRepository.PiesOfTheWeek;

            var homeViewModel = new HomeViewModel(piesOfTheWeek);

            return View(homeViewModel);
        }
    }
}
