using System;
using System.Collections.Generic;
using Assembler_Interpretator.Tasks;

namespace Assembler_Interpretator
{
    public static class Program
    {
        private static void Interpret(string[] program, Dictionary<string, int> regi)
        {
            var context = new Context();
            for (var i = 0; i < program.Length; i++)
            {
                var values = program[i].Split();
                switch (values[0])
                {
                    case "mov":
                        context.SetStrategy(new MoveTask());
                        break;
                    case "inc":
                        context.SetStrategy(new IncTask());
                        break;
                    case "dec":
                        context.SetStrategy(new DecTask());
                        break;
                    case "jnz":
                        context.SetStrategy(new JnzTask());
                        break;
                    default:
                        Console.WriteLine("Unknown strategy");
                        break;
                }

                context.DoSomeBusinessLogic(regi, values ,ref i);
            }
        }

        private static void Main()
        {
            var registers = new Dictionary<string, int>();
            Interpret(new[] { "mov a 5", "inc a", "dec a", "dec a", "jnz a -1", "inc a" }, registers);
        }
    }
}

    
        

