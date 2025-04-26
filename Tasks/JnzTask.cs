using System.Collections.Generic;

namespace Assembler_Interpretator.Tasks;

public class JnzTask : IStrategy
{
    private static void ChangeI(Dictionary<string, int> dict, string[] arr, ref int x) =>
        x += dict[arr[1]] != 0 ? int.Parse(arr[2]) - 1 : 0;

    public void DoAlgorithm(Dictionary<string, int> dict, string[] arr, ref int x) => ChangeI(dict, arr, ref x);
}
