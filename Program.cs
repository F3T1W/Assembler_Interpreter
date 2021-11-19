using System;
using System.Collections.Generic;

namespace Assembler_Interpretator
{
    class Program
    {
        class Context
        {
            public int GetValue(string key, Dictionary<string, int> rega)
            {
                return int.TryParse(key, out var val) ? val : rega[key];
            }

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

            virtual public void DoSomeBusinessLogic() { }
        }
        public interface IStrategy
        {
            Dictionary<string, int> DoAlgorithm(Dictionary<string, int> dict);
        }
        class MoveTask : IStrategy
        {
            public Dictionary<string, int> DoAlgorithm(Dictionary<string, int> dict)
            {
                throw new NotImplementedException();
            }
        }
        class IncTask : IStrategy
        {
            public Dictionary<string, int> DoAlgorithm(Dictionary<string, int> dict)
            {
                throw new NotImplementedException();
            }
        }

        class DecTask : IStrategy
        {
            public Dictionary<string, int> DoAlgorithm(Dictionary<string, int> dict)
            {
                throw new NotImplementedException();
            }
        }
        class JnzTask : IStrategy
        {
            public Dictionary<string, int> DoAlgorithm(Dictionary<string, int> dict)
            {
                    throw new NotImplementedException();
            }
        }
        static Dictionary<string, int> Interpret(string[] program, Dictionary<string, int> regi)
        {
            var context = new Context();
            for (var i = 0; i < program.Length; i++)
            {
                var values = program[i].Split();
                switch (values[0])
                {
                    case "mov":
                        context.SetStrategy(new MoveTask());
                        context.DoSomeBusinessLogic();
                        break;
                    case "inc":
                        context.SetStrategy(new IncTask());
                        context.DoSomeBusinessLogic();
                        break;
                    case "dec":
                        context.SetStrategy(new DecTask());
                        context.DoSomeBusinessLogic();
                        break;
                    case "jnz":
                        context.SetStrategy(new JnzTask());
                        context.DoSomeBusinessLogic();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return regi;
        }
        static void Main(string[] args)
        {
            var registers = new Dictionary<string, int>();
            Interpret(new[] {"mov a 5", "inc a", "dec a", "dec a", "jnz a -1", "inc a" }, registers);
        }
    }
}

    
        

