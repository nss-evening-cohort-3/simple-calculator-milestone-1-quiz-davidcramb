using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Expression
    {
        public Expression()
        {
        }

        public char[] validOperand = { '+','-','%','/','*'};
        public char[] digits = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        public string expression_as_string { get; set; }
        public string[] expression_array { get; set; }
        public int LHS { get; set; }
        public int RHS { get; set; }
        public char operand { get; set; }

        public void ExpressionSplit (string expression_as_string)
        {
            this.expression_as_string = expression_as_string;
            expression_array = expression_as_string.Split(validOperand);
            LHS = Int32.Parse(expression_array[0]);
            RHS = Int32.Parse(expression_array[1]);
            findOperand();
        }

        public void findOperand()
        {
            int LHS_Length = LHS.ToString().Length;
            char operand_from_string = expression_as_string[LHS_Length];
            operand = operand_from_string;
        }
    }
}