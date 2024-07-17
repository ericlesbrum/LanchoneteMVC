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
            string CategoriaAtual = "";

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(lanche => lanche.Id);
            }
            else
            {
                lanches = _lancheRepository.Lanches.Where(lanche => lanche.Categoria.CategoriaNome.Equals(categoria));
            }
            return View(LancheListViewModel.GetLancheListViewModel(lanches, CategoriaAtual));
        }

        public IActionResult Details(int Id)
        {
            var lanche=_lancheRepository.Lanches.FirstOrDefault(lanche=>lanche.Id==Id);
            return View(lanche);
        }

        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}