using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cocktails
{
    enum CondimentType
    {
        Crushed_Ice,
        Salt_Rim,
        Lime_Segment,
        Ice_Cubes,
        Celery_Stick,
        Worcestershire_Sauce,
        Mint_Leaves,
        Caster_Sugar,
        Brown_Sugar,
        Pineapple_Segment
    }
    class Condiment : Ingredient
    {
        public Condiment()
        {
        }

        public Condiment(CondimentType condimentType)
        {
            Name = condimentType.ToString();
            CondimentType = condimentType;
        }

        public CondimentType CondimentType { get; set; }
    }
}
