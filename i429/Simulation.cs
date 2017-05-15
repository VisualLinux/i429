using System;
using System.Collections.Generic;
using System.Linq;

namespace i429
{
    internal class Simulation
    {
        public int LifeTime;
        public int U;
        public int K;
        public int A;
        public int B;
        public List<Island> Islands;
        public List<Bacterium> Bacteria;
        public List<Square> Squares;
        public List<Point> Points;
        public Container Container;
        public int T;
        public Random Rnd;

        public Simulation(int u, int k, int t, int a, int b)
        {
            U = u;
            K = k;
            LifeTime = t;
            A = a;
            B = b;
            Rnd = new Random();
        }

        public void Simulate(int n)
        {
            T = 0;
            CreateContainer(A, B);
            CreatePoints(Enumerable.Range(0, A).ToArray(), Enumerable.Range(0, B).ToArray());
            CreateIslands(n);
            CreateBacteria(n);
            CreateSquares(n);
            while (T < 10000 && Bacteria.All(x => !x.IsActive))
            {
                Step();
            }
        }


        void Step()
        {
            foreach (var bacterium in Bacteria)
            {
                if (bacterium.Location.X == 0 && bacterium.Location.Y == 0) //Bal alsó sarok   
                {
                    switch (Rnd.Next(0, 2))
                    {
                        case 0:
                            bacterium.Location.X++;
                            break;
                        case 1:
                            bacterium.Location.Y++;
                            break;
                    }
                }
                if (bacterium.Location.X == 0 && bacterium.Location.Y == B) //Bal felső sarok   
                {
                    switch (Rnd.Next(0, 2))
                    {
                        case 0:
                            bacterium.Location.X++;
                            break;
                        case 1:
                            bacterium.Location.Y--;
                            break;
                    }
                }
                if (bacterium.Location.X == A && bacterium.Location.Y == 0) //Jobb alsó sarok   
                {
                    switch (Rnd.Next(0, 2))
                    {
                        case 0:
                            bacterium.Location.X--;
                            break;
                        case 1:
                            bacterium.Location.Y++;
                            break;
                    }
                }
                if (bacterium.Location.X == 0 && bacterium.Location.Y == 0) //Jobb felső sarok   
                {
                    switch (Rnd.Next(0, 2))
                    {
                        case 0:
                            bacterium.Location.X++;
                            break;
                        case 1:
                            bacterium.Location.Y++;
                            break;
                    }
                }
            }
        }

        void CreateContainer(int a, int b)
            {
                Container = new Container(a, b, Squares);
            }

            void CreateSquares(int n)
            {
                foreach (var t in Points)
                {
                    var bacteriaLocal = Bacteria.Where(a => a.Location == t).ToArray();
                    Squares.Add(new Square(t, bacteriaLocal));
                }
            }

            void CreateIslands(int n)
            {
                for (var i = 0; i < n; i++)
                {
                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    // ReSharper disable once PossibleLossOfFraction
                    // ReSharper disable once AccessToModifiedClosure
                    Islands.Add(new Island(Points.Where(x => x.X == A / 2 && x.Y == Math.Floor((double)(i * B / (n + 1)))).ToArray()[0]));
                }
            }

            void CreateBacteria(int n)
            {
                for (var i = 0; i < n; i++)
                {
                    // ReSharper disable once PossibleLossOfFraction
                    for (var j = 0; j < Math.Floor((double)(K / n)); j++)
                    {
                        Bacteria.Add(new Bacterium(Points.Where(x => x == Islands[i].Location).ToList()[0], false));
                    }
                }
                // ReSharper disable once PossibleLossOfFraction
                for (var i = 0; i < K - n * Math.Floor((double)(K / n)); i++)
                {
                    Bacteria.Add(new Bacterium(Points.Where(x => x.X == 0 && x.Y == 0).ToArray()[0], true));
                }
            }

            void CreatePoints(int[] x, int[] y)
            {
                for (var i = 0; i < x.Length; i++)
                {
                    Points.Add(new Point(x[i], y[i]));
                }
            }
        }
    }
