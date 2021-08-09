using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineShopWebApp.Examples;

namespace OnlineShopWebAppTests
{
    [TestClass]
    public class ExampleTests
    {
        [TestMethod]
        public void Sum_10and20_30()
        {
            //arrange настройка
            int x = 10;
            int y = 20;
            int expected = 30;

            //act выполнить действия
            Example example = new Example();
            int actual = example.Sum(x, y);

            //assert результат
            Assert.AreEqual(expected, actual);
        }
        //[TestMethod]
        //public void Multiply_10and20_200()
        //{
        //    //arrange настройка
        //    int x = 10;
        //    int y = 20;
        //    int expected = 200;

        //    //act выполнить действия
        //    Example example = new Example();
        //    int actual = example.Multiply(x, y);

        //    //assert результат
        //    Assert.AreEqual(expected, actual);
        //}
    }
}
