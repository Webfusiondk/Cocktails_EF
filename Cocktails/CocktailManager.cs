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

        public string UpdateCocktail(string name,Cocktail cocktail)
        {
            using (var ctx = new CocktailContext())
            {
                Cocktail drink = GetDrinkByName(name);
                if (drink != null)
                {
                    foreach (var ingredient in drink.Ingredients)
                    {
                        drink.Ingredients.Remove(ingredient);
                    }
                    foreach (var ingredient in cocktail.Ingredients)
                    {
                        drink.Ingredients.Add(ingredient);
                    }
                    drink.DrinkName = cocktail.DrinkName;
                    ctx.DTCocktail.Add(drink);
                    ctx.SaveChanges();
                    return "The drink is updated";
                }
            }
            return "No drink by that name.";
        }

        public string RemoveCocktail(string cocktail)
        {
            using (var ctx = new CocktailContext())
            {
                var drink = ctx.DTCocktail.Where(l => l.DrinkName == cocktail).FirstOrDefault();
                var ingredients = ctx.DTIngredient.Where(o => cocktail == drink.DrinkName).ToList();
                if (ingredients != null)
                {
                    foreach (var ingredient in ingredients)
                    {
                        ctx.DTIngredient.Remove(ingredient);
                    }
                    ctx.DTCocktail.Remove(drink);
                    ctx.SaveChanges();
                    return "Drink removed from menu card";
                }

            }
            return "No drink by that name";
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
            Cocktail drink = GetDrinkByName(cocktail);
            if (drink != null)
            {
                return drink;
            }
            return null;
        }

        public Cocktail GetDrinkByName(string name)
        {
            //Gets a drink by a string we send in.
            List<Ingredient> ingredients = new List<Ingredient>();
            string temp = "";
            using (var ctx = new CocktailContext())
            {
                var drink = from item in ctx.DTCocktail
                            where item.DrinkName.ToLower() == name.ToLower()
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
