using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problems1_50
{
    internal class Base
    {
        internal long Fibonacci(long x)
        {
            long i0 = 0;
            long i1 = 1;
            long isum = i0 + i1;
            for (long i = 0; i < x; i++)
            {
                isum = i0 + i1;
                i0 = i1;
                i1 = isum;
            }
            return isum;
        }
        internal bool IsPrime(long x)
        {
            if (x > 1)
            {
                long number = (long)Math.Floor(Math.Sqrt(x));
                for (long i = 2; i <= number; i++)
                {
                    if (x % i == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;

        }
        internal List<int> PrimeList(string FileName = "primes.txt")
        {
            List<int> primeList = new List<int>();
            try
            {
                StreamReader reader = new StreamReader(FileName);
                string primes;
                primes = reader.ReadToEnd();
                List<string> primesList = primes.Split().ToList();
                primesList.RemoveAll(i => i == null || i == "");
                primeList = primesList.Select(int.Parse).ToList();
                return primeList;
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong File Path");
                return primeList;
            }
        }
        internal string Reverse(int input)
        {
            return new string(input.ToString().ToCharArray().Reverse().ToArray());
        }
        internal long GCD(long a, long b) //greatest common divisor
        {
            while (b != 0)
            {
                a %= b;
                a ^= b;
                b ^= a;
                a ^= b;
            }
            return a;
        }
        internal long LCM(long a, long b) //lowest common multiple 
        {
            return a / GCD(a, b) * b;
        }
        internal List<List<int>> PTriplets()
        {
            var triplets = new List<List<int>>();
            List<int> sublist = new List<int>(3) { 0, 0, 0 };
            for (int a = 0; a < 1000; a++)
            {
                for (int b = 0; b < 1000; b++)
                {
                    for (int c = 0; c < 1000; c++)
                    {
                        if (a < b && b < c && a*a+b*b == c*c)
                        {
                            sublist[0] = a;
                            sublist[1] = b;
                            sublist[2] = c;
                        }
                    }
                }
            }
            foreach (var item in sublist)
            {
                Console.WriteLine(item);
            }
            foreach (var item in triplets)
            {
                foreach (var i in item)
                {
                    Console.Write(i);
                }
                Console.WriteLine();
            }
            return triplets;
        }
    }
}
