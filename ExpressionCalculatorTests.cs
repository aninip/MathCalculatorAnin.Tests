using MathCalculatorAnin.Calculations;
using MathCalculatorAnin.Parsers;

namespace MathCalculatorAnin.Tests
{
    public class ExpressionCalculatorTests
    {
        [Fact]
        public void Calculate_AdditionOfTwoNumbers()
        {
            var calculator = new ExpressionCalculator();
            var expression = new List<string> { "1", "+", "2" };

            // Act
            var result = calculator.Calculate(expression);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void Calculate_SubtractionOfTwoNumbers()
        {
            var calculator = new ExpressionCalculator();
            var expression = new List<string> { "5", "-", "3" };

            // Act
            var result = calculator.Calculate(expression);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Calculate_MultiplicationOfTwoNumbers()
        {
            var calculator = new ExpressionCalculator();
            var expression = new List<string> { "4", "*", "3" };

            // Act
            var result = calculator.Calculate(expression);

            // Assert
            Assert.Equal(12, result);
        }

        [Fact]
        public void Calculate_DivisionOfTwoNumbers()
        {
            var calculator = new ExpressionCalculator();
            var expression = new List<string> { "8", "/", "2" };

            // Act
            var result = calculator.Calculate(expression);

            // Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void Calculate_CombinedOperations()
        {
            var calculator = new ExpressionCalculator();
            var expression = new List<string> { "1", "+", "2", "*", "3", "-", "4", "/", "2" };

            // Act
            var result = calculator.Calculate(expression);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void Calculate_ExpressionWithParentheses()
        {
            var calculator = new ExpressionCalculator();
            var expression = new List<string> { "(", "1", "+", "2", ")", "*", "(", "3", "-", "1", ")" };

            // Act
            var result = calculator.Calculate(expression);

            // Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void Calculate_ExpressionWithDecimals()
        {
            var calculator = new ExpressionCalculator();
            var expression = new List<string> { "5,5", "+", "2,3" };

            // Act
            var result = calculator.Calculate(expression);

            // Assert
            Assert.Equal(7.8, result, 1);
        }

        [Fact]
        public void Calculate_DivisionByZero()
        {
            var calculator = new ExpressionCalculator();
            var expression = new List<string> { "4", "/", "0" };

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => calculator.Calculate(expression));
        }

        [Fact]
        public void Calculate_EmptyExpression_ThrowsArgumentException()
        {
            var calculator = new ExpressionCalculator();
            var expression = new List<string>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => calculator.Calculate(expression));
        }

        [Fact]
        public void Calculate_InvalidExpression_ThrowsFormatException()
        {
            var calculator = new ExpressionCalculator();
            var expression = new List<string> { "1", "+", "+", "2" };

            // Act & Assert
            Assert.Throws<FormatException>(() => calculator.Calculate(expression));
        }

        [Fact]
        public void Tokenize_DecimalNumbers_ReturnsCorrectTokens()
        {
            var parser = new ExpressionParser();
            var expression = "5.5 + 2.3";

            // Act
            var tokens = parser.Tokenize(expression);

            // Assert
            Assert.Equal(new List<string> { "5,5", "+", "2,3" }, tokens);
        }
        [Fact]
        public void Tokenize_ComplexExpression_ReturnsCorrectTokens()
        {
            // Arrange
            var parser = new ExpressionParser();
            string expression = "3.5 + (-2) * (4 - 1) / -0.5";

            // Act
            List<string> tokens = parser.Tokenize(expression);

            // Assert
            var expectedTokens = new List<string>
            {
            "3,5", "+", "(", "-2", ")", "*", "(", "4", "-", "1", ")", "/", "-0,5"
            };

            Assert.Equal(expectedTokens, tokens);
        }
    }
}
