using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LanchoneteMVC.Models;
using LanchoneteMVC.Repositories.Interfaces;
using LanchoneteMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace LanchoneteMVC.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(lanche => lanche.Id);
                return View(LancheListViewModel.GetLancheListViewModel(lanches, "Todos os Lanches"));
            }
            switch (categoria.ToLower())
            {
                case "normal":
                    lanches = _lancheRepository.Lanches.Where(lanche => lanche.Categoria.CategoriaNome.Equals("Normal")).OrderBy(lanche => lanche.Nome);
                    return View(LancheListViewModel.GetLancheListViewModel(lanches, "Normal"));
                case "natural":
                    lanches = _lancheRepository.Lanches.Where(lanche => lanche.Categoria.CategoriaNome.Equals("Natural")).OrderBy(lanche => lanche.Nome);
                    return View(LancheListViewModel.GetLancheListViewModel(lanches, "Natural"));
                default:
                    lanches = _lancheRepository.Lanches.OrderBy(lanche => lanche.Id);
                    return View(LancheListViewModel.GetLancheListViewModel(lanches, "Todos os Lanches"));
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}