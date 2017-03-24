using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    /// <summary>
    /// Assume starting floor is 0
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string controlCmd = "(()((()))))((()))))(((((()()()";

            ElevatorWithoutSequence(controlCmd);

            ElevatorWithSequence(controlCmd);
        }

        static void ElevatorWithoutSequence(string controlCmd)
        {
            int up = controlCmd.Where(c => c == '(').Count();
            int down = controlCmd.Where(c => c == ')').Count();

            int floor = up - down;

            Console.WriteLine($"Elevator at {floor.ToString()} floor");
            Console.ReadKey();
        }

        static void ElevatorWithSequence(string controlCmd)
        {
            int floor = 0;

            var seq = controlCmd.TakeWhile(
                c =>
                {
                    if (c == '(') floor++;
                    if (c == ')') floor--;
                    return floor != -1;
                }).ToArray();

            if (floor == -1)
            {
                Console.WriteLine("Reach Basement:");
                foreach (var c in seq)
                {
                    Console.Write($"{c}");
                }
                Console.Write($"{controlCmd[seq.Length]}");
            }
            else
            {
                Console.WriteLine("Cannot Reach Basement");
            }
            Console.ReadKey();
        }
    }
}
