namespace CarDealership.Tests
{
    public class UnitTest1
    {

        int Add(int x, int y) => x + y;

        [Fact]
        public void Adding_Numbers_Should_Return_Sum()
        {
            var result= Add(1, 2);
            Assert.Equal(3, result);
        }
    }
}