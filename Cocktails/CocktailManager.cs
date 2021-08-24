using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cocktails
{
    class CocktailManager
    {
        public List<Cocktail> AvailableDrinks()
        {
            //Getting all data from Cocktail table and from ingredient table by a join
            List<Cocktail> cocktails = new List<Cocktail>();
            using (var ctx = new CocktailContext())
            {
                var cocktail = from drink in ctx.DTCocktail
                               join ingredient in ctx.DTIngredient on drink.Id equals ingredient.Id
                               select new { drink.DrinkName, drink.Ingredients };

                //Loop threw all the objects cas it uses the construtor an empty construtor
                foreach (var item in cocktail)
                {
                    //Then loop threw all the ingredients and add them to a temp list and then add the list to cocktails.
                    List<Ingredient> ingredients = new List<Ingredient>();
                    for (int i = 0; i < item.Ingredients.Count; i++)
                    {
                        ingredients.Add(item.Ingredients[i]);
                    }
                    cocktails.Add(new Cocktail(ingredients, item.DrinkName));
                }
            }
            return cocktails;
        }

        public string UpdateCocktail(Cocktail cocktail)
        {
            return null;
        }

        public string RemoveCocktail(string cocktail)
        {
            using (var ctx = new CocktailContext())
            {
                List<Ingredient> itemsToRemove = new List<Ingredient>();
                var drink = ctx.DTCocktail.Single(o => o.DrinkName == cocktail);
                var ingredients = from ing in ctx.DTIngredient where drink.Id == ing.Id select ing;
                foreach (var item in ingredients)
                {
                    itemsToRemove.Add(item);
                }
                ctx.DTIngredient.RemoveRange(itemsToRemove);
                ctx.DTCocktail.Remove(drink);
                ctx.SaveChanges();
            }
            return null;
        }

        public string AddCocktail(Cocktail cocktail)
        {
            //Adds cocktail to the database
            using (var ctx = new CocktailContext())
            {
                ctx.DTCocktail.Add(cocktail);
                ctx.SaveChanges();
            }
            return null;
        }

        public Cocktail AskForCocktail(string cocktail)
        {
            //Gets a drink by a string we send in.
            List<Ingredient> ingredients = new List<Ingredient>();
            string temp = "";
            using (var ctx = new CocktailContext())
            {
                var drink = from item in ctx.DTCocktail
                            where item.DrinkName.ToLower() == cocktail.ToLower()
                            join ingredient in ctx.DTIngredient on item.Id equals ingredient.Id
                            select new { item.DrinkName, item.Ingredients };
                foreach (var item in drink)
                {
                    for (int i = 0; i < item.Ingredients.Count; i++)
                    {
                        ingredients.Add(item.Ingredients[i]);
                    }
                    temp = item.DrinkName;
                }
            }
            return new Cocktail(ingredients, temp);
        }
    }
}
