namespace CRUDTests
{
    public class UnitTest1
    {
        [Fact] 
        public void Test1()
        {
            //Arrange
            MyMath myMath = new MyMath();
            int a = 10;
            int b = 20;
            int expected = 30;

            //Act
            int actual = myMath.Add(a, b);


            //Assert
            Assert.Equal(expected, actual);
        }
    }
}