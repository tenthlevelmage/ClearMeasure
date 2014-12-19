using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;

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
            List<KeyValuePair<int, String>> patternList = new List<KeyValuePair<int, string>>()
            {
                //new KeyValuePair<int, String>(0,"Zero"),
                //new KeyValuePair<int, String>(-10,"Negative"),
                new KeyValuePair<int, String>(3,"Fizz"),
                new KeyValuePair<int, String>(5,"Buzz"),
            };

            CountUp(lowerBound, upperBound, callBack, patternList);
        }

        // Print all the integers between a lowerBound and and upperBound (inclusive).
        // Except, filter out certain integer values, if they are divisible by any of a List of integer Keys,
        // replace those values with a Value associated with that particular Key.
        // If more than one happens to match, then append each Value, in the order it appears in the List.
        // Return the results, one number/string at a time, through a generic callBack method
        public static void CountUp(int lowerBound, int upperBound, Action<String> callBack,
            List<KeyValuePair<int, String>> patternList)
        {
            for (int i = lowerBound; i <= upperBound; i++)
            {
                String result = "";
                bool matched = false;

                foreach (KeyValuePair<int, String> pair in patternList)
                {
                    // We'll never be evenly divisible by zero
                    if (pair.Key == 0)
                        continue;

                    // Are we divisible by this Key?
                    if (i%pair.Key == 0)
                    {
                        // Append the Value associated with this Key
                        result += pair.Value;
                        matched = true;
                    }
                }

                // Did we match anything?  If not, return the integer
                if (!matched)
                    result = String.Format("{0}", i);
                
                // Send the result back to the caller
                callBack(result);
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
