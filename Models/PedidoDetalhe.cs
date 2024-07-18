using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LanchoneteMVC.Models
{
    public class PedidoDetalhe
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        /*
            Define um relacionamento um para muitos e gera as chaves estrangeiras: 
            PedidoId(not NULL) e LancheId(not NULL)
        */
        public Lanche Lanche { get; set; }
        public int LancheId { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual int PedidoId { get; set; }
    }
}