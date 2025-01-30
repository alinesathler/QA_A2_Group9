namespace QA_A2_Group9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Products");

            // Instantiate a product object
            Product product1 = null;

            // Create a product with valid values
            try {
                product1 = new Product(5, "Books", 20.00m, 5);
                Console.WriteLine(product1.ToString());

                // Increment the quantity of the product by 5
                try {
                    product1.IncreaseStock(5);
                    Console.WriteLine(product1.ToString());
                } catch (Exception ex) {
                    Console.WriteLine($"Error increasing stock: {ex.Message}");
                }

                // Decrement the quantity of the product by 5
                try {
                    product1.DecreaseStock(5);
                    Console.WriteLine(product1.ToString());
                } catch (Exception ex) {
                    Console.WriteLine($"Error decreasing stock: {ex.Message}");
                }
            } catch (Exception ex) {
                Console.WriteLine($"Error creating product: {ex.Message}");
            }


        }
    }
}