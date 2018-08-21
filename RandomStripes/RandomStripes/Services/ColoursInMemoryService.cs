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
            return new List<ColourItem>
            {
                new ColourItem{ Name="Soft peach", ColourData = Color.FromHex("fbe5eb")},
                new ColourItem{ Name="Apricot", ColourData = Color.FromHex("f7d2ca")},
                new ColourItem{ Name="Candy floss", ColourData = Color.FromHex("fed6de")},
                new ColourItem{ Name="Clematis", ColourData = Color.FromHex("dbb1c9")},
                new ColourItem{ Name="Pale rose", ColourData = Color.FromHex("dba8bb")},
                new ColourItem{ Name="Fondant", ColourData = Color.FromHex("fc9fbe")},
                new ColourItem{ Name="Parma violet", ColourData = Color.FromHex("ddd6de")},
                new ColourItem{ Name="Wisteria", ColourData = Color.FromHex("caafd8")},
                new ColourItem{ Name="Lavender", ColourData = Color.FromHex("a69fd2")},
                new ColourItem{ Name="Bluebell", ColourData = Color.FromHex("8f90c9")},
                new ColourItem{ Name="Violet", ColourData = Color.FromHex("978bb1")},
                new ColourItem{ Name="Grape", ColourData = Color.FromHex("b67c92")}
            };
        }
    }
}
