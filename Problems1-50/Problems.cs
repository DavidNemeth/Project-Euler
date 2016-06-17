using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        internal void LargestPrimeFactor(long number = 600851475143)
        {
            //What is the largest prime factor of the number 600851475143 ? 
            //TODO: speed 
            long sqrtNumber = (long)Math.Floor(Math.Sqrt(number));
            long largestPrimeFactor = 0;
            for (long i = 1; i < sqrtNumber; i = (i == 2) ? 3 : i + 2)
            {
                if (IsPrime(i) && number % i == 0)
                {
                    largestPrimeFactor = i;
                }
            }
            Console.WriteLine("Largest primefactor of {0}: {1} ", number, largestPrimeFactor);
        }
        //4
        internal void LargestPalindromeProduct()
        {
            //Find the largest palindrome made from the product of two 3-digit numbers.
            var palindromes = new List<int>();
            int product = 0;
            for (int i = 1000; i > 99; i--)
            {
                for (int y = 1000; y > 99; y--)
                {
                    product = i * y;
                    string reversed = product.Reverse();
                    if (reversed == product.ToString())
                    {
                        palindromes.Add(product);
                        break;
                    }
                }
            }
            Console.WriteLine("Largets palindrom from two three digit procduct: {0}", palindromes.Max());
        }
        //5
        internal void SmallestMultiple(int by = 1, int to = 20)
        {
            //What is the smallest positive number that is evenly divisible by all of the numbers from number1 to numer2?
            if (by > to)
            {
                Console.WriteLine("The first parameter can not  be more than the second.");
            }
            else
            {
                long result = 1;
                for (long i = by; i <= to; i++)
                {
                    result = LCM(result, i);
                }
                Console.WriteLine("The smallest number evenly divisible from {0} to {1}: {2}", by, to, result);
            }
        }
        //6
        internal void SumSquareDifference(int input = 100)
        {
            //Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
            //bruteforce
            long sumSquare = 0;
            long squareSum = 0;
            for (int i = 1; i <= input; i++)
            {
                sumSquare += i * i;
                squareSum += i;
            }
            squareSum = squareSum * squareSum;
            long result = squareSum - sumSquare;
            Console.WriteLine("The SumSquareDifference of the first {0} netural number is: {1}", input, result);
        }
        //7
        internal void NthPrime(int input = 10001)
        {
            //What is the 10001st prime number?
            if (input > 200001)
            {
                Console.WriteLine("Input number is too large.");
            }
            else
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                long count = 0;
                var primes = new List<long>(input);
                while (primes.Count < input)
                {
                    if (IsPrime(count))
                    {
                        primes.Add(count);
                    }
                    count++;
                }
                Console.WriteLine(watch.Elapsed);
                Console.WriteLine(primes.Last());
            }
        }
        //8
        internal void LargestProductSeries(string FileName = "Digits.txt")
        {
            //Find the thirteen adjacent digits in the 1000-digit number that have the greatest product.           
            var digitArray = File.ReadAllLines(FileName);
            string digits = string.Join("", digitArray);
            long product = 0;
            long largestProduct = 0;
            var currentItems = new List<long>(13);
            var maxItems = new List<long>(13);
            for (int i = 0; i < digits.Length - 13; i++)
            {
                product = 1;
                currentItems.Clear();
                for (int j = 0; j < 13; j++)
                {
                    product *= long.Parse(digits.Substring(i + j, 1));
                    currentItems.Add(long.Parse(digits.Substring(i + j, 1)));
                }

                long maxCurrent = 1;
                long maxTotal = 1;
                foreach (var item in currentItems)
                {
                    maxCurrent *= item;
                }
                foreach (var item in maxItems)
                {
                    maxTotal *= item;
                }

                if (maxCurrent > maxTotal)
                {
                    maxItems = currentItems.ToList();
                }
                if (product > largestProduct)
                {
                    largestProduct = product;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Find the thirteen adjacent digits in the 1000-digit number that have the greatest product.");
            Console.WriteLine("Greatest Product: {0}", largestProduct);
            var items = string.Join(",", maxItems);
            Console.WriteLine("From the products of {0} ", items);

        }
        //9
        internal void PythagoreanTriplet()
        {
            //A Pythagorean triplet is a set of three natural numbers, a < b < c, for which, a2 + b2 = c2
            //There exists exactly one Pythagorean triplet for which a + b + c = 1000.
            //Find the product abc.            
            List<int> triplets = new List<int>(3);
            int num = 1000;
            int a, b, c;
            for (a = 0; a < num / 3; a++)
            {
                for (b = 0; b < num / 2; b++)
                {
                    c = num - a - b;
                    if (a * a + b * b == c * c)
                    {
                        triplets.Add(a);
                        triplets.Add(b);
                        triplets.Add(c);
                    }

                }
            }
            Console.WriteLine("a: {0}", triplets[0]);
            Console.WriteLine("b: {0}", triplets[1]);
            Console.WriteLine("c: {0}", triplets[2]);
        }
        //10
        internal void SummationOfPrimes(int input = 2000000)
        {
            //Find the sum of all the primes below two million.
            long sum = 2;
            for (long i = 1; i < input; i += 2)
            {
                if (IsPrime(i))
                {
                    sum += i;
                }
            }
            Console.WriteLine(sum);
        }
        //11
        //TODO:11
        //12
        internal void DivisibleTriangularNumber()
        {
            //What is the value of the first triangle number to have over five hundred divisors?
            long trianglenmbr = 0, divisors = 0, i = 1;
            while (divisors < 500)
            {
                divisors = 0;
                trianglenmbr += i;
                for (long j = 1; j <= Math.Sqrt(trianglenmbr); j++)
                {
                    divisors += trianglenmbr % j == 0 ? 2 : 0;
                }
                i++;
            }
            Console.WriteLine("The first triangle number to have over five hundred divisors:\n{0}\ndivisors: {1}", trianglenmbr, divisors);
        }
    }
}
