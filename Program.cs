using System;
using System.Collections.Generic;

namespace Assembler_Interpretator
{
    class Program
    {
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
                        context.DoSomeBusinessLogic(regi, values ,ref i);
                        break;
                    case "inc":
                        context.SetStrategy(new IncTask());
                        context.DoSomeBusinessLogic(regi, values, ref i);
                        break;
                    case "dec":
                        context.SetStrategy(new DecTask());
                        context.DoSomeBusinessLogic(regi, values, ref i);
                        break;
                    case "jnz":
                        context.SetStrategy(new JnzTask());
                        context.DoSomeBusinessLogic(regi, values, ref i);
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

    
        

