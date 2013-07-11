﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace RayMitchell.ProjectEuler
{
    /// <summary>
    /// Project Euler, Problem 12 (http://projecteuler.net/problem=12).
    /// 
    /// The sequence of triangle numbers is generated by adding the natural
    /// numbers. So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7
    /// = 28. The first ten terms would be:
    /// 
    /// 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...
    /// 
    /// Let us list the factors of the first seven triangle numbers:
    /// 
    ///      1: 1
    ///      3: 1,3
    ///      6: 1,2,3,6
    ///     10: 1,2,5,10
    ///     15: 1,3,5,15
    ///     21: 1,3,7,21
    ///     28: 1,2,4,7,14,28
    /// 
    /// We can see that 28 is the first triangle number to have over five
    /// divisors.
    /// 
    /// What is the value of the first triangle number to have over five
    /// hundred divisors?
    /// 
    /// Answer: 76576500
    /// </summary>
    public class Problem12
    {
        public static IEnumerable<int> Divisors(int value)
        {
            for (int i = 1, max = (int)Math.Sqrt(value); i <= max; ++i)
                if (value % i == 0)
                {
                    yield return i;
                    yield return value / i;
                }
        }

        public static IEnumerable<int> TriangleNumbers()
        {
            for (int i = 1, t = 1; ; ++i, t += i)
                yield return t;
        }

        public static int Solve()
        {
            foreach (var i in TriangleNumbers())
                if (Divisors(i).ToArray().Length >= 500)
                    return i;

            throw new InvalidOperationException();  // Should never be reached
        }
    }
}
