using refactor_me.Core.Domain.Models;

namespace refactor_me.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<refactor_me.Persistence.ProductApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(refactor_me.Persistence.ProductApplicationContext context)
        {
            context.Products.AddOrUpdate(
                p => p.Id,
                new Product() { Id = new Guid("8f2e9176-35ee-4f0a-ae55-83023d2db1a3"), Name = "Samsung Galaxy S7", Description = "Newest mobile product from Samsung.", DeliveryPrice = Convert.ToDecimal(1024.99), Price = Convert.ToDecimal(16.99) },
                new Product() { Id = new Guid("de1287c0-4b15-4a7b-9d8a-dd21b3cafec3"), Name = "Apple iPhone 6S", Description = "Newest mobile product from Apple.", DeliveryPrice = Convert.ToDecimal(1299.99), Price = Convert.ToDecimal(15.99) }
            );
            context.ProductOptions.AddOrUpdate(
                po => po.Id,
                new ProductOption() { Name = "White", Description = "White Samsung Galaxy S7", Id = new Guid("0643ccf0-ab00-4862-b3c5-40e2731abcc9"), ProductId = new Guid("8f2e9176-35ee-4f0a-ae55-83023d2db1a3") },
                new ProductOption() { Name = "Black", Description = "Black Samsung Galaxy S7", Id = new Guid("a21d5777-a655-4020-b431-624bb331e9a2"), ProductId = new Guid("8f2e9176-35ee-4f0a-ae55-83023d2db1a3") },
                new ProductOption() { Name = "Rose Gold", Description = "Gold Apple iPhone 6S", Id = new Guid("5c2996ab-54ad-4999-92d2-89245682d534"), ProductId = new Guid("de1287c0-4b15-4a7b-9d8a-dd21b3cafec3") },
                new ProductOption() { Name = "White", Description = "White Apple iPhone 6S", Id = new Guid("9ae6f477-a010-4ec9-b6a8-92a85d6c5f03"), ProductId = new Guid("de1287c0-4b15-4a7b-9d8a-dd21b3cafec3") },
                new ProductOption() { Name = "Black", Description = "Black Apple iPhone 6S", Id = new Guid("4e2bc5f2-699a-4c42-802e-ce4b4d2ac0ef"), ProductId = new Guid("de1287c0-4b15-4a7b-9d8a-dd21b3cafec3") }
                );
            
        }
    }
}
