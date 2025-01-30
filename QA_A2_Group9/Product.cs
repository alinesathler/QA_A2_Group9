using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_A2_Group9
{
    public class Product
    {
        #region Properties
        int productId;
        string productName;
        decimal price;
        int quantity;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for the Product class
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productName"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public Product(int productId, string productName, decimal price,int quantity)
        {
            // Check if the product ID is within the range of 5 to 50000
            if (productId < 5 || productId > 50000) {
                throw new ArgumentOutOfRangeException("", "ProductId is out of the range");
            }

            // Check if the product name is null or empty
            if (string.IsNullOrWhiteSpace(productName)) {
                throw new ArgumentNullException("", "Product Name cannot be null or empty");
            }

            // Check if the price is within the range of 5 to 5000
            if (price < 5 || price > 5000) {
                throw new ArgumentOutOfRangeException("", "Price is out of the range");
            }

            // Check if the quantity is within the range of 5 to 500000
            if (quantity < 5 || quantity > 500000) {
                throw new ArgumentOutOfRangeException("", "Quantity is out of the range");
            }

            this.productId = productId;
            this.productName = productName;
            this.price = price;
            this.quantity = quantity;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Output the product details
        /// </summary>
        /// <returns>String with product details</returns>
        public override string ToString() { return $"Product ID: {this.productId}, Name: {this.productName}, Price: {this.price.ToString("C")}, Quantity: {this.quantity}"; }

        /// <summary>
        /// Increment the quantity of the product by qty
        /// </summary>
        /// <param name="qty"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void IncreaseStock(int qty) {
            if (qty < 0) {
                throw new ArgumentOutOfRangeException("", "Increment must be positive.");
            }

            if (this.quantity + qty > 500000) {
                throw new ArgumentOutOfRangeException("", "Quantity cannot be above 500000.");
            }

            this.quantity += qty;
        }

        /// <summary>
        /// Decrement the quantity of the product by qty
        /// </summary>
        /// <param name="qty"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void DecreaseStock(int qty) {
            if (qty < 0) {
                throw new ArgumentOutOfRangeException("", "Decrement must be positive.");
            }
            if (this.quantity - qty < 5) {
                throw new ArgumentOutOfRangeException("", "Quantity cannot be below 5.");
            }

            this.quantity -= qty;
        }
        #endregion
    }
}
