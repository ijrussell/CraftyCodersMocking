using System;

namespace StateVsMock
{
    public class BasicMathematics
    {
        public BasicMathematics()
        {
            Adder = new Adder();
        }

        public Adder Adder { get; set; }

        public int Multiply(int a, int b)
        {
            var isPositiveA = a >= 0;
            var isPositiveB = b >= 0;
            var isProductNegative = isPositiveA != isPositiveB;

            a = Math.Abs(a);
            b = Math.Abs(b);

            var product = RepetativeAdd(a, b);
            //var product = ShiftAndAdd(a, b);

            return isProductNegative ? -product : product;
        }

        private int RepetativeAdd(int a, int b)
        {
            var product = 0;

            while (a-- > 0)
                product = Adder.Add(product, b);

            return product;
        }

        private int ShiftAndAdd(int a, int b)
        {
            int product;

            for (product = 0; a > 0; b = b << 1, a = a >> 1)
                if ((a & 1) == 1)
                    product = Adder.Add(product, b);

            return product;
        }
    }
}