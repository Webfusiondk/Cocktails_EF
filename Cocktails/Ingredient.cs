using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cocktails
{
    public abstract class Ingredient
    {
        [Key]
        public string Name { get; set; }
    }
}
