using System.Collections.Generic;

namespace Assembler_Interpretator
{
    internal class Context
    {
        private IStrategy _strategy;
        
        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void DoSomeBusinessLogic(Dictionary<string, int> dict, string[] arr, ref int x)
        {
            _strategy.DoAlgorithm(dict, arr, ref x);
        }
    }
}
