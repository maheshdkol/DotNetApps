using System;

namespace ConvertToJava
{
    class Program
    {
        static void Main(string[] args)
        {
            //CS2jTranslator\bin\cs2j.exe -net-templates-dir=.\NetFramework\ -out-java-dir=Java -app-dir=ConvertToJava -cs-dir=ConvertToJava
            Console.WriteLine("Hello World!");
        }

        static int ReturnSomething()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 9)
                {
                    return i;
                }
            }
            return 0;
        }
    }
}
