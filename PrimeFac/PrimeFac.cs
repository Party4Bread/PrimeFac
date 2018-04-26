using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace PrimeFac
{
    public static class PrimeFac
    {
        //TODO: Add isprime before every factor
        //TODO: Add algo which is not in YAFU

        //REF : https://en.wikipedia.org/wiki/Pollard%27s_rho_algorithm
        public static BigInteger PollardRho(BigInteger n, int c = 1)
        {
            BigInteger xFixed = 2, cycleSize = 2, x = 2, factor = 1;

            while (factor == 1)
            {
                for (int count = 1; count <= cycleSize && factor <= 1; count++)
                {
                    x = (x * x + c) % n;
                    factor = BigInteger.GreatestCommonDivisor(x - xFixed, n);
                }

                cycleSize *= 2;
                xFixed = x;
            }
            return factor;
        }
        public static bool PollardRho(BigInteger n, out BigInteger result, int limit = 100000, int c = 1)
        {
            BigInteger xFixed = 2, cycleSize = 2, x = 2, factor = 1;

            while (factor == 1 && cycleSize < limit)
            {
                for (int count = 1; count <= cycleSize && factor <= 1; count++)
                {
                    x = (x * x + c) % n;
                    factor = BigInteger.GreatestCommonDivisor(x - xFixed, n);
                }

                cycleSize *= 2;
                xFixed = x;
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

        //REF : https://github.com/elliptic-shiho/primefac-fork/blob/master/_primefac/_factor_algo/_fermat.py
        public static BigInteger Fermat(BigInteger n)
        {
            BigInteger x, y, w;
            x=Util.isqrt(n);
            x += 1;
            y=Util.isqrt(x * x - n);
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
        public static bool Fermat(BigInteger n, out BigInteger result, int limit = 100000)
        {
            BigInteger x, y, w;
            x = Util.isqrt(n);
            x += 1;
            y = Util.isqrt(x * x - n);
            while (limit > 0)
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

        //REF : https://comeoncodeon.wordpress.com/2010/09/18/pollard-rho-brent-integer-factorization/
        public static BigInteger PollardRho_brent(BigInteger n)
        {
            BigInteger y = 1, c = 1, m = 1, g = 1, r = 1, q = 1,x,k,ys,upper;//TODO : add random on y,c,m?
            while (g == 1)
            {
                x = y;
                for (int i = 0; i < r; i++)
                    y = (y * y + c) % n;
                k = 0;
                while (k < r && g == 1)
                {
                    ys = y;
                    upper = BigInteger.Min(m, r - k);
                    for (int i = 0; i < upper; i++)
                    {
                        y = (y * y + c) % n;
                        q = (q * BigInteger.Abs(x-y)) % n;
                    }
                    g = BigInteger.GreatestCommonDivisor(q, n);
                    k += m;
                }
                r *= 2;
            }
            if (g == n)
            {
                g = 1;
                while (g==1)
                {
                    ys = (ys * ys + c) % n;
                    g = BigInteger.GreatestCommonDivisor(BigInteger.Abs(x - ys), n);
                }   
            }
            return g;
        }

        public static BigInteger Pollard_PM1(BigInteger n)
        {
            return 0;
        }
    }
}
