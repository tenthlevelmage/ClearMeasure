using System;

namespace net.tlmage.clearmeasure.exercise
{
    public class CountUpUtility
    {
        public static String CountUp(int upperBound)
        {
            String result = "";
            for (int i = 1; i <= upperBound; i++)
            {
                bool isDivisibleBy3 = i % 3 == 0;
                bool isDivisibleBy5 = i % 5 == 0;

                if (isDivisibleBy3 && isDivisibleBy5)
                    result += "FizzBuzz\n";
                else if (isDivisibleBy3)
                    result += "Fizz\n";
                else if (isDivisibleBy5)
                    result += "Buzz\n";
                else
                    result += String.Format("{0}\n", i);
            }
            return result;
        }

    }
}
