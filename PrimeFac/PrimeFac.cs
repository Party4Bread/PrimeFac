using System;
using System.Numerics;

namespace PrimeFac
{
    public static class PrimeFac
    {
        public static BigInteger PollardRho(BigInteger n)
        {
            BigInteger x_fixed = 2, cycle_size = 2, x = 2, factor = 1;

            while (factor == 1)
            {
                for (int count = 1; count <= cycle_size && factor <= 1; count++)
                {
                    x = (x * x + 1) % n;
                    factor = Util.GCD(x - x_fixed, n);
                }

                cycle_size *= 2;
                x_fixed = x;
            }
            return factor;
        }
    }
}
