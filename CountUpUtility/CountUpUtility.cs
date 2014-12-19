using System;
using System.IO;

namespace net.tlmage.clearmeasure.exercise
{
    public class CountUpUtility
    {
        // Print all the integers between 1 and 100 (inclusive).
        // Except, print "Fizz" when the integer is evenly divisible by 3,
        // print "Buzz" when the integer is evenly divisible by 5;
        // print "FizzBUzz" when the integer is evenly divisible by both
        public static void CountUp()
        {
            CountUp(100);
        }

        // Print all the integers between 1 and a specified value (inclusive).
        // Except, print "Fizz" when the integer is evenly divisible by 3,
        // print "Buzz" when the integer is evenly divisible by 5;
        // print "FizzBUzz" when the integer is evenly divisible by both
        public static void CountUp(int upperBound)
        {
            String result = CountUp(1,upperBound);
            System.Console.WriteLine("{0}\n", result);
        }

        // Print all the integers between a lowerBound and and upperBound (inclusive).
        // Except, print "Fizz" when the integer is evenly divisible by 3,
        // print "Buzz" when the integer is evenly divisible by 5;
        // print "FizzBUzz" when the integer is evenly divisible by both
        public static String CountUp(int lowerBound, int upperBound)
        {
            StringWriter stringWriter = new StringWriter();
            CountUp(lowerBound, upperBound, stringWriter);

            String result = stringWriter.ToString();
            return result;
        }

        // Print all the integers between a lowerBound and and upperBound (inclusive).
        // Except, print "Fizz" when the integer is evenly divisible by 3,
        // print "Buzz" when the integer is evenly divisible by 5;
        // print "FizzBUzz" when the integer is evenly divisible by both
        // Return the result through a passed-in TextWriter
        public static void CountUp(int lowerBound, int upperBound, TextWriter textWriter)
        {
            for (int i = lowerBound; i <= upperBound; i++)
            {
                bool isDivisibleBy3 = i%3 == 0;
                bool isDivisibleBy5 = i%5 == 0;

                if (isDivisibleBy3 && isDivisibleBy5)
                    textWriter.WriteLine("FizzBuzz");
                else if (isDivisibleBy3)
                    textWriter.WriteLine("Fizz");
                else if (isDivisibleBy5)
                    textWriter.WriteLine("Buzz");
                else
                    textWriter.WriteLine("{0}", i);
            }
        }

    }
}
