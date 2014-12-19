using System;

namespace net.tlmage.clearmeasure.exercise
{
    class CountUpConsole
    {
        /// <summary>
        /// Print all the integers between 1 and 100 (inclusive).
        /// Except, print "Fizz" when the integer is evenly divisible by 3,
        /// print "Buzz" when the integer is evenly divisible by 5;
        /// print "FizzBUzz" when the integer is evenly divisible by both
        /// </summary>
        static void Main()
        {
            CountUpUtility.CountUp();

            Console.Write("Press and key to continue ...");
            Console.ReadKey();
        }
    }
}
