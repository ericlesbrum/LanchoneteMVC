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
            var lanche = _lancheRepository.Lanches.FirstOrDefault(lanche => lanche.Id == Id);
            return View(lanche);
        }
        public IActionResult Search(string searchString)
        {
            IEnumerable<Lanche> lanches;
            string CategoriaAtual = string.Empty;
            if (string.IsNullOrEmpty(searchString))
            {
                lanches = _lancheRepository.Lanches.OrderBy(lanche => lanche.Id);
                CategoriaAtual = "Todos os Lanches";
            }
            else
            {
                lanches = _lancheRepository.Lanches.Where(lanche => lanche.Nome.ToLower().Contains(searchString.ToLower()));
                if (lanches.Any())
                    CategoriaAtual = "Lanches";
                else
                    CategoriaAtual = "Nenhum lanche foi encontrado";
            }

            return View("~/Views/Lanche/List.cshtml", new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = CategoriaAtual
            });
        }

        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}