using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Problems1_50
{
    internal class Problems : Base
    {
        //1
        internal void Problem1(int x = 1000)
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
        internal void Problem2(long x = 4000000)
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
        internal void Problem3(long number = 600851475143)
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
        internal void Problem4()
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
        internal void Problem5(int by = 1, int to = 20)
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
        internal void Problem6(int input = 100)
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
        internal void Problem7(int input = 10001)
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
        internal void Problem8(string FileName = "Digits.txt")
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
        internal void Problem9()
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
        internal void Problem10(int input = 2000000)
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
        public void Problem11()
        {
            //What is the greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 20×20 grid?
            int[,] table = {{08, 02, 22, 97, 38, 15, 00, 40, 00, 75, 04, 05, 07, 78, 52, 12, 50, 77, 91, 08},
                             {49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 98, 43, 69, 48, 04, 56, 62, 00},
                             {81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88, 30, 03, 49, 13, 36, 65},
                             {52, 70, 95, 23, 04, 60, 11, 42, 69, 24, 68, 56, 01, 32, 56, 71, 37, 02, 36, 91},
                             {22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40, 40, 28, 66, 33, 13, 80},
                             {24, 47, 32, 60, 99, 03, 45, 02, 44, 75, 33, 53, 78, 36, 84, 20, 35, 17, 12, 50},
                             {32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54, 70, 66, 18, 38, 64, 70},
                             {67, 26, 20, 68, 02, 62, 12, 20, 95, 63, 94, 39, 63, 08, 40, 91, 66, 49, 94, 21},
                             {24, 55, 58, 05, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83, 14, 88, 34, 89, 63, 72},
                             {21, 36, 23, 09, 75, 00, 76, 44, 20, 45, 35, 14, 00, 61, 33, 97, 34, 31, 33, 95},
                             {78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 03, 80, 04, 62, 16, 14, 09, 53, 56, 92},
                             {16, 39, 05, 42, 96, 35, 31, 47, 55, 58, 88, 24, 00, 17, 54, 24, 36, 29, 85, 57},
                             {86, 56, 00, 48, 35, 71, 89, 07, 05, 44, 44, 37, 44, 60, 21, 58, 51, 54, 17, 58},
                             {19, 80, 81, 68, 05, 94, 47, 69, 28, 73, 92, 13, 86, 52, 17, 77, 04, 89, 55, 40},
                             {04, 52, 08, 83, 97, 35, 99, 16, 07, 97, 57, 32, 16, 26, 26, 79, 33, 27, 98, 66},
                             {88, 36, 68, 87, 57, 62, 20, 72, 03, 46, 33, 67, 46, 55, 12, 32, 63, 93, 53, 69},
                             {04, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 08, 46, 29, 32, 40, 62, 76, 36},
                             {20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67, 59, 85, 74, 04, 36, 16},
                             {20, 73, 35, 29, 78, 31, 90, 01, 74, 31, 49, 71, 48, 86, 81, 16, 23, 57, 05, 54},
                             {01, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43, 52, 01, 89, 19, 67, 48}};

            string direction = "";
            int result = 1;
            int max = 0;
            int x = 0;
            int y = 0;
            //Horizontal
            for (int a = 0; a < 20; a++)
            {
                for (int i = 0; i < 17; i++)
                {
                    for (int j = 0; j < 4; j++)
                        result *= table[a, i + j];
                    if (result > max)
                    {
                        max = result;
                        x = i;
                        y = a;
                        direction = "right";
                    }
                    result = 1;
                }
            }
            //TODO: vertical, down-left, down-right
        }
        //12
        internal void Problem12()
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
        //13
        internal void Problem13(string fileName = "problem13.txt")
        {
            //Work out the first ten digits of the sum of the following one-hundred 50-digit numbers.(problem13.txt)
            string result = File.ReadAllLines(fileName)
            .Select(BigInteger.Parse)
            .Aggregate((i1, i2) => i1 + i2)
            .ToString()
            .Substring(0, 10);
            Console.WriteLine(result);
        }
    }
}
