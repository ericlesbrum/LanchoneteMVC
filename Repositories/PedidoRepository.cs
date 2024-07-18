using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanchoneteMVC.Context;
using LanchoneteMVC.Models;
using LanchoneteMVC.Repositories.Interfaces;

namespace LanchoneteMVC.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ICarrinhoCompraRepository _carrinhoCompraRepository;

        public PedidoRepository(AppDbContext appDbContext, ICarrinhoCompraRepository carrinhoCompraRepository)
        {
            _appDbContext = appDbContext;
            _carrinhoCompraRepository = carrinhoCompraRepository;
        }

        public void CriarPedido(Pedido pedido)
        {
            // Persiste pedido no banco e cria o Id do pedido
            pedido.PedidoEnviado = DateTime.Now;
            _appDbContext.Pedidos.Add(pedido);
            _appDbContext.SaveChanges();

            var carrinhoCompraItems = _carrinhoCompraRepository.GetCarrinhoCompraItems();
            foreach (var carrinhoItem in carrinhoCompraItems)
            {
                var pedidoDetalhe = new PedidoDetalhe
                {
                    Quantidade = carrinhoItem.Quantidade,
                    LancheId = carrinhoItem.Lanche.Id,
                    PedidoId = pedido.Id,
                    Preco = carrinhoItem.Lanche.Preco
                };
                //
                _appDbContext.PedidoDetalhes.Add(pedidoDetalhe);
            }
            _appDbContext.SaveChanges();
        }
    }
}