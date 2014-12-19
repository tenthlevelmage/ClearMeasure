using System;
using System.IO;
using System.Collections.Generic;

namespace net.tlmage.clearmeasure.exercise
{
    public class CountUpUtility
    {
        #region Public

        /// <summary>
        /// Print all the integers between 1 and 100 (inclusive).
        /// Except, print "Fizz" when the integer is evenly divisible by 3,
        /// print "Buzz" when the integer is evenly divisible by 5;
        /// print "FizzBUzz" when the integer is evenly divisible by both
        /// </summary>
        public static void CountUp()
        {
            CountUp(100);
        }

        /// <summary>
        /// Print all the integers between 1 and a specified value (inclusive).
        /// Except, print "Fizz" when the integer is evenly divisible by 3,
        /// print "Buzz" when the integer is evenly divisible by 5;
        /// print "FizzBUzz" when the integer is evenly divisible by both
        /// </summary>
        /// <param name="upperBound">Stop counting at this integer</param>
        public static void CountUp(int upperBound)
        {
            String result = CountUp(1,upperBound);
            System.Console.Write("{0}", result);
        }

        /// <summary>
        /// Print all the integers between a lowerBound and and upperBound (inclusive).
        /// Except, print "Fizz" when the integer is evenly divisible by 3,
        /// print "Buzz" when the integer is evenly divisible by 5;
        /// print "FizzBUzz" when the integer is evenly divisible by both
        /// Return the result through a user-supplied TextWriter
        /// </summary>
        /// <param name="lowerBound">Start counting at this integer</param>
        /// <param name="upperBound">Stop counting at this integer</param>
        /// <returns>The String of the numbers/Strings, one per line</returns>
        public static String CountUp(int lowerBound, int upperBound)
        {
            StringWriter stringWriter = new StringWriter();
            CountUp(lowerBound, upperBound, stringWriter);

            String result = stringWriter.ToString();
            return result;
        }

        /// <summary>
        /// Print all the integers between a lowerBound and and upperBound (inclusive).
        /// Except, print "Fizz" when the integer is evenly divisible by 3,
        /// print "Buzz" when the integer is evenly divisible by 5;
        /// print "FizzBUzz" when the integer is evenly divisible by both
        /// Return the result through a user-supplied TextWriter
        /// </summary>
        /// <param name="lowerBound">Start counting at this integer</param>
        /// <param name="upperBound">Stop counting at this integer</param>
        /// <param name="textWriter">Use this TextWriter to collect the integers/Strings</param>
        public static void CountUp(int lowerBound, int upperBound, TextWriter textWriter)
        {
            TextWriterCallBack textWriterCallBack = new TextWriterCallBack(textWriter);
            CountUp(lowerBound, upperBound, textWriterCallBack);
        }

        /// <summary>
        /// Print all the integers between a lowerBound and and upperBound (inclusive).
        /// Except, print "Fizz" when the integer is evenly divisible by 3,
        /// print "Buzz" when the integer is evenly divisible by 5;
        /// print "FizzBUzz" when the integer is evenly divisible by both
        /// Return the results, one number/string at a time, through a generic callBack method
        /// </summary>
        /// <param name="lowerBound">Start counting at this integer</param>
        /// <param name="upperBound">Stop counting at this integer</param>
        /// <param name="callBack">Invoke the CallBack method of this class to collect each integer/String</param>
        public static void CountUp(int lowerBound, int upperBound, ICallBack callBack)
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

        /// <summary>
        /// Print all the integers between a lowerBound and and upperBound (inclusive).
        /// Except, filter out certain integer values, if they are divisible by any of a List of integer Keys,
        /// replace those values with a Value associated with that particular Key.
        /// If more than one happens to match, then append each Value, in the order it appears in the List.
        /// Return the results, one number/string at a time, through a generic callBack method
        /// </summary>
        /// <param name="lowerBound">Start counting at this integer</param>
        /// <param name="upperBound">Stop counting at this integer</param>
        /// <param name="callBack">Invoke the CallBack method of this class to collect each integer/String</param>
        /// <param name="patternList">An ordered List of Name/Value pairs of integers/Strings to be replaced</param>
        public static void CountUp(int lowerBound, int upperBound, ICallBack callBack,
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
                callBack.CallBack(result);
            }

        }

        /// <summary>
        /// Receive each number/string through the CallBack method,
        /// and store them in the user-supplied TextWriter
        /// </summary>
        public interface ICallBack
        {
            void CallBack(String message); // The number or String will be passed in here
        }

        /// <summary>
        /// Receive each number/string through the CallBack method,
        /// and store them in the user-supplied TextWriter
        /// </summary>
        public class TextWriterCallBack : ICallBack
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
