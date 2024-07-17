using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanchoneteMVC.Models;
using LanchoneteMVC.Repositories.Interfaces;
using LanchoneteMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchoneteMVC.ViewComponents
{
    public class CarrinhoCompraResumo : ViewComponent
    {
        private readonly ICarrinhoCompraRepository _carrinhoCompraRepository;

        public CarrinhoCompraResumo(ICarrinhoCompraRepository carrinhoCompraRepository)
        {
            _carrinhoCompraRepository = carrinhoCompraRepository;
        }
        public IViewComponentResult Invoke()
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
    }
}