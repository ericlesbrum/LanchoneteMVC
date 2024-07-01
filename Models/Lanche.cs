using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchoneteMVC.Models
{
    public class Lanche
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DescricaoDetalhada { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }
        public string ImagemThumbnailUrl { get; set; }
        public bool IsLanchePreferido { get; set; }
        public bool EmEstoque { get; set; }
        
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}