using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LanchoneteMVC.Models;
using LanchoneteMVC.Repositories.Interfaces;
using LanchoneteMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchoneteMVC.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly ICarrinhoCompraRepository _carrinhoCompraRepository;

        public CarrinhoCompraController(ILancheRepository lancheRepository, ICarrinhoCompraRepository carrinhoCompraRepository)
        {
            _lancheRepository = lancheRepository;
            _carrinhoCompraRepository = carrinhoCompraRepository;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompraRepository.GetCarrinhoCompraItems();

            _carrinhoCompraRepository.GetCarrinhoCompra().carrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompraRepository.GetCarrinhoCompra(),
                CarrinhoCompraTotal = _carrinhoCompraRepository.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraVM);
        }
        public IActionResult AdicionarItemNoCarrinhoCompra(int Id)
        {
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault((lanche) => lanche.Id == Id);

            if (lancheSelecionado != null)
            {
                _carrinhoCompraRepository.AdicionarAoCarrinho(lancheSelecionado);
            }

            return RedirectToAction("Index");
        }
        public IActionResult RemoverItemNoCarrinhoCompra(int Id)
        {
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault((lanche) => lanche.Id == Id);

            if (lancheSelecionado != null)
            {
                _carrinhoCompraRepository.RemoverDoCarrinho(lancheSelecionado);
            }
            
            return RedirectToAction("Index");
        }
    }
}