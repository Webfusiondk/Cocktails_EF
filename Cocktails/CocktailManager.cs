using System;
using System.Collections.Generic;
using System.Text;

namespace Cocktails
{
    class CocktailManager
    {
        public List<Cocktail> AvailableDrinks()
        {
            return null;
        }

        public string UpdateCocktail(Cocktail cocktail)
        {
            return null;
        }

        public string RemoveCocktail(Cocktail cocktail)
        {
            return null;
        }

        public string AddCocktail(Cocktail cocktail)
        {
            using (var ctx = new CocktailContext())
            {
                ctx.DTCocktail.Add(cocktail);
                ctx.SaveChanges();
            }
            return null;
        }

        public Cocktail AskForCocktail(Cocktail cocktail)
        {
            return null;
        }
    }
}
