using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i429
{
    static class Program
    {
        public static int LifeTime;
        public static int U;
        public static int K;
        public static int A;
        public static int B;
        public static void Main(string[] args)
        {
            var Input = Console.ReadLine().Split(' '); //K,U,T,a,b
            ParseInput(Input);
            Simulation simulation = new Simulation(U, K, LifeTime, A, B);
            foreach (var n in Enumerable.Range(1, 50))
            {
                for (int i = 0; i < 100; i++)
                {
                    simulation.Simulate(n);
                }
            }
        }

        static void ParseInput(string[] input)
        {
            K = Convert.ToInt32(input[0]);
            U = Convert.ToInt32(input[1]);
            LifeTime = int.Parse(input[2]);
            A = int.Parse(input[3]);
            B = int.Parse(input[4]);
        }
    }
}
