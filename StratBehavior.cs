using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembler_Interpretator
{
        class MoveTask : IStrategy
        {
            public Dictionary<string, int> DoAlgorithm(Dictionary<string, int> dict, string[] arr, ref int x)
            {
                dict[arr[1]] = (Int32.Parse(arr[2]));
                return dict;
            }
        }
        class IncTask : IStrategy
        {
            public Dictionary<string, int> DoAlgorithm(Dictionary<string, int> dict, string[] arr, ref int x)
            {
                dict[arr[1].ToString()]++;
                return dict;
            }
        }

        class DecTask : IStrategy
        {
            public Dictionary<string, int> DoAlgorithm(Dictionary<string, int> dict, string[] arr, ref int x)
            {
                dict[arr[1].ToString()]--;
                return dict;
            }
        }
        class JnzTask : IStrategy
        {
            public void ChangeI(Dictionary<string, int> dict, string[] arr, ref int x)
            {
                x += dict[arr[1].ToString()] != 0 ? Int32.Parse(arr[2]) - 1 : 0;
            }
            public Dictionary<string, int> DoAlgorithm(Dictionary<string, int> dict, string[] arr, ref int x)
            {
                ChangeI(dict, arr, ref x);
                return dict;
            }
        }
    }

