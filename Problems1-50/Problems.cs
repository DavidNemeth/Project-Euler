using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems1_50
{
    internal class Problems : Base
    {
        //1
        internal void SumMultiples(int x = 1000)
        {
            //Find the sum of all the multiples of 3 or 5 below x.

            //Linq solution:
            var resultLinq = Enumerable.Range(0, 1000)
                .Where(i => i % 3 == 0 || i % 5 == 0).Sum();

            //default bruteforce
            long result = 0;
            for (int i = 0; i < x; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    result += i;
                }
            }
            Console.WriteLine("Sums of 3 and 5 multiples from 0 to 1000: {0}", resultLinq);
            Console.WriteLine("Sums of 3 and 5 multiples from 0 to {0}: {1}", x, result);
        }
        //2
        internal void SumEvenFibonacci(long x = 4000000)
        {
            //By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
            //Brute Force
            long i0 = 0;
            long i1 = 1;
            long isum = i0 + i1;
            long result = 0;
            while (isum < x)
            {
                if (isum % 2 == 0)
                {
                    result += isum;
                }
                isum = i0 + i1;
                i0 = i1;
                i1 = isum;
            }
            Console.WriteLine("The sum of even fibonacci numbers under {0}: {1}", x, result);
        }
        //3 
        //What is the largest prime factor of the number 600851475143 ? 
        //TODO: speed 
        internal void LargestPrimeFactor(long number = 600851475143)
        {
            long sqrtNumber = (long)Math.Floor(Math.Sqrt(number));
            long largestPrimeFactor = 0;
            for (long i = 1; i < sqrtNumber; i = (i == 2) ? 3 : i + 2)
            {
                if (IsPrime(i) && number % i == 0)
                {
                    largestPrimeFactor = i;                    
                }                
            }
            Console.WriteLine("Largest primefactor: {0} ", largestPrimeFactor);            
        }
        //4
        internal void LargestPalindromeProduct()
        {
            //Find the largest palindrome made from the product of two 3-digit numbers.
            throw new NotImplementedException();
        }
        //5
        internal void SmallestMultiple(int number1, int number2)
        {
            //What is the smallest positive number that is evenly divisible by all of the numbers from number1 to numer2?
            throw new NotImplementedException();
        }
    }
}