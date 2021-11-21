using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembler_Interpretator
{
     class Context
    {
        private IStrategy _strategy;

        public Context()
        { }


        public Context(IStrategy strategy)
        {
            this._strategy = strategy;
        }


        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void DoSomeBusinessLogic(Dictionary<string, int> dict, string[] arr, ref int x)
        {
            var result = this._strategy.DoAlgorithm(dict, arr, ref x);
        }
    }
}
