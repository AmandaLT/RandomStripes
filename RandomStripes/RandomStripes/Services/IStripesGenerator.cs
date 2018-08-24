using RandomStripes.Models;
using RandomStripes.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomStripes.Services
{
    public interface IStripesGenerator
    {
        List<ColourItem> GenerateStripes(bool random);
    }
}
