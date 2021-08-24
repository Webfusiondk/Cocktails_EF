using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cocktails
{
    [Table("Cocktail")]
    class Cocktail
    {
        public List<Ingredient> Ingredients { get; set; }
        [Key]
        public int Id { get; set; }
        public string DrinkName { get; set; }
        public Cocktail(List<Ingredient> ingredients, string drinkName)
        {
            Ingredients = ingredients;
            DrinkName = drinkName;
        }

        public Cocktail()
        {

        }
    }
}
