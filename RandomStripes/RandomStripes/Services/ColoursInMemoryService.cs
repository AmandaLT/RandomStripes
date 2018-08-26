using RandomStripes.Models;
using RandomStripes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
            new ColourItem{ Name = "Soft peach", ColourData = "#fbe5eb" },
            new ColourItem{ Name = "Apricot", ColourData = "#f7d2ca" },
            new ColourItem{ Name = "Candy floss", ColourData = "#fed6de" },
            new ColourItem{ Name = "Clematis", ColourData = "#dbb1c9" },
            new ColourItem{ Name = "Pale rose", ColourData = "#dba8bb" },
            new ColourItem{ Name = "Fondant", ColourData = "#fc9fbe" },
            new ColourItem{ Name = "Parma violet", ColourData = "#ddd6de" },
            new ColourItem{ Name = "Wisteria", ColourData = "#caafd8" },
            new ColourItem{ Name = "Lavender", ColourData = "#a69fd2" },
            new ColourItem{ Name = "Bluebell", ColourData = "#8f90c9" },
            new ColourItem{ Name = "Violet", ColourData = "#978bb1" },
            new ColourItem{ Name = "Grape", ColourData = "#b67c92" },
            new ColourItem{ Name = "Shrimp", ColourData = "#ff8276" },
            new ColourItem{ Name = "Vintage Peach", ColourData = "#fbb6a3" },
            new ColourItem{ Name = "Blush", ColourData = "#e5a7ad" },
           new ColourItem{ Name = "Boysenberry", ColourData = "#f3569b" },
            new ColourItem{ Name = "Fiesta", ColourData = "#ff53b1" },
            new ColourItem{ Name = "Bright pink", ColourData = "#dd1f69" },
            new ColourItem{ Name = "Pomegranate", ColourData = "#e93f5a" },
            new ColourItem{ Name = "Lipstick", ColourData = "#c41323" },
            new ColourItem{ Name = "Claret", ColourData = "#6a0b1f" },
            new ColourItem{ Name = "Burgundy", ColourData = "#63282e" },
            new ColourItem{ Name = "Raspberry", ColourData = "#df6481" },
            new ColourItem{ Name = "Fuschia Purple", ColourData = "#dc437d" },
            new ColourItem{ Name = "Magenta", ColourData = "#cf68b1" },
             new ColourItem{ Name = "Plum", ColourData = "#97456d" },
            new ColourItem{ Name = "Emperor", ColourData = "#4a2958" },
            new ColourItem{ Name = "Aspen", ColourData = "#7dddc1" },
            new ColourItem{ Name = "Grass green", ColourData = "#92d375" },
            new ColourItem{ Name = "Bright green", ColourData = "#83e986" },
            new ColourItem{ Name = "Spring green", ColourData = "#c3e4b9" },
            new ColourItem{ Name = "Kelly green", ColourData = "#369960" },
            new ColourItem{ Name = "Green", ColourData = "#08834d" },
            new ColourItem{ Name = "Bottle", ColourData = "#26372f" },
            new ColourItem{ Name = "Sage", ColourData = "#84b1aa" },
            new ColourItem{ Name = "Lincoln", ColourData = "#afbba7" },
            new ColourItem{ Name = "Cypress", ColourData = "#8fa387" },
            new ColourItem{ Name = "Khaki", ColourData = "#857d56" },
            new ColourItem{ Name = "Teal", ColourData = "#429991" },
            new ColourItem{ Name = "Duck egg", ColourData = "#c3d7d8" },
            new ColourItem{ Name = "Sherbert", ColourData = "#a6cfef" },
            new ColourItem{ Name = "Cloud blue", ColourData = "#d8ecf5" },
            new ColourItem{ Name = "Turquoise", ColourData = "#60c3da" },
            new ColourItem{ Name = "Empire", ColourData = "#1791c0" },
            new ColourItem{ Name = "Petrol", ColourData = "#3c7789" },
            new ColourItem{ Name = "Storm blue", ColourData = "#7098a2" },
            new ColourItem{ Name = "Denim", ColourData = "#8394ae" },
            new ColourItem{ Name = "Aster", ColourData = "#6094cd" },
            new ColourItem{ Name = "Lobelia", ColourData = "#434b8a" },
            new ColourItem{ Name = "Royal", ColourData = "#273075" },
            new ColourItem{ Name = "Midnight", ColourData = "#202342" },
            new ColourItem{ Name = "White", ColourData = "#ffffff" },
            new ColourItem{ Name = "Cream", ColourData = "#fbf6f0" },
            new ColourItem{ Name = "Pistachio", ColourData = "#cec671" },
            new ColourItem{ Name = "Lime", ColourData = "#d7bf2b" },
            new ColourItem{ Name = "Meadow", ColourData = "#a5ab65" },
            new ColourItem{ Name = "Lemon", ColourData = "#f7f9a1" },
            new ColourItem{ Name = "Citron", ColourData = "#faf081" },
            new ColourItem{ Name = "Saffron", ColourData = "#fbcd77" },
            new ColourItem{ Name = "Buttermilk", ColourData = "#f7eaae" },
            new ColourItem{ Name = "Sunshine", ColourData = "#fbb91d" },
            new ColourItem{ Name = "Mustard", ColourData = "#efc137" },
            new ColourItem{ Name = "Gold", ColourData = "#e1882e" },
            new ColourItem{ Name = "Spice", ColourData = "#de4b18" },
            new ColourItem{ Name = "Jaffa", ColourData = "#ff9041" },
            new ColourItem{ Name = "Tomato", ColourData = "#b23322" },
            new ColourItem{ Name = "Copper", ColourData = "#bf4c31" },
            new ColourItem{ Name = "Matador", ColourData = "#e3181b" },
            new ColourItem{ Name = "Camel", ColourData = "#e3be7a" },
            new ColourItem{ Name = "Mocha", ColourData = "#c6a592" },
            new ColourItem{ Name = "Walnut", ColourData = "#6c4c3f" },
            new ColourItem{ Name = "Dark brown", ColourData = "#3f2723" },
            new ColourItem{ Name = "Stone", ColourData = "#f5ecdf" },
            new ColourItem{ Name = "Parchment", ColourData = "#e7decf" },
            new ColourItem{ Name = "Mushroom", ColourData = "#cec3c1" },
            new ColourItem{ Name = "Silver", ColourData = "#c2c2c2" },
            new ColourItem{ Name = "Grey", ColourData = "#b0b0b2" },
            new ColourItem{ Name = "Graphite", ColourData = "#767674" },
            new ColourItem{ Name = "Black", ColourData = "#0a0a0a" },
        };

        public List<ColourPalette> GetColourPalettes()
        {
            var palettes = new Dictionary<string, List<string>>
            {
                {"Harmony", new List<string>{ "Parma violet", "Aster", "Cloud blue", "Raspberry", "Plum", "Meadow", "Turquoise", "Pale rose", "Lavender", "Violet", "Clematis", "Petrol", "Lime", "Storm blue", "Sage" } },
                {"Flowers", new List<string>{ "Meadow", "Lime", "Citron", "Cream", "Aster", "Sage", "Storm blue", "Petrol", "Parma violet", "Candy floss", "Pale rose", "Magenta", "Raspberry" } },
                {"Coast",  new List<string>{"Aster", "Cloud blue", "Khaki", "Sherbert", "Teal", "Meadow", "Turquoise", "Bluebell", "Grey", "Silver", "Parchment", "Denim", "Camel", "Aspen", "Petrol" } },
                {"Kingfisher", new List<string>{"Lipstick", "Sage", "Parchment", "Saffron", "Gold", "Cloud blue", "Storm blue" }},
                {"Cherry blossom", new List<string>{"Denim", "Aster", "Pale rose", "Cream", "Meadow", "Grape", "Parchment", "Violet", "Raspberry", "Mocha" }},
            };

            var colourPalettes = new List<ColourPalette>();
            foreach (var palette in palettes)
            {
                colourPalettes.Add(new ColourPalette
                {
                    Name = palette.Key,
                    Colours = GetPaletteColourItems(palette.Value)
                });
            }

            return colourPalettes;
        }

        private List<ColourItem> GetPaletteColourItems(List<string> colourNames)
        {
            var paletteColours = new List<ColourItem>();

            paletteColours = colourNames.Select(cn => colours.First(c => c.Name == cn)).ToList();

            return paletteColours;
        }
    }
}
