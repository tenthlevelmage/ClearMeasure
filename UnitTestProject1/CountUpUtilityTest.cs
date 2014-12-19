using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace net.tlmage.clearmeasure.exercise
{
    [TestClass]
    public class CountUpUtilityTest
    {
        // This one test exercises all of the functionality of the CountUpUtility.  
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

            CountUpUtility.CountUp(-20, +20, textWriterCallBack, patternList);
            String result = stringWriter.ToString();

            string expectedResult = @"NegativeBuzz
-19
Fizz
-17
-16
FizzBuzz
-14
-13
Fizz
-11
NegativeBuzz
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
11
Fizz
13
14
FizzBuzz
16
17
Fizz
19
NegativeBuzz
";
            Assert.AreEqual(result,expectedResult);
        }
    }
}
