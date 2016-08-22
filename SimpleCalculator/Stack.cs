using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Stack
    {
        public Stack ()
        {
        }
        public Stack<int> last_answer { get; set; }
        public Stack<string> last_expression { get; set; }

        public void SetLastAnswer(int result)
        {
            last_answer = new Stack<int>();
            last_answer.Push(result);
        }

        public int GetLastAnswer()
        {
            int answer = last_answer.Pop();
            return answer;
        }
        public void SetLastExpressionQueried(string userExpression)
        {
            last_expression = new Stack<string>();
            last_expression.Push(userExpression);
        }

    }
}
