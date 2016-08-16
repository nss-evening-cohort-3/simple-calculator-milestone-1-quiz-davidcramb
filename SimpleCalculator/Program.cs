using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepGoing = true;
            Regex pemdas = new Regex(@"(\s*)?[\d](\s*)?(\+|\-|\*|\%|\/)(\s*)?[\d]+(\s*)?"); //not sure if i will use this
            string[] quitArray = { "no", "quit", "stop", "exit", "q" };
            
            var prompt = ">";
            Console.WriteLine("Let's Play with Baby's First Calculator");
            //While loop to kee
            while (keepGoing)
            {
                string userPrompt = Console.ReadLine().ToLower();
                Console.WriteLine("Add, Subtract, Multiply, Divide, or get a Remainder");
                Console.WriteLine(prompt);
                
                if (quitArray.Any(userPrompt.Contains))
                {
                    keepGoing = false;
                    Console.WriteLine("Bye!");
                    Console.ReadLine();

                }
            }
        }
    }
}
