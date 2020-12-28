using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantLibrary.Connections;
using RestaurantLibrary.Models;
using Smocks;
using Smocks.Matching;

namespace RestaurantLibraryTests.Connections
{
    [TestClass]
    public class TextFileConnectorTests
    {
        private ProductModel GenerateSampleProduct()
        {
            return new ProductModel { Name = "Apple", PortionCount = 5, Unit = "kg", PortionSize = 1 };
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
                }
            };

            return sampleProducts;
        }

        private MenuItemModel GenerateSampleMenuItem()
        {
            string sampleMenuItemName = "Chicked with Fries";
            List<ProductModel> sampleIngredients = GenerateSampleProducts();

            MenuItemModel sampleMenuItem = new MenuItemModel(sampleMenuItemName, sampleIngredients);

            return sampleMenuItem;
        }

        private List<MenuItemModel> GenerateSampleMenuItems()
        {
            List<MenuItemModel> sampleMenuItems = new List<MenuItemModel>
            {
                new MenuItemModel("Chicken", new List<ProductModel>{ new ProductModel { Id = 101, Name = "Chicken" } }),
                new MenuItemModel("Chicken with Fries", new List<ProductModel>{ new ProductModel { Id = 101, Name = "Chicken" }, new ProductModel { Id = 100, Name = "Potatoes" } })
            };
            sampleMenuItems[0].Id = 100;
            sampleMenuItems[1].Id = 101;

            return sampleMenuItems;
        }

        private OrderModel GenerateSampleOrder()
        {
            return new OrderModel(DateTime.Now, GenerateSampleMenuItems());
        }

        private List<OrderModel> GenerateSampleOrders()
        {
            List<OrderModel> sampleOrder = new List<OrderModel>
            {
                GenerateSampleOrder(),
                GenerateSampleOrder(),
                GenerateSampleOrder()
            };

            return sampleOrder;
        }

        [TestMethod]
        public void Test_CreateProduct_ShouldAddProductToList()
        {
            Smock.Run(context =>
            {
                // Arrange
                TextFileConnector connector = new TextFileConnector();
                ProductModel sampleProdut = GenerateSampleProduct();
                List<ProductModel> stock = GenerateSampleProducts();
                int expected = stock.Count + 1;
                context.Setup(() => TextFileProcessor.GetProductRowsFrom()).Returns(stock);
                context.Setup(() => TextFileProcessor.SaveToProductsFile(stock));

                // Act
                connector.CreateProduct(sampleProdut);

                // Assert
                Assert.IsTrue(stock.Count == expected);
                Assert.AreEqual(stock.Last().Id, sampleProdut.Id);
            });
        }

        [TestMethod]
        public void Test_CreateProduct_ListShouldHaveOneProduct()
        {
            Smock.Run(context =>
            {
                // Arrange
                TextFileConnector connector = new TextFileConnector();
                ProductModel sampleProdut = GenerateSampleProduct();
                List<ProductModel> stock = new List<ProductModel>();
                int expected = 1;
                context.Setup(() => TextFileProcessor.GetProductRowsFrom()).Returns(stock);
                context.Setup(() => TextFileProcessor.SaveToProductsFile(stock));

                // Act
                connector.CreateProduct(sampleProdut);

                // Assert
                Assert.IsTrue(stock.Count == expected);
                Assert.AreEqual(stock.Last().Id, sampleProdut.Id);
            });
        }

        [TestMethod]
        public void Test_CreateProduct_ShouldThrowArgumentException()
        {
            // Arrange
            string expected = "Given product can not be null.";

            // Act
            TextFileConnector connector = new TextFileConnector();
            try
            {
                connector.CreateProduct(null);
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
        public void Test_CreateMenuItem_ShouldAddMenuItemToList()
        {
            Smock.Run(context =>
            {
                // Arrange
                TextFileConnector connector = new TextFileConnector();
                MenuItemModel sampleMenuItem = GenerateSampleMenuItem();
                List<MenuItemModel> menuItems = GenerateSampleMenuItems();
                int expected = menuItems.Count + 1;
                context.Setup(() => TextFileProcessor.GetMenuItemRowsFrom()).Returns(menuItems);
                context.Setup(() => TextFileProcessor.SaveToMenuItemsFile(menuItems));

                // Act
                connector.CreateMenuItem(sampleMenuItem);

                // Assert
                Assert.IsTrue(menuItems.Count == expected);
                Assert.AreEqual(menuItems.Last().Id, sampleMenuItem.Id);
            });
        }

        [TestMethod]
        public void Test_CreateMenuItem_ShouldThrowArgumentException()
        {
            // Arrange
            string expected = "Given menu item can not be null.";

            // Act
            TextFileConnector connector = new TextFileConnector();
            try
            {
                connector.CreateMenuItem(null);
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
        public void Test_CreateMenuItem_ListShouldHaveOneMenuItem()
        {
            Smock.Run(context =>
            {
                // Arrange
                TextFileConnector connector = new TextFileConnector();
                MenuItemModel sampleMenuItem = GenerateSampleMenuItem();
                List<MenuItemModel> menuItems = new List<MenuItemModel>();
                int expected = 1;
                context.Setup(() => TextFileProcessor.GetMenuItemRowsFrom()).Returns(menuItems);
                context.Setup(() => TextFileProcessor.SaveToMenuItemsFile(menuItems));

                // Act
                connector.CreateMenuItem(sampleMenuItem);

                // Assert
                Assert.IsTrue(menuItems.Count == expected);
                Assert.AreEqual(menuItems.Last().Id, sampleMenuItem.Id);
            });
        }

        [TestMethod]
        public void Test_CreateOrder_ShouldAddOrderToList()
        {
            Smock.Run(context =>
            {
                // Arrange
                TextFileConnector connector = new TextFileConnector();
                OrderModel sampleOrder = GenerateSampleOrder();
                List<OrderModel> orders = GenerateSampleOrders();
                int expected = orders.Count + 1;
                context.Setup(() => TextFileProcessor.GetOrderRowsFrom()).Returns(orders);
                context.Setup(() => TextFileProcessor.SaveToOrdersFile(orders));

                // Act
                connector.CreateOrder(sampleOrder);

                // Assert
                Assert.IsTrue(orders.Count == expected);
                Assert.AreEqual(orders.Last().Id, sampleOrder.Id);
            });
        }

        [TestMethod]
        public void Test_CreateOrder_ShouldThrowArgumentException()
        {
            // Arrange
            string expected = "Given order can not be null.";

            // Act
            TextFileConnector connector = new TextFileConnector();
            try
            {
                connector.CreateOrder(null);
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
        public void Test_CreateOrder_ListShouldHaveOneOrder()
        {
            Smock.Run(context =>
            {
                // Arrange
                TextFileConnector connector = new TextFileConnector();
                OrderModel sampleOrder = GenerateSampleOrder();
                List<OrderModel> orders = new List<OrderModel>();
                int expected = 1;
                context.Setup(() => TextFileProcessor.GetOrderRowsFrom()).Returns(orders);
                context.Setup(() => TextFileProcessor.SaveToOrdersFile(orders));

                // Act
                connector.CreateOrder(sampleOrder);

                // Assert
                Assert.IsTrue(orders.Count == expected);
                Assert.AreEqual(orders.Last().Id, sampleOrder.Id);
            });
        }

        [TestMethod]
        public void Test_GetAllProducts_ShouldReturnProductList()
        {
            Smock.Run(context =>
            {
                // Arrange
                TextFileConnector connector = new TextFileConnector();
                List<ProductModel> allProducts = GenerateSampleProducts();
                int expected = allProducts.Count;
                context.Setup(() => TextFileProcessor.GetProductRowsFrom()).Returns(allProducts);

                // Act
                List<ProductModel>  actual = connector.GetAllProducts();

                // Assert
                Assert.IsTrue(allProducts.Count == actual.Count);
            });
        }

        [TestMethod]
        public void Test_GetAllProducts_ShouldReturnEmptyList()
        {
            Smock.Run(context =>
            {
                // Arrange
                TextFileConnector connector = new TextFileConnector();
                List<ProductModel> allProducts = new List<ProductModel>();
                int expected = allProducts.Count;
                context.Setup(() => TextFileProcessor.GetProductRowsFrom()).Returns(allProducts);

                // Act
                List<ProductModel> actual = connector.GetAllProducts();

                // Assert
                Assert.IsTrue(actual.Count == 0);
            });
        }

        [TestMethod]
        public void Test_GetAllMenuItems_ShouldReturnMenuItemList()
        {
            Smock.Run(context =>
            {
                // Arrange
                TextFileConnector connector = new TextFileConnector();
                List<MenuItemModel> allMenuItems = GenerateSampleMenuItems();
                int expected = allMenuItems.Count;
                context.Setup(() => TextFileProcessor.GetMenuItemRowsFrom()).Returns(allMenuItems);

                // Act
                List<MenuItemModel> actual = connector.GetAllMenuItems();

                // Assert
                Assert.IsTrue(allMenuItems.Count == actual.Count);
            });
        }

        [TestMethod]
        public void Test_GetAllMenuItems_ShouldReturnEmptyList()
        {
            Smock.Run(context =>
            {
                // Arrange
                TextFileConnector connector = new TextFileConnector();
                List<MenuItemModel> allMenuItems = new List<MenuItemModel>();
                int expected = allMenuItems.Count;
                context.Setup(() => TextFileProcessor.GetMenuItemRowsFrom()).Returns(allMenuItems);

                // Act
                List<MenuItemModel> actual = connector.GetAllMenuItems();

                // Assert
                Assert.IsTrue(actual.Count == 0);
            });
        }

        [TestMethod]
        public void Test_GetAllOrders_ShouldReturnOrderList()
        {
            Smock.Run(context =>
            {
                // Arrange
                TextFileConnector connector = new TextFileConnector();
                List<OrderModel> allOrders = GenerateSampleOrders();
                int expected = allOrders.Count;
                context.Setup(() => TextFileProcessor.GetOrderRowsFrom()).Returns(allOrders);

                // Act
                List<OrderModel> actual = connector.GetAllOrders();

                // Assert
                Assert.IsTrue(allOrders.Count == actual.Count);
            });
        }

        [TestMethod]
        public void Test_GetAllOrders_ShouldReturnEmptyList()
        {
            Smock.Run(context =>
            {
                // Arrange
                TextFileConnector connector = new TextFileConnector();
                List<OrderModel> allOrders = new List<OrderModel>();
                int expected = allOrders.Count;
                context.Setup(() => TextFileProcessor.GetOrderRowsFrom()).Returns(allOrders);

                // Act
                List<OrderModel> actual = connector.GetAllOrders();

                // Assert
                Assert.IsTrue(actual.Count == 0);
            });
        }

        [TestMethod]
        public void Test_UpdateProduct_ShouldUpdateProductWithNewValues()
        {
            Smock.Run(context =>
            {
                // Arrange
                TextFileConnector connector = new TextFileConnector();
                List<ProductModel> allProducts = GenerateSampleProducts();
                ProductModel newProduct = new ProductModel { Name = "Carrot", PortionCount = 10, Unit = "g", PortionSize = 0.5 };
                int productToUpdateId = 102;
                context.Setup(() => TextFileProcessor.GetProductRowsFrom()).Returns(allProducts);
                context.Setup(() => TextFileProcessor.SaveToProductsFile(allProducts));

                // Act
                connector.UpdateProduct(productToUpdateId, newProduct);

                // Assert
                Assert.AreEqual(allProducts.Where(p => p.Id == productToUpdateId).First().Name, newProduct.Name);
                Assert.AreEqual(allProducts.Where(p => p.Id == productToUpdateId).First().PortionCount, newProduct.PortionCount);
                Assert.AreEqual(allProducts.Where(p => p.Id == productToUpdateId).First().Unit, newProduct.Unit);
                Assert.AreEqual(allProducts.Where(p => p.Id == productToUpdateId).First().PortionSize, newProduct.PortionSize);
            });
        }

        [TestMethod]
        public void Test_UpdateProduct_ShouldNotUpdateAnyProduct()
        {
            Smock.Run(context =>
            {
                // Arrange
                TextFileConnector connector = new TextFileConnector();
                List<ProductModel> allProducts = GenerateSampleProducts();
                ProductModel newProduct = new ProductModel { Name = "TEST", PortionCount = -1, Unit = "TEST", PortionSize = -1 };
                int productToUpdateId = 999;
                context.Setup(() => TextFileProcessor.GetProductRowsFrom()).Returns(allProducts);
                context.Setup(() => TextFileProcessor.SaveToProductsFile(allProducts));

                // Act
                connector.UpdateProduct(productToUpdateId, newProduct);

                // Assert
                foreach (ProductModel product in allProducts)
                {
                    Assert.AreNotEqual(product.Name, newProduct.Name);
                    Assert.AreNotEqual(product.PortionCount, newProduct.PortionCount);
                    Assert.AreNotEqual(product.Unit, newProduct.Unit);
                    Assert.AreNotEqual(product.PortionSize, newProduct.PortionSize);
                }
            });
        }

        [TestMethod]
        public void Test_UpdateProduct_ShouldThrowArgumentException()
        {
            Smock.Run(context =>
            {
                // Arrange
                TextFileConnector connector = new TextFileConnector();
                string expected = "Given new product can not be null.";
                context.Setup(() => TextFileProcessor.GetProductRowsFrom()).Returns(GenerateSampleProducts());
                context.Setup(() => TextFileProcessor.SaveToProductsFile(GenerateSampleProducts()));

                try
                {
                    // Act
                    connector.UpdateProduct(It.IsAny<int>(), null);
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
        public void Test_UpdateMenuItem_ShouldUpdateMenuItemWithNewValues()
        {
            Smock.Run(context =>
            {
                // Arrange
                TextFileConnector connector = new TextFileConnector();
                List<MenuItemModel> allMenuItems = GenerateSampleMenuItems();
                MenuItemModel newMenuItem = new MenuItemModel("SuperDuper", new List<ProductModel> { new ProductModel("Orange", "1", "t", "1") });
                int productToUpdateId = 101;
                context.Setup(() => TextFileProcessor.GetMenuItemRowsFrom()).Returns(allMenuItems);
                context.Setup(() => TextFileProcessor.SaveToMenuItemsFile(allMenuItems));

                // Act
                connector.UpdateMenuItem(productToUpdateId, newMenuItem);

                // Assert
                Assert.AreEqual(allMenuItems.Where(p => p.Id == productToUpdateId).First().Name, newMenuItem.Name);
                Assert.AreEqual(allMenuItems.Where(p => p.Id == productToUpdateId).First().Ingredients.Count, newMenuItem.Ingredients.Count);
                Assert.AreEqual(allMenuItems.Where(p => p.Id == productToUpdateId).First().Ingredients[0].Name, newMenuItem.Ingredients[0].Name);
            });
        }

        [TestMethod]
        public void Test_UpdateMenuItem_ShouldNotUpdateAnyMenuItem()
        {
            Smock.Run(context =>
            {
                // Arrange
                TextFileConnector connector = new TextFileConnector();
                List<MenuItemModel> allMenuItems = GenerateSampleMenuItems();
                MenuItemModel newMenuItem = new MenuItemModel("TEST", new List<ProductModel> { new ProductModel("TEST", "-1", "TEST", "-1") });
                int productToUpdateId = 999;
                context.Setup(() => TextFileProcessor.GetMenuItemRowsFrom()).Returns(allMenuItems);
                context.Setup(() => TextFileProcessor.SaveToMenuItemsFile(allMenuItems));

                // Act
                connector.UpdateMenuItem(productToUpdateId, newMenuItem);

                // Assert
                foreach (MenuItemModel menuItem in allMenuItems)
                {
                    Assert.AreNotEqual(menuItem.Name, newMenuItem.Name);
                    Assert.AreNotEqual(menuItem.Ingredients[0].Name, newMenuItem.Ingredients[0].Name);
                }
            });
        }

        [TestMethod]
        public void Test_UpdateMenuItem_ShouldThrowArgumentException()
        {
            Smock.Run(context =>
            {
                // Arrange
                TextFileConnector connector = new TextFileConnector();
                string expected = "Given new menu item can not be null.";
                context.Setup(() => TextFileProcessor.GetMenuItemRowsFrom()).Returns(GenerateSampleMenuItems());
                context.Setup(() => TextFileProcessor.SaveToMenuItemsFile(GenerateSampleMenuItems()));

                try
                {
                    // Act
                    connector.UpdateMenuItem(It.IsAny<int>(), null);
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
