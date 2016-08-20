using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Tests
{
    [TestClass]
    public class CalculateTest
    {
        [TestMethod]
        public void CalculateAcceptsExpressionProperties()
        {
            Expression exp = new Expression();
            exp.ExpressionSplit("14+6");
            Calculate cal = new Calculate(exp.LHS, exp.RHS, exp.operand);
            int expectedLHS = 14;
            int expectedRHS = 6;
            char expectedOperand = '+';
            Assert.AreEqual(expectedLHS, cal.x);
            Assert.AreEqual(expectedRHS, cal.y);
            Assert.AreEqual(expectedOperand, cal.operand);
        }
        [TestMethod]
        public void CalculateReturnsAddIntResultThroughDetermineOperation()
        {
            Expression exp = new Expression();
            exp.ExpressionSplit("5+1");
            Calculate cal = new Calculate(exp.LHS, exp.RHS, exp.operand);
            cal.DetermineOperation();
            int expected = 6;
            int actual = cal.result;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalcualteReturnsSubtractIntResultThroughDetermineOperation()
        {
            Expression exp = new Expression();
            exp.ExpressionSplit("40-33");
            Calculate cal = new Calculate(exp.LHS, exp.RHS, exp.operand);
            cal.DetermineOperation();
            int expected = 7;
            int actual = cal.result;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculateReturnsDivideIntResult()
        {
            Expression exp = new Expression();
            exp.ExpressionSplit("10/2");
            Calculate cal = new Calculate(exp.LHS, exp.RHS, exp.operand);
            cal.DetermineOperation();
            int expected = 5;
            int actual = cal.result;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculateReturnsMultiplyIntResult()
        {
            Expression exp = new Expression();
            exp.ExpressionSplit("12*11");
            Calculate cal = new Calculate(exp.LHS, exp.RHS, exp.operand);
            cal.DetermineOperation();
            int expected = 132;
            int actual = cal.result;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculateReturnsModulo()
        {
            Expression exp = new Expression();
            exp.ExpressionSplit("5%5");
            Calculate cal = new Calculate(exp.LHS, exp.RHS, exp.operand);
            cal.DetermineOperation();
            int expected = 0;
            int actual = cal.result;
            Assert.AreEqual(expected, actual);
        }
    }

}
