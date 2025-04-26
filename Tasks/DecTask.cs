using System.Collections.Generic;

namespace Assembler_Interpretator.Tasks;

public class DecTask : IStrategy
{
    public void DoAlgorithm(Dictionary<string, int> dict, string[] arr, ref int x) => dict[arr[1]]--;
}
