using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Tests
{
    [TestClass]
    public class ExpressionsTest
    {
        [TestMethod]
        public void ExpressionExpressionSplitGivesExpectedProperties()
            //expected properties are integer values for LHS, RHS and string for operand
        {
            Expression expressed = new Expression();
            expressed.ExpressionSplit("1+2");
            int expectedLHS = 1;
            int expectedRHS = 2;
            int actualLHS = expressed.LHS;
            int actualRHS = expressed.RHS;
            string actual = expressed.expression_as_string;

            Assert.AreEqual(expectedLHS, actualLHS);
            Assert.AreEqual(expectedRHS, actualRHS);
        }
        [TestMethod]
        public void ExpressionExpressionSplitLargerIntegers()
        //expected properties are integer values for LHS, RHS and string for operand
        {
            Expression expressed = new Expression();
            expressed.ExpressionSplit("100+200");
            int expectedLHS = 100;
            int expectedRHS = 200;
            int actualLHS = expressed.LHS;
            int actualRHS = expressed.RHS;
            string actual = expressed.expression_as_string;

            Assert.AreEqual(expectedLHS, actualLHS);
            Assert.AreEqual(expectedRHS, actualRHS);
        }
        [TestMethod]
        public void ExpressionOperandIsFound()
        {
            Expression expressed = new Expression();
            expressed.ExpressionSplit("12+9");
            char expected = '+';
            char actual = expressed.operand;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ExpressionFindOperandGetsOtherOperandsMinus()
        {
            List<char> expectedCharList = new List<char> { '-', '/', '%', '*' };
            List<char> actualCharList = new List<char>();
            Expression minus = new Expression();
            minus.ExpressionSplit("1000-5000");
            Expression divide = new Expression();
            divide.ExpressionSplit("22/1");
            Expression modulo = new Expression();
            modulo.ExpressionSplit("5%3");
            Expression multiply = new Expression();
            multiply.ExpressionSplit("15*99");

            actualCharList.Add(minus.operand);
            actualCharList.Add(divide.operand);
            actualCharList.Add(modulo.operand);
            actualCharList.Add(multiply.operand);

            CollectionAssert.AreEquivalent(expectedCharList, actualCharList);

        }
        [TestMethod]
        public void ExpressionIgnoresWhitespace()
        {
            Expression add = new Expression();
            add.ExpressionSplit("  5    +   7");
            int expectedLHS = 5;
            int expectedRHS = 7;
            char expectedOperand = '+';
            Assert.AreEqual(expectedLHS, add.LHS);
            Assert.AreEqual(expectedRHS, add.RHS);
            Assert.AreEqual(expectedOperand, add.operand);
        }
        [TestMethod]
        public void ExpressionCheckForConstant()
        {
            Expression add = new Expression();
            add.ExpressionSplit("5 + x");
            string[] barg = { "x" };
            Console.WriteLine(Char.IsLetter(char.Parse(barg[0])));
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            dictionary.Add('x', 5);
            Console.WriteLine(dictionary['x']);
        }
        [TestMethod]
        public void ExpressionTakesUserDefinedConstant()
        {
            Expression add = new Expression();
            Stack stack = new Stack();
            add.Constant.userVars.Add('x', 30);
            add.ExpressionSplit("x+5");
            Console.WriteLine(add.LHS);
        }
    }
}
//[TestMethod]
//public void ExpressionSplitsOnOperand()
//{
//    Expression expressed = new Expression("11+22");
//    expressed.
//            string[] actual = expressed.ExpressionSplit(expressed.expression_as_string);
//    string[] expected = { "11", "22" };
//    CollectionAssert.AreEquivalent(expected, actual);
//}

//[TestMethod]
//public void expressionretrieveLHS()
//{
//    Expression expressed = new Expression("11+22");
//    int expected = 11;
//    expressed.ExpressionSplit(expressed.expression_as_string);
//    int actual = expressed.LHS;
//}
//[TestMethod]
//public void ExpressionExtractOperandFromInput()
//{
//    Expression expressed = new Expression("100+300");
//    string expected = "+";
//    string actual = expressed.operand;
//    Assert.AreEqual(expected, actual[0]);
//}
        //[TestMethod]
        //public void ExpressionSeparateAsArray()
        //{
        //    Expression expressed = new Expression("1+1");
        //    char[] expected = {'1', '+', '1'};
        //    char[] actual = expressed.splitExpressionString(expressed.expression_as_string);

        //    CollectionAssert.AreEquivalent(expected, actual);
        //}
        //[TestMethod]
        //public void ExpressionDoesNotSplit()
        //{
        //    //Going down a failed path to split the string array
        //    Expression expressed = new Expression("1+1");
        //    string expected = "1+1";
        //    expressed.splitExpressionString(expressed.expression_as_string);
        //    string actual = expressed.expression_as_array[0]; 

        //    Assert.AreSame(expected, actual);
        //}
        //[TestMethod]
        //public void ExpressionCharArrayDisassembledFurther()
        //{
        //    Expression expressed = new Expression("10+20");
        //    char[] expected = { '1','0', '+', '2','0' };
        //    char[] actual = expressed.splitExpressionString(expressed.expression_as_string);

        //    CollectionAssert.AreEquivalent(expected, actual);
        //}
        //[TestMethod]
        //public void ExpressionParseOperandThrowsException()
        //{
        //    Expression expressed = new Expression("11+22");
        //    expressed.splitExpressionString(expressed.expression_as_string);
        //    char[] charArray = { '1', '1', '+', '2', '2' };
        //    Int32.Parse(charArray[0].ToString());
        //}
        //[TestMethod]
        //public void ExpressionConverCharArrayTo3StringArray()
        //{
        //    Expression expressed = new Expression("11+22");
        //    expressed.splitExpressionString(expressed.expression_as_string); //"11+22"
        //    string[] expressionArray = { "11", "+", "22" };
        //    int expected = 11;
        //            Int32.Parse(expected[0]);
        //Assert.AreEqual(expected[0], 11);
    //}
    //[TestMethod]
    //public void ExpressionConvertCharArrayToListReturnsList()
    //{
    //    Expression expressed = new Expression("111+222");
    //    List<string> actual = expressed.ConvertExpressionToList(expressed.expression_as_char_array);
    //    Assert.IsInstanceOfType(actual, typeof(List<string>));
    //}
    //[TestMethod]
    //public void ExpressionListReturnsLHSinList()
    //{
    //    Expression expressed = new Expression("11+22");
    //    string expected = "11";
    //    List<string> LHS = expressed.ConvertExpressionToList(expressed.expression_as_char_array);
    //    string actual = LHS[0];
    //    Assert.AreEqual(expected, actual);
    //}
    //[TestMethod]
    //public void ExpressionFindOperand()
    //{
    //    char[] expressionCharArray = { '1', '2', '3', '+', '4', '5' };
    //    int operand = Array.IndexOf(expressionCharArray, '+');
    //    int expected = 3;
    //    int actual = operand;
    //    Assert.IsTrue(expected == actual);
    //}
    //[TestMethod]
    //public void ExpressionException()
    //{
    //    Expression expressed = new Expression("111+222");
    //    expressed.ConvertExpressionToList(expressed.expression_as_char_array);
    //    expressed.GetLHSFromExpressionList(expressed.expression_as_list);
    //}
    //[TestMethod]
    //public void ExpressionCannotUseBinarySearchMethod()
    //{
    //    //Expression expressed = new Expression("100+200");
    //    List<string> test = new List<string> { "1", "2", "+", "2" };
    //    int index = test.BinarySearch("+");
    //    Assert.AreNotEqual(2, index);
    //}
    //[TestMethod]
    //public void ExpressionConcatenatedListReturnedLHSRHSOperator()
    //{
    //    Expression expressed = new Expression("135-400");
    //    expressed.ConvertExpressionToList(expressed.expression_as_char_array);
    //    expressed.CreateConcatenatedList(expressed.expression_as_list);
    //    List<string> Expected = new List<string> { "135", "-", "400" };
    //    CollectionAssert.AreEqual(Expected, expressed.expression_list);
    //    CollectionAssert.AreEquivalent(Expected, expressed.expression_list);

    //}
