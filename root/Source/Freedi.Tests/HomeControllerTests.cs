using Xunit;
using Freedi.Website.Controllers;
using System.Web.Mvc;

namespace Freedi.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_returns_view()
        {
            var controller = new HomeController();

            var result = controller.Index() as ViewResult;

            Assert.NotNull(result);
        }

        [Fact]
        public void About_sets_message()
        {
            var controller = new HomeController();

            var result = controller.About() as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Your application description page.", result.ViewBag.Message);
        }

        [Fact]
        public void Contact_sets_message()
        {
            var controller = new HomeController();

            var result = controller.Contact() as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Your contact page.", result.ViewBag.Message);
        }
    }
}
