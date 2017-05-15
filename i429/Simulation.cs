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
            Bacteria.RemoveAll(x => x.Age == LifeTime);
            foreach (var bacterium in Bacteria.Where(x=>x.IsActive).ToArray())
            {
                var dx = 0;
                var dy = 0;
                if (bacterium.Location.X == 0)
                {
                    switch (Rnd.Next(0, 2))
                    {
                        case 1:
                            dx = 1;
                            break;
                    }
                    if (bacterium.Location.Y == 0)
                    {
                        if (dx == 0)
                        {
                            dy = 1;
                        }
                    }
                    else if (bacterium.Location.Y == B)
                    {
                        if (dx == 0)
                        {
                            dy = -1;
                        }
                    }
                    else
                    {
                        switch (Rnd.Next(0, 2))
                        {
                            case 1:
                                if (dx == 0)
                                {
                                    dy = 1;
                                }
                                break;
                            case 2:
                                if (dx == 0)
                                {
                                    dy = -1;
                                }
                                break;
                        }
                    }
                }
                if (bacterium.Location.X == A)
                {
                    switch (Rnd.Next(0, 2))
                    {
                        case 1:
                            dx = -1;
                            break;
                    }
                    if (bacterium.Location.Y == 0)
                    {
                        if (dx == 0)
                        {
                            dy = 1;
                        }
                    }
                    else if (bacterium.Location.Y == B)
                    {
                        if (dx == 0)
                        {
                            dy = -1;
                        }
                    }
                    else
                    {
                        switch (Rnd.Next(0, 2))
                        {
                            case 1:
                                if (dx == 0)
                                {
                                    dy = 1;
                                }
                                break;
                            case 2:
                                if (dx == 0)
                                {
                                    dy = -1;
                                }
                                break;
                        }
                    }
                }
                else
                {
                    switch (Rnd.Next(0, 3))
                    {
                        case 1:
                            dx = -1;
                            break;
                        case 2:
                            dx = 1;
                            break;
                    }
                    if (bacterium.Location.Y == 0)
                    {
                        if (dx == 0)
                        {
                            dy = 1;
                        }
                    }
                    else if (bacterium.Location.Y == B)
                    {
                        if (dx == 0)
                        {
                            dy = -1;
                        }
                    }
                    else
                    {
                        switch (Rnd.Next(0, 2))
                        {
                            case 1:
                                if (dx == 0)
                                {
                                    dy = 1;
                                }
                                break;
                            case 2:
                                if (dx == 0)
                                {
                                    dy = -1;
                                }
                                break;
                        }
                    }
                }
                bacterium.Location = Points.Where(x => x.X == bacterium.Location.X + dx
                && x.Y == bacterium.Location.Y + dy).ToArray()[0];
                bacterium.Age++;
                if (Squares.Where(x => x.Location == bacterium.Location).ToArray()[0] is IslandSquare)
                {

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
