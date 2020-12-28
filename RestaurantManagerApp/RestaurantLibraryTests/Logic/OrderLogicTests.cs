using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantLibrary;
using RestaurantLibrary.Models;
using Smocks;
using Smocks.Matching;

namespace RestaurantLibraryTests.Logic
{
    [TestClass]
    public class OrderLogicTests
    {
        private List<MenuItemModel> GenerateSampleMenuItems()
        {
            List<MenuItemModel> sampleMenuItems = new List<MenuItemModel>
            {
                new MenuItemModel("Chicken", new List<ProductModel>{ new ProductModel { Id = 101, Name = "Chicken" } }),
                new MenuItemModel("Chicken with Fries", new List<ProductModel>{ new ProductModel { Id = 101, Name = "Chicken" }, new ProductModel { Id = 100, Name = "Potatoes" } })
            };

            return sampleMenuItems;
        }

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
                    Name = "Chicken",
                    PortionCount = 3,
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
                }
            };

            return sampleProducts;
        }

        [TestMethod]
        public void Test_AreOrderedMenuItemsProductsInStock_ShouldReturnTrue()
        {
            Smock.Run(context =>
            {
                // Arrange
                List<MenuItemModel> orderedMenuItems = GenerateSampleMenuItems();
                context.Setup(() => StockLogic.IsProductInStock(It.IsAny<int>())).Returns(true);

                // Act
                bool areInStock = OrderLogic.AreOrderedMenuItemsProductsInStock(orderedMenuItems);

                // Assert
                Assert.IsTrue(areInStock);
            });
        }

        [TestMethod]
        public void Test_AreOrderedMenuItemsProductsInStock_ShouldReturnFalse()
        {
            Smock.Run(context =>
            {
                // Arrange
                List<MenuItemModel> orderedMenuItems = GenerateSampleMenuItems();
                context.Setup(() => StockLogic.IsProductInStock(It.IsAny<int>())).Returns(false);

                // Act
                bool areInStock = OrderLogic.AreOrderedMenuItemsProductsInStock(orderedMenuItems);

                // Assert
                Assert.IsFalse(areInStock);
            });
        }

        [TestMethod]
        public void Test_AreOrderedMenuItemsProductsInStock_ShouldThrowArgumentException()
        {
            // Arrange
            List<MenuItemModel> orderedMenuItems = new List<MenuItemModel>();
            string expected = "Ordered menu item list can not be empty.";

            try
            {
                // Act
                bool areInStock = OrderLogic.AreOrderedMenuItemsProductsInStock(orderedMenuItems);
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

        [TestMethod]
        public void Test_ReduceProductsInStock_ShouldReduceAllOrderedItemsPortionCountInStock()
        {
            Smock.Run(context =>
            {
                // Arrange
                List<ProductModel> stock = GenerateSampleProducts();
                List<MenuItemModel> orderedMenuItems = GenerateSampleMenuItems();
                List<ProductModel> expected = new List<ProductModel>{
                    new ProductModel{
                        Id = 100,
                        Name = "Potatoes",
                        PortionCount = 1,
                        Unit = "kg",
                        PortionSize = 0.7
                    },
                    new ProductModel{
                        Id = 101,
                        Name = "Chicken",
                        PortionCount = 1,
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
                    }
                };
                context.Setup(() => GlobalConfig.Connection.GetAllProducts()).Returns(stock);
                context.Setup(() => StockLogic.ReduceProductInStock(stock, It.IsAny<int>())).Callback((List<ProductModel> products, int id) =>
                {
                    products.Where(p => p.Id == id).First().PortionCount--;
                });
                context.Setup(() => GlobalConfig.Connection.UpdateProductStock(stock));

                // Act
                OrderLogic.ReduceProductsInStock(orderedMenuItems);

                // Assert
                Assert.AreEqual(expected.Count, stock.Count);
                Assert.AreEqual(expected[0].PortionCount, stock[0].PortionCount);
                Assert.AreEqual(expected[1].PortionCount, stock[1].PortionCount);
                
            });
        }

        [TestMethod]
        public void Test_ReduceProductsInStock_ShouldThrowArgumentException()
        {
            // Arrange
            List<MenuItemModel> orderedMenuItems = new List<MenuItemModel>();
            string expected = "Ordered menu item list can not be empty.";

            try
            {
                // Act
                OrderLogic.ReduceProductsInStock(orderedMenuItems);
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
