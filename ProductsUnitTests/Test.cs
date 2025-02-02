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
        /// <summary>
        /// Test that creating a product with ID below minimum (5) throws exception
        /// Ensures ProductId lower boundary validation
        /// </summary>
        [TestCase(4)]
        public void Constructor_ProductIdBelowMinimum_ShouldThrowException(int productId)
        {
            // Arrange & Act
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Product(productId, "Test Product", 10m, 50));

            // Assert
            Assert.That(ex.Message, Does.Contain("ProductId is out of the range"));
        }

        /// <summary>
        /// Test that valid ProductId (within 5-50000) creates product successfully
        /// Verifies proper acceptance of valid IDs
        /// </summary>
        [TestCase(100)]
        public void Constructor_ValidProductId_ShouldCreateProduct(int productId)
        {
            // Arrange & Act
            var product = new Product(productId, "Valid Product", 50m, 100);

            // Assert
            Assert.That(product.ToString(), Does.Contain($"Product ID: {productId}"));
        }

        /// <summary>
        /// Test that valid product name creates product without exceptions
        /// Confirms non-empty names are accepted
        /// </summary>
        [TestCase("Valid Product Name")]
        public void Constructor_ValidProductName_ShouldCreateProduct(string productName)
        {
            // Arrange & Act
            var product = new Product(100, productName, 50m, 100);

            // Assert
            Assert.That(product.ToString(), Does.Contain($"Name: {productName}"));
        }

        /// <summary>
        /// Test that valid stock increase updates quantity correctly
        /// Verifies proper inventory management
        /// </summary>
        [Test]
        public void IncreaseStock_ValidAmount_ShouldUpdateQuantity()
        {
            // Arrange
            var product = new Product(100, "Test Product", 50m, 100);

            // Act
            product.IncreaseStock(50);

            // Assert
            Assert.That(product.ToString(), Does.Contain("Quantity: 150"));
        }

        /// <summary>
        /// Test that valid stock decrease updates quantity correctly
        /// Ensures proper inventory deduction
        /// </summary>
        [Test]
        public void DecreaseStock_ValidAmount_ShouldUpdateQuantity()
        {
            // Arrange
            var product = new Product(100, "Test Product", 50m, 100);

            // Act
            product.DecreaseStock(50);

            // Assert
            Assert.That(product.ToString(), Does.Contain("Quantity: 50"));
        }

        /// <summary>
        /// Test that negative decrement amount throws exception
        /// Prevents invalid stock reductions
        /// </summary>
        [TestCase(-5)]
        public void DecreaseStock_NegativeAmount_ShouldThrowException(int amount)
        {
            // Arrange
            var product = new Product(100, "Test Product", 50m, 100);

            // Act & Assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
                product.DecreaseStock(amount));
            Assert.That(ex.Message, Does.Contain("Decrement must be positive."));
        }
        #endregion

        #region Lena Test Section
        ///<summary>
        ///Test that creating a product with a price below the allowed minimum (5) throws an exception
        ///This ensures that price restrictions are respected
        ///</summary>
        ///<param name="price"></param>
        [TestCase(4)]
        public void Constructor_PriceUnderMinimum_ShouldThrowException(int price)
        {
            // Arrange
            _product = null;

            // Act
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => {
                _product = new Product(50, "Oranges", price, 75);
            });

            // Assert
            Assert.That(ex.Message, Does.Contain("Price is out of the range"));
        }

        ///<summary>
        ///Test that creating a product with a quantity below the allowed minimum (5) throws an exception
        ///This ensures that quantity restrictions are respected
        ///</summary>
        ///<param name="stock"></param>
        [TestCase(4)]
        public void Constructor_QtyUnderMinimum_ShouldThrowException(int stock) {
            // Arrange
            _product = null;

            // Act
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => {
                _product = new Product(34, "Games console", 400.50m, stock);
            });

            // Assert
            Assert.That(ex.Message, Does.Contain("Quantity is out of the range"));
        }

        ///<summary>
        ///Test that increasing stock by a negative amount throws an exception
        ///This ensures that input is being validated correctly
        ///</summary>
        ///<param name="amount"
        [TestCase(-1)]
        public void IncreaseStock_NegativeIncrease_ShouldThrowException(int amount)
        {
            // Arrange
            _product = new Product(150, "Shoes", 50m, 3500);

            // Act
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => {
                _product.IncreaseStock(amount);
            });

            // Assert
            Assert.That(ex.Message, Does.Contain("Increment must be positive."));
        }

        ///<summary>
        ///Test that creating a product with a null name throws an exception
        ///This ensures that input is being validated correctly
        ///</summary>
        ///<param name="productName"></param>
        [TestCase("")]
        public void Constructor_ProductNameNull_ShouldThrowException(string productName)
        {
            // Arrange
            _product = null;

            // Act
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => {
                _product = new Product(700, productName, 9.99m, 40);
            });

            // Assert
            Assert.That(ex.Message, Does.Contain("Product Name cannot be null or empty"));
        }
        ///<summary>
        ///Test that creating a product with a valid price does not throw an exception
        ///</summary>
        ///<param name="price"
        [TestCase(50)]
        public void Constructor_ValidPrice_ShouldNotThrowException(int price)
        {
            // Arrange
            _product = null;

            // Act
            
                _product = new Product(50, "Oranges", price, 75);
           

            // Assert
            Assert.That(_product!=null&&price>5&&price<50000);
        }
        ///<summary>
        ///Test that creating a product with a valid quantity does not throw an exception
        ///</summary>
        ///<param name="price"
        [TestCase(700)]
        public void Constructor_ValidQuantity_ShouldNotThrowException(int quantity)
        {
            // Arrange
            _product = null;

            // Act

            _product = new Product(50, "Oranges", 100, quantity);


            // Assert
            Assert.That(_product != null && quantity > 5 && quantity < 50000);
        }
        #endregion
    }
}