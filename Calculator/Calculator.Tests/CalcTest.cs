namespace Calculator.Tests
{
    public class CalcTest
    {
        [Fact]
        public void Sum_2_and_3_results_5()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(2, 3);

            //Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void Sum_0_and_0_results_0()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(0, 0);

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        public void Sum_MAX_and_1_throws_OverflowException()
        {
            var calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(int.MaxValue, 1));
        }


        [Theory]
        [Trait("Category", "UnitTest")]
        [Trait("Soﬂe", "Senf")]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 2)]
        [InlineData(450, 120, 570)]
        [InlineData(-10, -15, -25)]
        public void Sum_Tests(int a, int b, int exp)
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(a, b);

            //Assert
            Assert.Equal(exp, result);
        }
    }
}