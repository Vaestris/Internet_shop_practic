using Internet_shop_practic;
using Internet_shop_practic.Models;
using Internet_shop_practic.Controllers;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace Internet_shop_practic_test
{
    
    public class CheckTest
    {
        [Fact]
        public void Check_TooLongAddress_ReturnsErrormessageNotNull()
        {
            // Arrange
            Check Check = new Check();
            string[] errormessage;
            Order order = new Order();
            order.Address = "123456789_123456789_123456789_123456789_123456789_1";

            // Act
            order = Check.Checking(order,out errormessage);

            // Assert
            Assert.Contains("јдрес слишком длинный", errormessage[1]);

        }
        [Fact]
        public void Check_EmptyAddress_ReturnsErrormessageNotNull()
        {
            // Arrange
            Check Check = new Check();
            string[] errormessage;
            Order order = new Order();
            order.Address = "";

            // Act
            order = Check.Checking(order, out errormessage);

            // Assert
            Assert.Contains("¬ведите адресс", errormessage[1]);
        }
        [Fact]
        public void GetOrder_Order_ReturnsOrder()
        {
            //Arrange
            ValuesController controller = new ValuesController();
            Order order = new Order();
            order.Address = "";
            order.CustomerId = 1;
            order.ProductId = 1;
            Order orderresult = new Order();

            //Act
            var result = controller.GetOrder(order);

            //Assert
            Assert.IsType<JsonResult>(result);
        }
    }
}

