﻿using System;
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
        int operationcounter { get; set; }

        public void ExpressionSplit (string expression_as_string)
        {
            try
            {
                this.expression_as_string = expression_as_string.Trim();
                expression_array = expression_as_string.Split(validOperand);
                LHS = Int32.Parse(expression_array[0]);
                RHS = Int32.Parse(expression_array[1]);
                findOperand();
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid format, try again. For example: 10 + 5 or 700 / 7");
            }
        }

        public void findOperand()
        {
            try
            {
                int LHS_Length = LHS.ToString().Length;
                char operand_from_string = expression_as_string[LHS_Length];
                //if there is trailing whitespace before the operand, this while loop will continue until the operand is found
                while (char.IsWhiteSpace(operand_from_string))
                {
                    LHS_Length++;
                    operand_from_string = expression_as_string[LHS_Length];
                }
                operand = operand_from_string;
            }
            catch (FormatException e)
            {
                Console.WriteLine("Try another format, for example: 10 + 5 or 7 * 12");
            }
        }
    }
}