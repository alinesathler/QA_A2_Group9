using QA_A2_Group9;
using System.Diagnostics;

namespace ProductsUnitTests {
    public class Tests {
        private Product _product = null;

        [SetUp]
        public void Setup() {
            // Product object is created in each test method as they're testing the constructor
        }

        #region Aline Test Section
        /// <summary>
        /// Test that creating a product with an ID above the allowed maximum (50000) throws an exception.
        /// This ensures ID's limits are respected.
        /// </summary>
        /// <param name="productId"></param>
        [TestCase(50001)]
        public void Constructor_ProductIdAboveMaximum_ShouldThrowException(int productId) {
            // Arrange
            _product = null;

            // Act
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _product = new Product(productId, "Laptop", 999.99m, 50);
            });

            // Assert
            Assert.That(ex.Message, Does.Contain("ProductId is out of the range"));
        }

        /// <summary>
        /// Test that creating a product with only whitespace as the name throws an exception.
        /// This prevents users from entering empty product names.
        /// </summary>
        /// <param name="productName"></param>
        [TestCase(" ")]
        public void Constructor_ProductNameWhiteSpace_ShouldThrowException(string productName) {
            // Arrange
            _product = null;

            // Act
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => {
                _product = new Product(100, productName, 999.99m, 50);
            });

            // Assert
            Assert.That(ex.Message, Does.Contain("Product Name cannot be null or empty"));
        }

        /// <summary>
        /// Test that creating a product with a price above the maximum (5000) throws an exception.
        /// This ensures prices limits are respected.
        /// </summary>
        /// <param name="price"></param>
        [TestCase(5001)]
        public void Constructor_PriceAboveMaximum_ShouldThrowException(decimal price) {
            // Arrange
            _product = null;

            // Act
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => {
                _product = new Product(100, "Laptop", price, 50);
            });

            // Assert
            Assert.That(ex.Message, Does.Contain("Price is out of the range"));
        }

        /// <summary>
        /// Test that creating a product with a stock amount above the allowed maximum (500000) throws an exception.
        /// This ensures that inventory limits are respected
        /// </summary>
        /// <param name="stockAmount"></param>
        [TestCase(500001)]
        public void Constructor_StockAboveMaximum_ShouldThrowException(int stockAmount) {
            // Arrange
            _product = null;

            // Act
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => {
                _product = new Product(100, "Laptop", 999.99m, stockAmount);
            });

            // Assert
            Assert.That(ex.Message, Does.Contain("Quantity is out of the range"));
        }

        /// <summary>
        /// Test that increasing the stock above the allowed maximum (500000) throws an exception.
        /// This ensures that stock cannot be above inventory limits.
        /// </summary>
        /// <param name="qty"></param>
        [TestCase(1)]
        public void IncreaseStock_AboveMaximum_ShouldThrowException(int qty) {
            // Arrange
            _product = new Product(100, "Laptop", 999.99m, 500000);

            // Act
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => {
                _product.IncreaseStock(qty);
            });

            // Assert
            Assert.That(ex.Message, Does.Contain("Quantity cannot be above 500000."));
        }

        /// <summary>
        /// Test that decreasing stock below the minimum allowed (5) throws an exception.
        /// This ensures that stock cannot be below inventory limits.
        /// </summary>
        /// <param name="amount"></param>
        [TestCase(1)]
        public void DecreaseStock_BelowMinimum_ShouldThrowException(int amount) {
            // Arrange
            _product = new Product(100, "Laptop", 999.99m, 5);

            // Act
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => {
                _product.DecreaseStock(amount);
            });

            // Assert
            Assert.That(ex.Message, Does.Contain("Quantity cannot be below 5."));
        }
        #endregion

        #region Jahanvi Test Section
        #endregion

        #region Lena Test Section
        #endregion
    }
}