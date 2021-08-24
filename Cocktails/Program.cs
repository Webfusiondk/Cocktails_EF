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
            ChoseIngredients();
            Console.WriteLine("Done");
            Console.ReadKey();
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
            string temp = "";
            for (int i = 0; i < ingredients.Count; i++)
            {
                if (ingredients[i] is Liquid)
                {
                    temp += ingredients[i].Name + " " + ((Liquid)ingredients[i]).Ammount +" Ml" + "\n";
                }
                else
                    temp += ingredients[i].Name.Replace("_", " ") + "\n";
            }
            return temp;
        }
        private static Ingredient MatchCondiment(string liquid)
        {
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
