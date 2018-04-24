using System;
using System.Numerics;

namespace PrimeFac
{
    public static class PrimeFac
    {
        public static BigInteger PollardRho(BigInteger n)//TODO : set cycle limit, figure out how this work
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
        public static bool Fermat(BigInteger n,out BigInteger result, int limit = 10000)
        {
            BigInteger a,max,b,b2;
            Util.isqrt(n,out a);
            max = a + limit;
            while (a < max)
            {
                b2 = a * a - n;
                if (b2 >= 0)
                {
                    Util.isqrt(b2, out b);
                    if(b*b == b2)
                    {
                        break;
                    }
                }
                a += 1;
            }
            if (a < max)
            {
                result = a - b;
                return true;
            }
            else
                return false;
        }
    }
}
