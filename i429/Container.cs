using System.Collections.Generic;

namespace i429
{
    public class Container
    {
        public int A;
        public int B;
        public List<Square> Squares;

        public Container(int a, int b, List<Square> squares)
        {
            A = a;
            B = b;
            Squares = squares;
        }
    }
}