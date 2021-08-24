using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Cocktails
{
    class CocktailContext : DbContext
    {
        public DbSet<Ingredient> DTIngredient { get; set; }
        public DbSet<Cocktail> DTCocktail  { get; set; }
    }
}
