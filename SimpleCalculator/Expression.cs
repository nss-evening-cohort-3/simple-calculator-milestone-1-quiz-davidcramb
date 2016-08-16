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
                        
        }
        public string expression_as_string { get; set; }
        public string[] expression_as_array { get; set; }

        //parse the expression as string into LHS#, Operand, and RHS#
        public string[] splitExpressionString(string expression_as_string)
        {
            string[] testarray = expression_as_string.Split(new char[] { '+' });
            return expression_as_array = testarray;
            
        }

        
    }
}
