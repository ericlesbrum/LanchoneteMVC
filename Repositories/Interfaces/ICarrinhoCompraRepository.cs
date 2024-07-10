using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanchoneteMVC.Models;

namespace LanchoneteMVC.Repositories.Interfaces
{
    public interface ICarrinhoCompraRepository
    {
        IEnumerable<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }
        List<CarrinhoCompraItem> GetCarrinhoCompraItems();
        decimal GetCarrinhoCompraTotal();
        void AdicionarAoCarrinho(Lanche lanche);
        void RemoverDoCarrinho(Lanche lanche);
    }
}