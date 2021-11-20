using System;
using System.Collections.Generic;

namespace Assembler_Interpretator
{
    class Program
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

            virtual public void DoSomeBusinessLogic() { }
        }
        public interface IStrategy
        {
            Dictionary<string, int> DoAlgorithm(Dictionary<string, int> dict, int[] arr, ref int x);
        }
        class MoveTask : IStrategy
        {
            public Dictionary<string, int> DoAlgorithm(Dictionary<string, int> dict, int[] arr, ref int x)
            {
                dict[arr[1].ToString()] = (arr[2]);
                return dict;
            }
        }
        class IncTask : IStrategy
        {
            public Dictionary<string, int> DoAlgorithm(Dictionary<string, int> dict, int[] arr, ref int x)
            {
                dict[arr[1].ToString()]++;
                return dict;
            }
        }

        class DecTask : IStrategy
        {
            public Dictionary<string, int> DoAlgorithm(Dictionary<string, int> dict, int[] arr, ref int x)
            {
                dict[arr[1].ToString()]--;
                return dict;
            }
        }
        class JnzTask : IStrategy
        {
            public void ChangeI(Dictionary<string, int> dict, int[] arr, ref int x)
            {
                x += dict[arr[1].ToString()] != 0 ? arr[2] - 1 : 0;
            }
            public Dictionary<string, int> DoAlgorithm(Dictionary<string, int> dict, int[] arr, ref int x)
            {
                ChangeI(dict, arr,ref x);
                return dict;
            }
        }
        static Dictionary<string, int> Interpret(string[] program, Dictionary<string, int> regi)
        {
            Context context = new Context();
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

    
        

