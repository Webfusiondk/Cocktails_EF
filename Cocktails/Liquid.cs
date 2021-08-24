using System;
using System.Collections.Generic;
using System.Text;

namespace Cocktails
{
    enum LiquidType
    {
        Vodka,
        Water,
        Orange_Juice,
        Lime_Juice,
        Tequila,
        Triple_Sec,
        Kahlua,
        Fresh_Cream,
        Dark_Rum,
        Tomato_Juice,
        Soda,
        Pineapple_Juice,
        White_Rum,
        Coconut_Cream,
        Cola,
        Grapefruit_Juice,
        Cranberry_Juic
    }
    class Liquid : Ingredient
    {
        public Liquid()
        {
        }

        public Liquid(LiquidType liquidType, float ammount)
        {
            Name = liquidType.ToString();
            LiquidType = liquidType;
            Ammount = ammount;
        }

        public LiquidType LiquidType { get; set; }
        public float Ammount { get; set; }
    }
}
