using RandomStripes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomStripes.Services
{
    public interface IColoursService
    {
        List<ColourItem> GetColours();
    }
}
