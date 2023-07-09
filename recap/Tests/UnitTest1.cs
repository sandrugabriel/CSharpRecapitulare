namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public void Add_WhenCalled_ReturnsCorrectSum()
        {
            // Arrange
            int a = 5;
            int b = 10;
            int expectedSum = 15;

            MathOperations mathOperations = new MathOperations();

            // Act
            int actualSum = mathOperations.Add(a, b);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }

        [Fact]
        public void Subtract_WhenCalled_ReturnsCorrectDifference()
        {
            // Arrange
            int a = 10;
            int b = 5;
            int expectedDifference = 5;

            MathOperations mathOperations = new MathOperations();

            // Act
            int actualDifference = mathOperations.Subtract(a, b);

            // Assert
            Assert.Equal(expectedDifference, actualDifference);
        }

        [Theory]
        [InlineData(5, 2, 10)]
        [InlineData(0, 5, 0)]
        [InlineData(-10, 3, -30)]
        public void Multiply_WhenCalled_ReturnsCorrectProduct(int a, int b, int expectedProduct)
        {
            // Arrange
            MathOperations mathOperations = new MathOperations();

            // Act
            int actualProduct = mathOperations.Multiply(a, b);

            // Assert
            Assert.Equal(expectedProduct, actualProduct);
        }

        [Fact]
        public void Divide_DivisorIsZero_ThrowsDivideByZeroException()
        {
            // Arrange
            int dividend = 10;
            int divisor = 0;

            MathOperations mathOperations = new MathOperations();

            // Act and Assert
            Assert.Throws<DivideByZeroException>(() => mathOperations.Divide(dividend, divisor));
        }
    }

    public class MathOperations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public int Divide(int dividend, int divisor)
        {
            return dividend / divisor;
        }
    }
}
