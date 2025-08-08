using System;

namespace Shopping
{
    class ShoppingCart
    {
        private string[] product = new string[20];

        public string AccessProduct(int n)
        {
            return product[n - 1];
        }

        public void AddProduct(int n, string product)
        {
            this.product[n - 1] = product;
        }

        public void Display()
        {
            foreach (var item in product)
            {
                Console.WriteLine($"Product is {item}");
            }
        }
    }

    class Shop
    {
        public static void Run()
        {
            ShoppingCart cart = new ShoppingCart();

            cart.AddProduct(1, "beef");
            cart.AddProduct(2, "onion");
            cart.AddProduct(3, "Mango");
            cart.AddProduct(4, "orange");

            string bag = cart.AccessProduct(1);
            Console.WriteLine(bag);

            cart.Display();
        }
    }

}