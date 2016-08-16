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
            string[] expected = { "1", "+", "1" };
            expressed.splitExpressionString(expressed.expression_as_string);
            string[] actual = expressed.expression_as_array;
            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}
