using System.Collections.Generic;

namespace Assembler_Interpretator;

internal interface IStrategy
{
    void DoAlgorithm(Dictionary<string, int> dict, string[] arr, ref int x);
}
