using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExOrdenacao.src.pt.Strategy.Contexto
{
    public interface ISortAlgorithm
    {
        int[] Sort(int[] arr);
    }
}