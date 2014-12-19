using System;
using System.IO;

namespace net.tlmage.clearmeasure.exercise
{
    public class CountUpUtility
    {
        #region Public

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
            System.Console.Write("{0}", result);
        }

        // Print all the integers between a lowerBound and and upperBound (inclusive).
        // Except, print "Fizz" when the integer is evenly divisible by 3,
        // print "Buzz" when the integer is evenly divisible by 5;
        // print "FizzBUzz" when the integer is evenly divisible by both
        // Resturn the result as a String
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
        // Return the result through a user-supplied TextWriter
        public static void CountUp(int lowerBound, int upperBound, TextWriter textWriter)
        {
            TextWriterCallBack textWriterCallBack = new TextWriterCallBack(textWriter);
            CountUp(lowerBound, upperBound, textWriterCallBack.CallBack);
        }

        // Print all the integers between a lowerBound and and upperBound (inclusive).
        // Except, print "Fizz" when the integer is evenly divisible by 3,
        // print "Buzz" when the integer is evenly divisible by 5;
        // print "FizzBUzz" when the integer is evenly divisible by both
        // Return the results, one number/string at a time, through a generic callBack method
        public static void CountUp(int lowerBound, int upperBound, Action<String> callBack)
        {
            for (int i = lowerBound; i <= upperBound; i++)
            {
                bool isDivisibleBy3 = i % 3 == 0;
                bool isDivisibleBy5 = i % 5 == 0;

                if (isDivisibleBy3 && isDivisibleBy5)
                    callBack("FizzBuzz");
                else if (isDivisibleBy3)
                    callBack("Fizz");
                else if (isDivisibleBy5)
                    callBack("Buzz");
                else
                    callBack(String.Format("{0}", i));
            }
        }

        #endregion
        #region internal

        // Receive each number/string through the CallBack method,
        // and store them in the user-supplied TextWriter
        internal class TextWriterCallBack
        {
            private TextWriter _textWriter;

            // We'll store the collected messages in the user-supplied TextWriter
            public TextWriterCallBack(TextWriter textWriter)
            {
                _textWriter = textWriter;
            }

            // The number or String will be passed in here
            public void CallBack(String message)
            {
                _textWriter.WriteLine("{0}",message);
            }
        }

        #endregion
    }
}
