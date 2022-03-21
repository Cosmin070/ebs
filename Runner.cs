using System;

namespace EBS
{
    class Runner
    {
        public static void Main(string[] args)
        {
            GeneratePublication generator = new GeneratePublication();
            Console.WriteLine(generator.Generate(0.2f, 0.8f, 0.2f, 0.8f, 0.2f, 0.8f));
            Console.WriteLine(generator.Generate(0.2f, 0.8f, 0.2f, 0.8f, 0.2f, 0.8f));
            Console.WriteLine(generator.Generate(0.2f, 0.8f, 0.2f, 0.8f, 0.2f, 0.8f));
            Console.WriteLine(generator.Generate(0.2f, 0.8f, 0.2f, 0.8f, 0.2f, 0.8f));
            Console.ReadLine();
            // generam 100% si cazuri < 100% handle -> split 30 40 30 -> 30%, 40%, 30% 
            // 
        }
    }
}
