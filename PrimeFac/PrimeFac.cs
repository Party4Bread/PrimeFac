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
        public static bool PollardRho(BigInteger n, out BigInteger result, int limit = 100000)
        {
            BigInteger x_fixed = 2, cycle_size = 2, x = 2, factor = 1;

            while (factor == 1&& cycle_size<limit)
            {
                for (int count = 1; count <= cycle_size && factor <= 1; count++)
                {
                    x = (x * x + 1) % n;
                    factor = Util.GCD(x - x_fixed, n);
                }

                cycle_size *= 2;
                x_fixed = x;
            }
            if (factor != 1)
            {
                result = factor;
                return true;
            }
            else
            {
                return false;
            }
        }
        public static BigInteger Fermat(BigInteger n)
        {
            BigInteger x, y, w;
            Util.isqrt(n, out x);
            x += 1;
            Util.isqrt(x * x - n, out y);
            while (true)
            {
                w = (x * x) - n - (y * y);
                if (w == 0)
                    break;
                else if (w > 0)
                    y += 1;
                else
                    x += 1;
            }
            return x - y;
        }
        /// <summary>
        /// Perform Fermat attack on Modulus
        /// </summary>
        /// <param name="n">Modulus</param>
        /// <param name="limit">Loop Limit</param>
        /// <param name="result">Return one of prime</param>
        /// <returns>Return that was successful attack</returns>
        public static bool Fermat(BigInteger n, out BigInteger result, int limit = 100000)
        {
            BigInteger x, y, w;
            Util.isqrt(n, out x);
            x += 1;
            Util.isqrt(x * x - n, out y);
            while (limit>0)
            {
                w = (x * x) - n - (y * y);
                if (w == 0)
                    break;
                if (w > 0)
                    y += 1;
                else
                    x += 1;
                limit--;
            }
            if (limit != 0)
            {
                result = x - y;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
