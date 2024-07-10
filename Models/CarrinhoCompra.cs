using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LanchoneteMVC.Models
{
    [Table("CarrinhoCompra")]
    public class CarrinhoCompra
    {
        [StringLength(200)]
        public string Id { get; set; }
        public List<CarrinhoCompraItem> carrinhoCompraItems { get; set; }
    }
}