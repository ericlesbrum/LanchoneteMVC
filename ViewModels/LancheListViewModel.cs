using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanchoneteMVC.Models;

namespace LanchoneteMVC.ViewModels
{
    public class LancheListViewModel
    {

        public IEnumerable<Lanche> Lanches { get; set; }
        public string CategoriaAtual { get; set; }

        public static LancheListViewModel GetLancheListViewModel(IEnumerable<Lanche> lanche, string categoria)
        {
            return new LancheListViewModel
            {
                Lanches = lanche,
                CategoriaAtual = categoria
            };

        }
    }
}