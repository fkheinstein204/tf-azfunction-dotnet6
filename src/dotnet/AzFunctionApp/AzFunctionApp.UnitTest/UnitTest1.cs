namespace AzFunctionApp.UnitTest
{
    public class UnitTest1
    {
        [Trait("Category", "Unit")] 
        [Fact]
        public void Test1()
        {
            Assert.Equal(1, 1);  //for pipeline testing purpose
        }
    }
}