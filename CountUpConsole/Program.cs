using System;

namespace net.tlmage.clearmeasure.exercise
{
    class CountUpConsole
    {
        static void Main(string[] args)
        {
            String result = CountUpUtility.CountUp(100);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
