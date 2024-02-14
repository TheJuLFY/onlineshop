namespace WebAPI.MockFactory.Tests.Data
{
    using System.Collections.Generic;
    using Domain.Models;

    public static class TestEntities
    {
        public static Category CategoryA => new Category() { Name = "CategoryA" };

        public static Category CategoryB => new Category() { Name = "CategoryB" };

        public static Category CategoryC => new Category() { Name = "CategoryC" };

        public static List<Category> AllCategories => new List<Category>() { CategoryA, CategoryB, CategoryC };

        public static Product ProductA => new Product() { Category = CategoryA, Name = "ProductA", Price = 1000000, Tonnage = 10, Region = 0 };

        public static Product ProductB => new Product() { Category = CategoryA, Name = "ProductB", Price = 2000000, Tonnage = 20, Region = 0 };

        public static Product ProductC => new Product() { Category = CategoryA, Name = "ProductC", Price = 3000000, Tonnage = 30, Region = 0 };

        public static List<Product> AllProducts => new List<Product>() { ProductA, ProductB, ProductC };
    }
}
