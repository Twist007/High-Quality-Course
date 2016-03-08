using System;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace ArraySlider
{
    class ArraySlider
    {
        static void Main()
        {
            long[] inputSequance = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse).ToArray();
            {

                string[] commandLine = Console.ReadLine().Split().ToArray();
                long index = 0;
                while (commandLine[0] != "stop")
                {
                    long numA = long.Parse(commandLine[0]);
                    string operand = commandLine[1];
                    long c = long.Parse(commandLine[2]);
                    numA = numA % inputSequance.Length;
                    index += numA;
                    var position = index % inputSequance.Length;
                    if (position < 0)
                    {
                        position += inputSequance.Length;
                    }
                    if (position >= inputSequance.Length)
                    {
                        position -= inputSequance.Length;
                    }
                    ProduceOperation(operand, inputSequance, position, c);
                    commandLine = Console.ReadLine();
                }
                for (int qq = 0; qq < inputSequance.Length; qq++)
                {
                    if (inputSequance[qq] < 0)
                    {
                        inputSequance[qq] = 0;
                    }
                }
                Console.WriteLine("[" + string.Join(", ", inputSequance) + "]");
            }
        }

        private static void ProduceOperation(string operand, long[] inputSequance, long position, long c)
        {
            switch (operand)
            {
                case "+":
                    if ((inputSequance[position] + c) < 0)
                    {
                        inputSequance[position] = 0;
                    }
                    else inputSequance[position] = inputSequance[position] + c;
                    break;
                case "-":
                    if (inputSequance[position] < c)
                    {
                        inputSequance[position] = 0;
                    }
                    else inputSequance[position] = inputSequance[position] - c;
                    break;
                case "*":
                    if ((inputSequance[position]*c) < 0)
                    {
                        inputSequance[position] = 0;
                    }
                    else inputSequance[position] = inputSequance[position]*c;
                    break;
                case "/":
                    if ((inputSequance[position]/c) < 0)
                    {
                        inputSequance[position] = 0;
                    }
                    else inputSequance[position] = inputSequance[position]/c;
                    break;
                case "&":
                    if ((inputSequance[position] & c) < 0)
                    {
                        inputSequance[position] = 0;
                    }
                    else inputSequance[position] = inputSequance[position] & c;
                    break;
                case "|":
                    if ((inputSequance[position] | c) < 0)
                    {
                        inputSequance[position] = 0;
                    }
                    else inputSequance[position] = inputSequance[position] | c;
                    break;
                case "^":
                    if ((inputSequance[position] ^ c) < 0)
                    {
                        inputSequance[position] = 0;
                    }
                    else inputSequance[position] = inputSequance[position] ^ c;
                    break;
            }
        }
    }
}