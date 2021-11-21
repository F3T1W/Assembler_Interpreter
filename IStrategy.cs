using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembler_Interpretator
{
    interface IStrategy
    {
        Dictionary<string, int> DoAlgorithm(Dictionary<string, int> dict, string[] arr, ref int x);
    }
}
