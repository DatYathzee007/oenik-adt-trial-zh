using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TRIALTEST.Entities;

namespace TRIALTEST.DbContexts
{
    class FoodRecipesDbContext : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set;}
        public FoodRecipesDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Server = (LocalDB)\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\FoodRecipes.mdf; Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>(
                x => x
                .HasOne(i => i.Recipe)
                .WithMany(i => i.Ingredients)
                .HasForeignKey(i => i.ReceiptId)
                .OnDelete(DeleteBehavior.NoAction)
                );

            var carb = new Recipe() { Id = 1, Name = "Carbonara", Price = 1400 };
            var bolo = new Recipe() { Id = 2, Name = "Bolognese", Price = 900 };
            var gt = new Recipe() { Id = 3, Name = "Semolina pasta", Price = 400, IsRomantic = true };
            var lasa = new Recipe() { Id = 4, Name = "Lasagne", Price = 1600, IsRomantic = true };
            var pk = new Recipe() { Id = 5, Name = "Chicken paprika stew", Price = 700 };
            var lecso = new Recipe() { Id = 6, Name = "Ratatouille", Price = 850 };

            var ingredients = new List<Ingredient>()
            {
                // Carb
                new Ingredient() { Id = 1, Name = "Spagetti pasta", Amount = 1, ReceiptId = carb.Id },
                new Ingredient() { Id = 2, Name = "Egg", Amount = 4, ReceiptId = carb.Id },
                new Ingredient() { Id = 3, Name = "Salt", Amount = 1, ReceiptId = carb.Id },
                new Ingredient() { Id = 4, Name = "Pepper", Amount = 1, ReceiptId = carb.Id },
                new Ingredient() { Id = 5, Name = "Bacon", Amount = 5, ReceiptId = carb.Id },
                // Bolo
                new Ingredient() { Id = 6, Name = "Spagetti pasta", Amount = 1, ReceiptId = bolo.Id },
                new Ingredient() { Id = 7, Name = "Tomato sauce", Amount = 3, ReceiptId = bolo.Id },
                new Ingredient() { Id = 8, Name = "Onion", Amount = 1, ReceiptId = bolo.Id },
                new Ingredient() { Id = 9, Name = "Minced meat", Amount = 1, ReceiptId = bolo.Id },
                new Ingredient() { Id = 10, Name = "Oregano", Amount = 1, ReceiptId = bolo.Id },
                new Ingredient() { Id = 11, Name = "Salt", Amount = 1, ReceiptId = bolo.Id },
                new Ingredient() { Id = 12, Name = "Pepper", Amount = 1, ReceiptId = bolo.Id },
                new Ingredient() { Id = 13, Name = "Oil", Amount = 1, ReceiptId = bolo.Id },
                // Gt
                new Ingredient() { Id = 14, Name = "Sheet pasta", Amount = 2, ReceiptId = gt.Id },
                new Ingredient() { Id = 15, Name = "Semolina flour", Amount = 2, ReceiptId = gt.Id },
                new Ingredient() { Id = 16, Name = "Oil", Amount = 2, ReceiptId = gt.Id },
                new Ingredient() { Id = 17, Name = "Jam", Amount = 1, ReceiptId = gt.Id },
                // Lasa
                new Ingredient() { Id = 18, Name = "Sheet pasta", Amount = 2, ReceiptId = lasa.Id },
                new Ingredient() { Id = 19, Name = "Tomato sauce", Amount = 3, ReceiptId = lasa.Id },
                new Ingredient() { Id = 20, Name = "Onion", Amount = 1, ReceiptId = lasa.Id },
                new Ingredient() { Id = 21, Name = "Minced meat", Amount = 1, ReceiptId = lasa.Id },
                new Ingredient() { Id = 22, Name = "Oregano", Amount = 1, ReceiptId = lasa.Id },
                new Ingredient() { Id = 23, Name = "Salt", Amount = 1, ReceiptId = lasa.Id },
                new Ingredient() { Id = 24, Name = "Pepper", Amount = 1, ReceiptId = lasa.Id },
                new Ingredient() { Id = 25, Name = "Oil", Amount = 1, ReceiptId = lasa.Id },
                new Ingredient() { Id = 26, Name = "Besamel", Amount = 1, ReceiptId = lasa.Id },
                new Ingredient() { Id = 27, Name = "Cheese", Amount = 1, ReceiptId = lasa.Id },
                // PK
                new Ingredient() { Id = 28, Name = "Potato", Amount = 10, ReceiptId = pk.Id },
                new Ingredient() { Id = 29, Name = "Onion", Amount = 1, ReceiptId = pk.Id },
                new Ingredient() { Id = 30, Name = "Sausage", Amount = 2, ReceiptId = pk.Id },
                new Ingredient() { Id = 31, Name = "Paprika", Amount = 1, ReceiptId = pk.Id },
                new Ingredient() { Id = 32, Name = "Salt", Amount = 1, ReceiptId = pk.Id },
                new Ingredient() { Id = 33, Name = "Pepper", Amount = 1, ReceiptId = pk.Id },
                new Ingredient() { Id = 34, Name = "Marjoram", Amount = 1, ReceiptId = pk.Id },
                // Ratatouille
                new Ingredient() { Id = 35, Name = "Paprika", Amount = 6, ReceiptId = lecso.Id },
                new Ingredient() { Id = 36, Name = "Tomato", Amount = 4, ReceiptId = lecso.Id },
                new Ingredient() { Id = 37, Name = "Onion", Amount = 1, ReceiptId = lecso.Id },
                new Ingredient() { Id = 38, Name = "Salt", Amount = 1, ReceiptId = lecso.Id },
                new Ingredient() { Id = 39, Name = "Pepper", Amount = 1, ReceiptId = lecso.Id },
            };

            modelBuilder.Entity<Ingredient>().HasData(ingredients);
            modelBuilder.Entity<Recipe>().HasData(carb, bolo, gt, pk, lecso, lasa);
        }
    }
}
