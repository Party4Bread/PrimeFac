using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace PrimeFac
{
    public static class Util
    {
        public static BigInteger GCD(BigInteger x, BigInteger y)
        {
            BigInteger remainder;
            while (y != 0)
            {
                remainder = x % y;
                x = y;
                y = remainder;
            }
            return BigInteger.Abs(x);
        }
        public static bool isqrt(BigInteger n,out BigInteger result)
        {
            if(n==0)
            {
                result = 0;
                return true;
            }
            BigInteger x, y;
            x = n;
            y = (n + 1) / 2;
            while (y < x)
            {
                x = y;
                y = (y + n / y) / 2;
            }
            result = x;
            if (n == x * x)
                return true;
            else
                return false;
        }
    }
}
