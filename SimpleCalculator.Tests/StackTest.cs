using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void StackGetAnswer()
        {
            Expression expresso = new Expression();
            Stack stacky = new Stack();
            expresso.ExpressionSplit("2+3");
            Calculate cal = new Calculate(expresso.LHS, expresso.RHS, expresso.operand);
            cal.DetermineOperation();
            stacky.SetLastAnswer(cal.result);
            int expected = 5;
            int actual = stacky.GetLastAnswer();
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
        public void StackGetExpression()
        {
            Expression exp = new Expression();
            Stack stacky = new Stack();
            exp.ExpressionSplit("5*10");
            Calculate cal = new Calculate(exp.LHS, exp.RHS, exp.operand);
            cal.DetermineOperation();
            stacky.SetLastExpressionQueried(exp.expression_as_string);
            string expected = "5*10";
            string actual = stacky.GetLastExpressionQueried();
            Assert.AreEqual(expected, actual);
        }
    }
}
