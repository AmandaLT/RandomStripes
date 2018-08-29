using RandomStripes.Models;
using RandomStripes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomStripes.Services
{
    public class StripesGenerator : IStripesGenerator
    {
        private IAppDataService _appDataService;
        private int _totalRows { get { return _appDataService.RowCount; } }
        private List<ColourItem> _selectedColours { get { return _appDataService.SelectedColours; } }

        public StripesGenerator(IAppDataService appDataService)
        {
            _appDataService = appDataService;
        }

        public List<ColourItem> GenerateStripes(bool randomStripes)
        {
            try
            {
                if (_totalRows <= 0 || !_selectedColours.Any())
                {
                    return new List<ColourItem>();
                }

                if(_selectedColours.Count == 1)
                {
                    return CreateStripesOneColour();
                }

                if (randomStripes)
                {
                    return CreateRandomStripes();
                }
                else
                {                   
                    return CreateOrderedStripes();
                }
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return new List<ColourItem>();
            }
        }

        private List<ColourItem> CreateStripesOneColour()
        {
            var stripes = new List<ColourItem>();
            var colour = _selectedColours[0];
            for (int i = 0; i < _totalRows ; i++)
            {
                stripes.Add(colour);
            }
            return stripes;
        }

        private List<ColourItem> CreateOrderedStripes()
        {
            var stripes = new List<ColourItem>();

            var colourIndex = 0;
            for (int rowIndex = 0; rowIndex < _totalRows; rowIndex++)
            {
                stripes.Add(_selectedColours[colourIndex]);
                if (colourIndex == _selectedColours.Count - 1)
                {
                    colourIndex = 0;
                }
                else
                {
                    colourIndex++;
                }
            }            
            return stripes;
        }

        private List<ColourItem> CreateRandomStripes()
        {
            var stripes = new List<ColourItem>();

            int colourIndexMax = _selectedColours.Count;
            int colourIndex = 0;
            int previousColourIndex = -1;
            var random = new Random();

            for (int rowIndex = 0; rowIndex < _totalRows; rowIndex++)
            {
                // get a random colour
                colourIndex = random.Next(0, colourIndexMax-1);
                if (previousColourIndex != -1)
                {
                    while (colourIndex == previousColourIndex)
                    {
                        // get a new colour
                        colourIndex = random.Next(1, colourIndexMax);
                    }
                }

                stripes.Add(_selectedColours[colourIndex]);
                previousColourIndex = colourIndex;
            }

            return stripes;
        }
    }
}
