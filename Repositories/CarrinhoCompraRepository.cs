using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanchoneteMVC.Context;
using LanchoneteMVC.Models;
using LanchoneteMVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchoneteMVC.Repositories
{
    public class CarrinhoCompraRepository : ICarrinhoCompraRepository
    {
        private readonly AppDbContext _context;
        private static CarrinhoCompra carrinhoCompra;

        public List<CarrinhoCompraItem> carrinhoCompraItems { get; set; }
        public IEnumerable<CarrinhoCompraItem> CarrinhoCompraItems
        {
            get => carrinhoCompraItems;
            set => carrinhoCompraItems= (List<CarrinhoCompraItem>)value;
        }

        public CarrinhoCompraRepository(AppDbContext context)
        {
            _context = context;
        }

        public static CarrinhoCompra GetCarrinho(IServiceProvider serviceProvider)
        {
            //define uma sessão, caso contrario não é feito nada
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço do tipo do nosso contexto
            var context = serviceProvider.GetService<AppDbContext>();

            //obtem ou gera o Id do carrinho, caso contrario gera um novo
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na sessão
            session.SetString("CarrinhoId", carrinhoId);

            //retorna o carrinho com o contexto e o Id atribuído ou obtido
            return carrinhoCompra = new CarrinhoCompra()
            {
                Id = carrinhoId
            };
        }
        public void AdicionarAoCarrinho(Lanche lanche)
        {
            //verifica se o item existe
            var carrinhoCompraItem = _context.CarrinhoCompraItems.SingleOrDefault(
                item => item.Lanche.Id == lanche.Id && item.CarrinhoCompraId == carrinhoCompra.Id
            );
            //caso não exista, insere um novo produto
            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = carrinhoCompra.Id,
                    Lanche = lanche,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItems.Add(carrinhoCompraItem);
            }
            //senão existe, aumenta a quantidade
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            // salva as mudanças quando altera a quantidade
            _context.SaveChanges();
        }
        public void RemoverDoCarrinho(Lanche lanche)
        {
            //verifica se o item existe
            var carrinhoCompraItem = _context.CarrinhoCompraItems.SingleOrDefault(
                item => item.Lanche.Id == lanche.Id && item.CarrinhoCompraId == carrinhoCompra.Id
            );
            //verifica se o item existe e se a quantidade for maior que 1, decrementa e retorna o valor da quantidadeLocal
            if (carrinhoCompraItem != null)
                return;

            if (carrinhoCompraItem.Quantidade > 1)
            {
                carrinhoCompraItem.Quantidade--;
            }
            // caso contrario remove o item
            else
            {
                _context.CarrinhoCompraItems.Remove(carrinhoCompraItem);
            }
            //persiste no banco de dados
            _context.SaveChanges();
        }
        public List<CarrinhoCompraItem> GetCarrinhoCompraItems()
        {
            /*
                Retorna CarrinhoCompraItems se não for igual a null, caso seja nulo é avalidado a expressão:
                É utilizada a instancia do contexto e obtendo os carrinhos de compras comparado ao o id do carrinho da sessão,
                é incluido todos os lanches do carrinho
            */
            return (List<CarrinhoCompraItem>)(CarrinhoCompraItems ??
            (CarrinhoCompraItems =
                _context.CarrinhoCompraItems
                .Where(carrinho => carrinho.CarrinhoCompraId == carrinhoCompra.Id)
                .Include(carrinhoCompraItem => carrinhoCompraItem.Lanche)
                .ToList()));
        }
        public void LimparCarrinho()
        {
            /*
                Localiza o carrinho de compra com o id especifico, vai usar o metodo RemoveRange() para remover todos os itens do carrinho de compra
                e vai persistir no banco de dados
            */
            var carrinhoItems = _context.CarrinhoCompraItems.Where(carrinho => carrinho.CarrinhoCompraId == carrinhoCompra.Id);
            _context.CarrinhoCompraItems.RemoveRange(carrinhoItems);
            _context.SaveChanges();
        }
        public decimal GetCarrinhoCompraTotal()
        {
            /*
                Retorna o total da soma de todos os itens de um carrinho de compras
            */
            var total = _context.CarrinhoCompraItems
            .Where(carrinho => carrinho.CarrinhoCompraId == carrinhoCompra.Id)
            .Select(carrinho => carrinho.Lanche.Preco * carrinho.Quantidade).Sum();
            return total;
        }
    }
}