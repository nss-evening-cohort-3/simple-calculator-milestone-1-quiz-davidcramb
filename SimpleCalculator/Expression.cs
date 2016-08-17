using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Expression
    {
        public Expression(string userGivenExpression)
        {
            expression_as_string = userGivenExpression;
            expression_as_array = new string[3];
            expression_as_char_array = expression_as_string.ToCharArray();
            //LHS = LHS; 
            //RHS = RHS;
            operand = operand;

        }
        public string expression_as_string { get; set; }
        public string[] expression_as_array { get; set; }
        public char[] expression_as_char_array { get; set; }
        public int LHS { get; set; }
        public int RHS { get; set; }
        public string operand { get; set; }

        //parse the expression as string into LHS#, Operand, and RHS#

        //this method may be unnecessary
        public char[] splitExpressionString(string expression_as_string)
        {
            int number;
            List<int> testList = new List<int>();
            char[] expressionCharArray = expression_as_string.ToCharArray();
            foreach (var character in expressionCharArray)
            {
                Int32.TryParse(character.ToString(), out number);
                testList.Add(number);
            }
            return expressionCharArray;
        }

        public string[] ExpressionAsArray(char[] expression_as_char_array)
        {
            int operand = Array.IndexOf(expression_as_char_array, ('+' | '-' | '%' | '/' | '*'));
            //find index of operand to use as length of for loop, ignore foreach code below
            foreach(var character in expression_as_char_array)
            {
            }
            //
        }

        
    }
}
