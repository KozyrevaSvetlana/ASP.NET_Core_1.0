using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Controllers;
using Xunit;

namespace OnlineShop.Db.xUnitTests
{
    public class HomeControllerTests
    {
        private readonly Mock<IProductsRepository> _mockRepo;
        private readonly HomeController _controller;
        public HomeControllerTests()
        {
            _mockRepo = new Mock<IProductsRepository>();
            //_controller = new HomeController(_mockRepo.Object);
        }
        [Fact]
        public void Index_ActionExecutes_ViewForIndex()
        {
            var result = _controller.Index() as ViewResult;
            Assert.IsType<ViewResult>(result);
        }
    }
}
