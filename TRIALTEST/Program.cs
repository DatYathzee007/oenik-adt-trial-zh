using System;
using TRIALTEST.DbContexts;
using TRIALTEST.Models;
using TRIALTEST.Helpers;
using System.Linq;

namespace TRIALTEST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program Started!");
            var data = new FoodRecipesDbContext();
            Console.WriteLine("Db Connected");

            /*
             a)	How many recipes are in the database? (1.5 points)
            b)	Display the romantic recipes on the console. (1.5 points)
            c)	Arrange the recipes that contain an ingredient called Oil in descending order of price. (4 points)
            d)	If we were to make all the recipes, how much of the ingredients would we need? 
            In the result, display the name of the ingredient and the total amount needed in such a way
                that it appears in ascending order according to the total amount. (3 points)
            e)	Display the contents of the refrigerator on the console. (1 point) 
                Use the value of the DisplayName attribute on the product properties during display! (2.5 points)
             */
            //A
            var resultA = data.Recipes.Count();
                Console.WriteLine("How many Recipes in the database? " + resultA);
            //B
            Console.WriteLine("Display the romantic recipes:");
            foreach (var item in data.Recipes.Where(x=>x.IsRomantic==true))
            {
                    Console.WriteLine(item.ToString());
            }
            //C
            foreach (var item in data.Recipes.Where(x=>x.Ingredients.Any(y=>y.Name == "Olaj")).OrderByDescending(x=>x.Price))
            {
                Console.WriteLine(item.ToString());
            }
            //D
            var resultD = from ingredient in data.Ingredients
                          group ingredient by ingredient.Name into grouped
                          select new
                          {
                              Name = grouped.Key, Amount = grouped.Sum(x=>x.Amount)
                          };
            var resultD2 = data.Ingredients.GroupBy(x=>x.Name).Select(x=> new {Name = x.Key, Amount=x.Sum(x=>x.Amount)});
            foreach (var item in resultD.OrderBy(x=>x.Amount))
            {
                Console.WriteLine("{0} - {1}", item.Name, item.Amount);
            }
            //E
            var frigo = Refigerator.CreateFromXML("frigo.xml");
            Console.WriteLine("XML loaded!");
            Console.WriteLine("Brand: {0}, Capacity: {1}", frigo.Brand, frigo.Capacity);
            foreach (var item in frigo.Products)
            {
                Console.WriteLine("{2}: {0} - {3}:{1}", item.Name, item.Amount, AttributeHelper.GetPropertyDisplayName<Product>(nameof(Product.Name)), AttributeHelper.GetPropertyDisplayName<Product>(nameof(Product.Amount)));
            }
            Console.WriteLine("Finish");
            Console.ReadKey();

        }
    }
}
