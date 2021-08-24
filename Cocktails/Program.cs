using System;
using System.Collections.Generic;

namespace Cocktails
{
    class Program
    {
        static List<Ingredient> ingredients;
        static CocktailManager manager = new CocktailManager();
        static void Main(string[] args)
        {
            manager.RemoveCocktail("");
            AskForDrink();
            PrintAllDrinks();
            ChoseIngredients();
            Console.WriteLine("Done");
            Console.ReadKey();
        }

        private static void AskForDrink()
        {
            //By userinput we get a specific drink
            string temp = "";
            Cocktail drink = manager.AskForCocktail(Console.ReadLine().ToLower());
            if (drink != null)
            {
                for (int i = 0; i < drink.Ingredients.Count; i++)
                {
                    temp += drink.Ingredients[i].Name.Replace("_", " ") + "\n";
                }
                Console.WriteLine(drink.DrinkName + "\n" + temp);
            }
            else
                Console.WriteLine("Wrong input");
        }
        private static void PrintAllDrinks()
        {
            //Prints all drinks
            string tempString = "";
            List<Cocktail> temp = manager.AvailableDrinks();
            for (int i = 0; i < temp.Count; i++)
            {
                for (int j = 0; j < temp[i].Ingredients.Count; j++)
                {
                    tempString += temp[i].Ingredients[j].Name.Replace("_", " ") + " ";
                }
                Console.WriteLine(temp[i].DrinkName + " " + tempString);
            }
        }
        private static void ChoseIngredients()
        {
            bool isNotDone = true;
            ingredients = new List<Ingredient>();
            while (isNotDone)
            {
                Console.WriteLine("Type 1 to chose Liquid" + "\n" + "Type 2 to chose Condiments" + "\n" + "When your drink is done type 3");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Chose a Liquid");
                        Console.WriteLine(AllLiquid());
                        Ingredient tempLiquid = MatchLiquid(Console.ReadLine().ToLower());
                        if (tempLiquid == null)
                            break;
                        ingredients.Add(tempLiquid);

                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Chose a Condiment");
                        Console.WriteLine(AllCondiment());
                        Ingredient tempCondiment = MatchCondiment(Console.ReadLine().ToLower());
                        if (tempCondiment == null)
                            break;
                        ingredients.Add(tempCondiment);

                        break;
                    case "3":
                        Console.Clear();
                        isNotDone = false;
                        Console.WriteLine("Name your drink." + "\n" + AllIngredients(ingredients));
                        manager.AddCocktail(new Cocktail(ingredients, Console.ReadLine()));

                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
            }
        }
        private static string AllIngredients(List<Ingredient> ingredients)
        {
            //Makes a string of all ingredients
            string temp = "";
            for (int i = 0; i < ingredients.Count; i++)
            {
                if (ingredients[i] is Liquid)
                {
                    temp += ingredients[i].Name + " " + ((Liquid)ingredients[i]).Ammount + " Ml" + "\n";
                }
                else
                    temp += ingredients[i].Name.Replace("_", " ") + "\n";
            }
            return temp;
        }
        private static Ingredient MatchCondiment(string liquid)
        {
            //Checks if the Ingredient is a condiment
            string[] stringArrya = Enum.GetNames(typeof(CondimentType));
            foreach (var item in stringArrya)
            {
                if (liquid.Replace(" ", "_") == item.ToLower())
                {
                    return new Condiment((CondimentType)Enum.Parse(typeof(CondimentType), item));
                };
            }
            return null;
        }
        private static Ingredient MatchLiquid(string liquid)
        {
            //Checks if the Ingredient is a Liquid
            string[] stringArrya = Enum.GetNames(typeof(LiquidType));
            foreach (var item in stringArrya)
            {
                if (liquid.Replace(" ", "_") == item.ToLower())
                {
                    Console.WriteLine("Insert how meney ML of " + liquid.Replace("_", ""));
                    return new Liquid((LiquidType)Enum.Parse(typeof(LiquidType), item), float.Parse(Console.ReadLine()));
                };
            }
            return null;
        }
        private static string AllLiquid()
        {
            //Makes a string of all liquids
            string[] stringArrya = Enum.GetNames(typeof(LiquidType));
            string temp = "";
            foreach (var item in stringArrya)
            {
                temp += item.ToString().Replace("_", " ") + "\n";
            }
            return temp;
        }
        private static string AllCondiment()
        {
            //Makes a string of all liquids
            string[] stringArrya = Enum.GetNames(typeof(CondimentType));
            string temp = "";
            foreach (var item in stringArrya)
            {
                temp += item.ToString().Replace("_", " ") + "\n";
            }
            return temp;
        }
    }
}
