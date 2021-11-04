using System;
using System.Collections.Generic;

namespace Assembler_Interpretator
{
    class Program
    {
        static void Main(string[] args)
        {
           static Dictionary<string, int> Interpret(string[] program)
            {
                var registers = new Dictionary<string, int>();
                int GetValue(string key) => int.TryParse(key, out var val) ? val : registers[key];
                for (var i = 0; i < program.Length; i++)
                {
                    var values = program[i].Split();
                    switch (values[0])
                    {
                        case "mov":
                            registers[values[1]] = GetValue(values[2]);
                            break;
                        case "inc":
                            registers[values[1]]++;
                            break;
                        case "dec":
                            registers[values[1]]--;
                            break;
                        case "jnz":
                            i += GetValue(values[1]) != 0 ? GetValue(values[2]) - 1 : 0;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                return registers;
            }
        }
    }
}
