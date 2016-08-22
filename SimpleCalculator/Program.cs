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
            int counter = 0;
            Regex pemdas = new Regex(@"(\s*)?[\d](\s*)?(\+|\-|\*|\%|\/)(\s*)?[\d]+(\s*)?"); //not sure if i will use this
            string[] quitArray = { "no", "quit", "stop", "exit"};
            Stack lastExpression = new Stack();
            
            Console.WriteLine("This is a Calculator. There are many like it but this one is mine.");
            //While loop to kee
            while (keepGoing)
            {
                var prompt = ">";
                Console.WriteLine("Add, Subtract, Multiply, Divide, or get a Remainder");
                Console.Write("[{0}] {1} ", counter, prompt);
                string userPrompt = Console.ReadLine().ToLower();

                if (quitArray.Any(userPrompt.Contains))
                {
                    keepGoing = false;
                    Console.WriteLine("Bye!");
                    Console.ReadLine();
                }
                else if (userPrompt == "last")
                {
                    lastExpression.GetLastAnswer();
                }
                else if (userPrompt == "lastq")
                {
                    //lastExpression.GetLastExpressionQueried(userPrompt);
                }
                else
                {
                    Expression userExpression = new Expression();
                    try
                    { 
                        userExpression.ExpressionSplit(userPrompt);
                        //lastExpression.LastExpressionQueried(userPrompt);
                        Calculate calculation = new Calculate(userExpression.LHS, userExpression.RHS, userExpression.operand);
                        calculation.DetermineOperation();
                        //lastExpression.LastAnswer(calculation.result);
                        Console.WriteLine(calculation.result);
                        counter++;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}
