using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Tests
{
    [TestClass]
    public class ExpressionsTest
    {
        [TestMethod]
        public void ExpressionSavestoExpressionObjectAsString()
        {
            Expression expressed = new Expression("1+1");
            string expected = "1+1";
            string actual = expressed.expression_as_string;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ExpressionSeparateAsArray()
        {
            Expression expressed = new Expression("1+1");
            char[] expected = {'1', '+', '1'};
            char[] actual = expressed.splitExpressionString(expressed.expression_as_string);

            CollectionAssert.AreEquivalent(expected, actual);
        }
        [TestMethod]
        public void ExpressionDoesNotSplit()
        {
            //Going down a failed path to split the string array
            Expression expressed = new Expression("1+1");
            string expected = "1+1";
            expressed.splitExpressionString(expressed.expression_as_string);
            string actual = expressed.expression_as_array[0]; 

            Assert.AreSame(expected, actual);
        }
        [TestMethod]
        public void ExpressionCharArrayDisassembledFurther()
        {
            Expression expressed = new Expression("10+20");
            char[] expected = { '1','0', '+', '2','0' };
            char[] actual = expressed.splitExpressionString(expressed.expression_as_string);

            CollectionAssert.AreEquivalent(expected, actual);
        }
        [TestMethod]
        public void ExpressionParseOperandThrowsException()
        {
            Expression expressed = new Expression("11+22");
            expressed.splitExpressionString(expressed.expression_as_string);
            char[] charArray = { '1', '1', '+', '2', '2' };
            Int32.Parse(charArray[2]);
        }
        [TestMethod]
        public void ExpressionConverCharArrayTo3StringArray()
        {
            Expression expressed = new Expression("11+22");
            expressed.splitExpressionString(expressed.expression_as_string); //"1+2"
            string[] expressionArray = { "11", "+", "22" };
            int expected = 11;
                        Int32.Parse(expected[0]);
            Assert.AreEqual(expected[0], 11);

        }

    }
}
