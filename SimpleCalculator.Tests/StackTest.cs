using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleCalculator.Tests
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public void StacksSetsAnswer()
        {
            Expression expresso = new Expression();
            Stack stacky = new Stack();
            expresso.ExpressionSplit("2+3");
            Calculate cal = new Calculate(expresso.LHS, expresso.RHS, expresso.operand);
            cal.DetermineOperation();
            stacky.SetLastAnswer(cal.result);
            int expected = 5;
            int actual = stacky.last_answer.Peek();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void StackSetsExpression()
        {
            Expression exp = new Expression();
            Stack stacky = new Stack();
            exp.ExpressionSplit("5*10");
            Calculate cal = new Calculate(exp.LHS, exp.RHS, exp.operand);
            cal.DetermineOperation();
            stacky.SetLastExpressionQueried(exp.expression_as_string);
            string expected = "5*10";
            string actual = stacky.last_expression.Peek();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void StackRegexTest()
        {
            string constPat = @"(?<variable>[a-z])\s=\s(?<integer>[0-9]+)";
            Regex m = new Regex(constPat, RegexOptions.IgnoreCase);
            string exp = "1 + 3";
            string mexp = "x = 3";
            Match tryone = m.Match(exp);
            Console.WriteLine(tryone.ToString());
            Match trytwo = m.Match(mexp);
            Console.WriteLine(trytwo.ToString());
            //Console.WriteLine(trytwo.Groups.Count);
            Console.WriteLine(trytwo.Groups[0]);
            Console.WriteLine(trytwo.Groups[1]);
            Console.WriteLine(trytwo.Groups[2]);
        }
        [TestMethod]
        public void StackRegexTest2()
        {
            string constPat = @"(?<variable>[a-z])\s=\s(?<integer>[0-9]+)";
            Regex m = new Regex(constPat, RegexOptions.IgnoreCase);
            string mexp = "x = 3";
            Match trytwo = m.Match(mexp);
            Assert.AreEqual(mexp, trytwo.ToString());
        }
        [TestMethod]
        public void StackRegexMatchesPassIntoMethod()
        {
            string constPat = @"(?<variable>[a-z])\s=\s(?<integer>[0-9]+)";
            string mexp = "x = 3";
            Regex m = new Regex(constPat, RegexOptions.IgnoreCase);
            Match match = m.Match(mexp);
            char x = char.Parse(match.Groups[1].ToString());
            int y = int.Parse(match.Groups[2].ToString());

            Stack stacky = new Stack();
            stacky.SetUserVariableToThisValue(x, y);
            char expectedvar = 'x';
            int expectedint = 3;
            Assert.IsTrue(expectedvar == stacky.VariableLetter);
            Assert.IsTrue(expectedint == stacky.VariableValue);
        }
        [TestMethod]
        public void StackConstantCannotDeclareSameVariableTwice()
        {
            string constPat = @"(?<variable>[a-z])\s=\s(?<integer>[0-9]+)";
            string mexp = "x = 3";
            Regex m = new Regex(constPat, RegexOptions.IgnoreCase);
            Match match = m.Match(mexp);
            Stack stacky = new Stack();
            stacky.userVars = new Dictionary<char,int>();
            char x = char.Parse(match.Groups[1].ToString());
            int y = int.Parse(match.Groups[2].ToString());
            stacky.SetUserVariableToThisValue(x, y);
            string fail = "x = 5";
            Match matchfail = m.Match(fail);
            char a = char.Parse(matchfail.Groups[1].ToString());
            int b = int.Parse(matchfail.Groups[2].ToString());
            stacky.SetUserVariableToThisValue(a, b);
            Assert.IsFalse(stacky.userVars.ContainsValue(5));
            Assert.IsTrue(stacky.userVars.ContainsValue(3));
        }
    }
}
