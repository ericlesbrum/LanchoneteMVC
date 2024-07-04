using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanchoneteMVC.Models;

namespace LanchoneteMVC.Repositories.Interfaces
{
    public interface ILancheRepository
    {
        IEnumerable<Lanche> Lanches{get;}
        IEnumerable<Lanche> LanchesPreferidos{get;}
        Lanche GetLancheById(int lancheId);
    }
}