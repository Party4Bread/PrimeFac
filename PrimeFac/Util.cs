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
    }
}
