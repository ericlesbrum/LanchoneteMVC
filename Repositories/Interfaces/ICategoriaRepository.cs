using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanchoneteMVC.Models;

namespace LanchoneteMVC.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria>Categorias{get;}
    }
}