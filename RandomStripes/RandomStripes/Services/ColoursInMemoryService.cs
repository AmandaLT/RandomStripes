using RandomStripes.Models;
using RandomStripes.ViewModels;
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
                new ColourItem{ Name="Soft peach", ColourData = "#fbe5eb"},
                new ColourItem{ Name= "Apricot", ColourData = "#f7d2ca"},
                new ColourItem{ Name= "Candy floss", ColourData = "#fed6de"},
                new ColourItem{ Name= "Clematis", ColourData = "#dbb1c9"},
                new ColourItem{ Name= "Pale rose", ColourData = "#dba8bb"},
                new ColourItem{ Name= "Fondant", ColourData = "#fc9fbe"},
                new ColourItem{ Name= "Parma violet", ColourData = "#ddd6de"},
                new ColourItem{ Name= "Wisteria", ColourData = "#caafd8"},
                new ColourItem{ Name= "Lavender", ColourData = "#a69fd2"},
                new ColourItem{ Name= "Bluebell", ColourData = "#8f90c9"},
                new ColourItem{ Name= "Violet", ColourData = "#978bb1"},
                new ColourItem{ Name= "Grape", ColourData = "#b67c92"},
                new ColourItem{ Name= "Duck egg", ColourData = "#c3d7d8"},
                new ColourItem{ Name= "Sherbert", ColourData = "#a6cfef"},
                new ColourItem{ Name= "Cloud blue", ColourData = "#d8ecf5"},
                new ColourItem{ Name= "Turquoise", ColourData = "#60c3da"},
                new ColourItem{ Name= "Empire", ColourData = "#1791c0"},
                new ColourItem{ Name= "Petrol", ColourData = "#3c7789"},
                new ColourItem{ Name= "Storm blue", ColourData = "#7098a2"},
                new ColourItem{ Name= "Denim", ColourData = "#8394ae"},
                new ColourItem{ Name= "Aster", ColourData = "#6094cd"},
                new ColourItem{ Name= "Lobelia", ColourData = "#434b8a"},
                new ColourItem{ Name= "Royal", ColourData = "#273075"},
                new ColourItem{ Name= "Midnight", ColourData = "#202342"},
                new ColourItem{ Name= "Jaffa", ColourData = "#ff9041"},
                new ColourItem{ Name= "Tomato", ColourData = "#b23322"},
                new ColourItem{ Name= "Copper", ColourData = "#bf4c31"},
                new ColourItem{ Name= "Matador", ColourData = "#e3181b"},
                new ColourItem{ Name= "Camel", ColourData = "#e3be7a"},
                new ColourItem{ Name= "Mocha", ColourData = "#c6a592"},
                new ColourItem{ Name= "Walnut", ColourData = "#6c4c3f"},
                new ColourItem{ Name= "Dark brown", ColourData = "#3f2723"},
                new ColourItem{ Name= "Stone", ColourData = "#f5ecdf"},
                new ColourItem{ Name= "Parchment", ColourData = "#e7decf"},
                new ColourItem{ Name= "Mushroom", ColourData = "#cec3c1"},
                new ColourItem{ Name= "Silver", ColourData = "#c2c2c2"},
                new ColourItem{ Name= "Grey", ColourData = "#b0b0b2"},
                new ColourItem{ Name= "Graphite", ColourData = "#767674"}
            };
        
    }
}
