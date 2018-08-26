using RandomStripes.Models;
using RandomStripes.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomStripes.Services
{
    public interface IColoursService
    {
        List<ColourItem> GetColours();
        List<ColourPalette> GetColourPalettes();
    }
}
