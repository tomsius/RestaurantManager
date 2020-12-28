using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantLibrary;
using RestaurantLibrary.Models;
using Smocks;

namespace RestaurantLibraryTests
{
    [TestClass]
    public class StockLogicTests
    {
        private List<ProductModel> GenerateSampleProducts()
        {
            List<ProductModel> sampleProducts = new List<ProductModel>
            {
                new ProductModel{
                    Id = 100,
                    Name = "Potatoes",
                    PortionCount = 2,
                    Unit = "kg",
                    PortionSize = 0.7
                },
                new ProductModel{
                    Id = 101,
                    Name = "Tomatoes",
                    PortionCount = 0,
                    Unit = "kg",
                    PortionSize = 0.4
                },
                new ProductModel{
                    Id = 102,
                    Name = "Cheese",
                    PortionCount = 5,
                    Unit = "g",
                    PortionSize = 0.1
                },
                new ProductModel{
                    Id = 103,
                    Name = "Pepsi",
                    PortionCount = 10,
                    Unit = "bottles",
                    PortionSize = 1
                },
            };

            return sampleProducts;
        }

        [TestMethod]
        public void Test_IsProductInStock_ShouldReturnTrue()
        {
            Smock.Run(context =>
            {
                // Arrange
                int productId = 100;
                context.Setup(() => GlobalConfig.Connection.GetAllProducts()).Returns(GenerateSampleProducts());

                // Act
                bool isInStock = StockLogic.IsProductInStock(productId);

                // Assert
                Assert.IsTrue(isInStock);
            });
        }

        [TestMethod]
        public void Test_IsProductInStock_ShouldReturnFalse()
        {
            Smock.Run(context =>
            {
                // Arrange
                int productId = 101;
                context.Setup(() => GlobalConfig.Connection.GetAllProducts()).Returns(GenerateSampleProducts());

                // Act
                bool isInStock = StockLogic.IsProductInStock(productId);

                // Assert
                Assert.IsFalse(isInStock);
            });
        }

        [TestMethod]
        public void Test_IsProductInStock_ShouldThrowArgumentException()
        {
            Smock.Run(context =>
            {
                // Arrange
                int productId = 10;
                string expected = "There is no product with id: " + productId + ".";
                context.Setup(() => GlobalConfig.Connection.GetAllProducts()).Returns(GenerateSampleProducts());

                try
                {
                    // Act
                    bool isInStock = StockLogic.IsProductInStock(productId);

                    // Assert
                    Assert.Fail($"Expected { typeof(ArgumentException).Name }, got none exception.");
                }
                catch (ArgumentException ex)
                {
                    // Assert
                    Assert.AreEqual(expected, ex.Message);
                }
                catch (Exception ex)
                {
                    // Assert
                    Assert.Fail($"Expected { typeof(ArgumentException).Name }, got { ex.GetType().Name }.");
                }
            });
        }

        [TestMethod]
        public void Test_ReduceProductInStock_ShouldReducePortionCountBy1()
        {
            // Arrange
            List<ProductModel> stock = GenerateSampleProducts();
            int productId = 100;
            int expected = stock[0].PortionCount - 1;

            // Act
            StockLogic.ReduceProductInStock(stock, productId);
            int actual = stock[0].PortionCount;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_ReduceProductInStock_ShouldThrowArgumentException()
        {
            // Arrange
            List<ProductModel> stock = GenerateSampleProducts();
            int productId = 10;
            string expected = "There is no product with id: " + productId + ".";

            try
            {
                // Act
                StockLogic.ReduceProductInStock(stock, productId);
                // Assert
                Assert.Fail($"Expected { typeof(ArgumentException).Name }, got none exception.");
            }
            catch (ArgumentException ex)
            {
                // Assert
                Assert.AreEqual(expected, ex.Message);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail($"Expected { typeof(ArgumentException).Name }, got { ex.GetType().Name }.");
            }
        }
    }
}
