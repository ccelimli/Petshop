using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entites.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();
            /*User user = new User() {FirstName="Çağatay",Id=2,LastName="Çelimli",Email="c.celimli@live.co.uk",Password="123456" };
            UserManager userManager = new UserManager( new UserDal());
            userManager.Add(user);

            Customer customer = new Customer() { UserId=2,Address="74555. sk"}; 
           
            customerManager.Add(customer);
            */
            CustomerManager customerManager = new CustomerManager(new CustomerDal());
            UserManager userManager = new UserManager(new UserDal());


            foreach (var users in userManager.GetAll().Data)
            {
                Console.WriteLine(users.FirstName + " " + users.LastName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new ProductDal());

            Product product1 = new Product() { AnimalId = 2, BrandId = 2, CategoryId = 3, ProductName = "Puppy", UnitPrice = 16, UnitsInStock = 15 };
            productManager.Add(product1);

            if (productManager.GetProductDetails().Success)
            {
                foreach (var product in productManager.GetProductDetails().Data)
                {
                    Console.WriteLine(product.ProductName + " / " + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(productManager.GetProductDetails().Message);
            }
        }
    }
}
