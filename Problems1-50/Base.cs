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
        internal bool IsPrime(long n)//O(sqrt(n))
        {
            for (int i = 2; i * i < n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;

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
        //O(LOGN) 
        internal long LCM(long a, long b) //lowest common multiple 
        {
            return a / GCD(a, b) * b;
        }
    }
}
