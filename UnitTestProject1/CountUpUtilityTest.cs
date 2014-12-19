using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace net.tlmage.clearmeasure.exercise
{
    [TestClass]
    public class CountUpUtilityTest
    {
        /// <summary>
        /// This one test exercises all of the functionality of the CountUpUtility.
        /// </summary>  
        [TestMethod]
        public void CountUpTest1()
        {
            StringWriter stringWriter = new StringWriter();
            CountUpUtility.ICallBack textWriterCallBack = new CountUpUtility.TextWriterCallBack(stringWriter);

            List<KeyValuePair<int, String>> patternList = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, String>(0,"Zero"),
                new KeyValuePair<int, String>(-10,"Negative"),
                new KeyValuePair<int, String>(3,"Fizz"),
                new KeyValuePair<int, String>(5,"Buzz"),
            };

            CountUpUtility.CountUp(-10, +10, textWriterCallBack, patternList);
            String result = stringWriter.ToString();

            string expectedResult = @"NegativeBuzz
Fizz
-8
-7
Fizz
Buzz
-4
Fizz
-2
-1
NegativeFizzBuzz
1
2
Fizz
4
Buzz
Fizz
7
8
Fizz
NegativeBuzz
";
            Assert.AreEqual(result, expectedResult);
        }

        /// <summary>
        /// This test exercises all of the interfaces of the CountUpUtility.  
        /// </summary>
        [TestMethod]
        public void CountUpTest2()
        {
            StringWriter stringWriter = new StringWriter();
            TextWriter textWriter = Console.Out;
            Console.SetOut(stringWriter);

            CountUpUtility.CountUp(10);

            Console.SetOut(textWriter);
            String result = stringWriter.ToString();

            string expectedResult = @"1
2
Fizz
4
Buzz
Fizz
7
8
Fizz
Buzz
";
            Assert.AreEqual(result,expectedResult);
        }
    }
}
