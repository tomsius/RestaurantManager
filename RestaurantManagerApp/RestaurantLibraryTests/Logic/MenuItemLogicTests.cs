using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantLibrary;
using RestaurantLibrary.Logic;
using RestaurantLibrary.Models;
using Smocks;

namespace RestaurantLibraryTests.Logic
{
    [TestClass]
    public class MenuItemLogicTests
    {
        private MenuItemModel GenerateSampleMenuItem()
        {
            string sampleMenuItemName = "Chicked with Fries";
            List<ProductModel> sampleIngredients = GetSampleIngredients();

            MenuItemModel sampleMenuItem = new MenuItemModel(sampleMenuItemName, sampleIngredients);

            return sampleMenuItem;
        }

        private List<ProductModel> GetSampleIngredients()
        {
            List<ProductModel> sampleIngredients = new List<ProductModel>
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
                    PortionSize = 0.9
                }
            };

            return sampleIngredients;
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
                    PortionSize = 0.9
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
        public void Test_GetNotUsedIngredients_ShouldReturnListOf2Items()
        {
            Smock.Run(context =>
            {
                // Arrange
                MenuItemModel menuItem = GenerateSampleMenuItem();
                List<ProductModel> expected = new List<ProductModel>
                {
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
                context.Setup(() => GlobalConfig.Connection.GetAllProducts()).Returns(GenerateSampleProducts());

                // Act
                List<ProductModel> actual = MenuItemLogic.GetNotUsedIngredients(menuItem);

                // Assert
                Assert.AreEqual(expected.Count, actual.Count);
                Assert.AreEqual(expected[0].Name, actual[0].Name);
                Assert.AreEqual(expected[1].Name, actual[1].Name);
            });
        }

        [TestMethod]
        public void Test_GetNotUsedIngredients_ShouldReturnEmptyList()
        {
            Smock.Run(context =>
            {
                // Arrange
                MenuItemModel menuItem = GenerateSampleMenuItem();
                menuItem.Ingredients.Add(new ProductModel {
                                            Id = 102,
                                            Name = "Cheese",
                                            PortionCount = 5,
                                            Unit = "g",
                                            PortionSize = 0.1});
                menuItem.Ingredients.Add(new ProductModel
                                            {
                                                Id = 103,
                                                Name = "Pepsi",
                                                PortionCount = 10,
                                                Unit = "bottles",
                                                PortionSize = 1
                                            });
                context.Setup(() => GlobalConfig.Connection.GetAllProducts()).Returns(GenerateSampleProducts());

                // Act
                List<ProductModel> actual = MenuItemLogic.GetNotUsedIngredients(menuItem);

                // Assert
                Assert.IsTrue(actual.Count == 0);
            });
        }

        [TestMethod]
        public void Test_GetNotUsedIngredients_ShouldThrowException()
        {
            Smock.Run(context =>
            {
                // Arrange
                string expected = "Menu item object can not be null.";
                context.Setup(() => GlobalConfig.Connection.GetAllProducts()).Returns(GenerateSampleProducts());

                try
                {
                    // Act
                    List<ProductModel> actual = MenuItemLogic.GetNotUsedIngredients(null);
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
    }
}
