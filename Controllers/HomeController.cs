using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lanchonete.Models;
using LanchoneteMVC.Repositories.Interfaces;
using LanchoneteMVC.ViewModels;

namespace Lanchonete.Controllers;

public class HomeController : Controller
{
    private readonly ILancheRepository _lancheRepository;

    public HomeController(ILancheRepository lancheRepository)
    {
        _lancheRepository = lancheRepository;
    }

    public IActionResult Index()
    {
        var homeViewModel= new HomeViewModel{
            LanchesPreferidos=_lancheRepository.LanchesPreferidos
        };
        return View(homeViewModel);
    }
}