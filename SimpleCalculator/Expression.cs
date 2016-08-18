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
            expression_as_char_array = expression_as_string.ToCharArray();
            expression_as_list = new List<string>();
            expression_list = new List<string>();

            //LHS = LHS; 
            //RHS = RHS;
            operand = operand;

        }
        public string[] validOperand = { "+", "-", "%", "/", "*" };
        public string expression_as_string { get; set; }
        public List<string> expression_as_list { get; set; }
        public List<string> expression_list { get; set; }
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

        public List<string> ConvertExpressionToList(char[] expression_as_char_array)
        {
            for (int i = 0; i < expression_as_char_array.Length; i++)
            {
                expression_as_list.Add(expression_as_char_array[i].ToString());
            }
            return expression_as_list;
        }

        public List<string> CreateConcatenatedList(List<string> expression_as_list)
        {
            string LHS = null;
            string RHS = null;
            string operand = null;
            int operandIndex = 0;
            for (int i = 0; i < expression_as_list.Count; i++)
            {
                if (expression_as_list[i] == "+" || expression_as_list[i] == "-" || expression_as_list[i] == "%" || expression_as_list[i] == "*" || expression_as_list[i] == "*")
                {
                    operand = expression_as_list[i];
                    operandIndex = expression_as_list.IndexOf(expression_as_list[i]);
                }
            }
            //get LHS
            for (int i = 0; i < operandIndex; i++)
            {
                LHS += expression_as_list[i];
            }
            for (int i = operandIndex; i <= expression_as_list.Count; i++)
            {
                RHS += expression_as_list[i];
            }
            expression_list.Add(LHS);
            expression_list.Add(operand);
            expression_list.Add(RHS);
            
            return expression_list;
        }
    }
}