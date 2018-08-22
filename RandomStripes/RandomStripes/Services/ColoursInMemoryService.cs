using RandomStripes.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RandomStripes.Services
{
    public class ColoursInMemoryService : IColoursService
    {
        public List<ColourItem> GetColours()
        {
            return colours;
        }

        private List<ColourItem> colours = new List<ColourItem>
        {
                new ColourItem{ Name="Soft peach", ColourData = Color.FromHex("fbe5eb")},
                new ColourItem{ Name= "Apricot", ColourData = Color.FromHex("f7d2ca")},
                new ColourItem{ Name= "Candy floss", ColourData = Color.FromHex("fed6de")},
                new ColourItem{ Name= "Clematis", ColourData = Color.FromHex("dbb1c9")},
                new ColourItem{ Name= "Pale rose", ColourData = Color.FromHex("dba8bb")},
                new ColourItem{ Name= "Fondant", ColourData = Color.FromHex("fc9fbe")},
                new ColourItem{ Name= "Parma violet", ColourData = Color.FromHex("ddd6de")},
                new ColourItem{ Name= "Wisteria", ColourData = Color.FromHex("caafd8")},
                new ColourItem{ Name= "Lavender", ColourData = Color.FromHex("a69fd2")},
                new ColourItem{ Name= "Bluebell", ColourData = Color.FromHex("8f90c9")},
                new ColourItem{ Name= "Violet", ColourData = Color.FromHex("978bb1")},
                new ColourItem{ Name= "Grape", ColourData = Color.FromHex("b67c92")},
                new ColourItem{ Name= "Duck egg", ColourData = Color.FromHex("c3d7d8")},
                new ColourItem{ Name= "Sherbert", ColourData = Color.FromHex("a6cfef")},
                new ColourItem{ Name= "Cloud blue", ColourData = Color.FromHex("d8ecf5")},
                new ColourItem{ Name= "Turquoise", ColourData = Color.FromHex("60c3da")},
                new ColourItem{ Name= "Empire", ColourData = Color.FromHex("1791c0")},
                new ColourItem{ Name= "Petrol", ColourData = Color.FromHex("3c7789")},
                new ColourItem{ Name= "Storm blue", ColourData = Color.FromHex("7098a2")},
                new ColourItem{ Name= "Denim", ColourData = Color.FromHex("8394ae")},
                new ColourItem{ Name= "Aster", ColourData = Color.FromHex("6094cd")},
                new ColourItem{ Name= "Lobelia", ColourData = Color.FromHex("434b8a")},
                new ColourItem{ Name= "Royal", ColourData = Color.FromHex("273075")},
                new ColourItem{ Name= "Midnight", ColourData = Color.FromHex("202342")},
                new ColourItem{ Name= "Jaffa", ColourData = Color.FromHex("ff9041")},
                new ColourItem{ Name= "Tomato", ColourData = Color.FromHex("b23322")},
                new ColourItem{ Name= "Copper", ColourData = Color.FromHex("bf4c31")},
                new ColourItem{ Name= "Matador", ColourData = Color.FromHex("e3181b")},
                new ColourItem{ Name= "Camel", ColourData = Color.FromHex("e3be7a")},
                new ColourItem{ Name= "Mocha", ColourData = Color.FromHex("c6a592")},
                new ColourItem{ Name= "Walnut", ColourData = Color.FromHex("6c4c3f")},
                new ColourItem{ Name= "Dark brown", ColourData = Color.FromHex("3f2723")},
                new ColourItem{ Name= "Stone", ColourData = Color.FromHex("f5ecdf")},
                new ColourItem{ Name= "Parchment", ColourData = Color.FromHex("e7decf")},
                new ColourItem{ Name= "Mushroom", ColourData = Color.FromHex("cec3c1")},
                new ColourItem{ Name= "Silver", ColourData = Color.FromHex("c2c2c2")},
                new ColourItem{ Name= "Grey", ColourData = Color.FromHex("b0b0b2")},
                new ColourItem{ Name= "Graphite", ColourData = Color.FromHex("767674")}
            };
        
    }
}
