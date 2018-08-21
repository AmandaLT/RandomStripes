using Prism.Commands;
using Prism.Mvvm;
using RandomStripes.Models;
using RandomStripes.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomStripes.ViewModels
{
	public class CustomColourSelectPageViewModel : BindableBase
	{
        private readonly IColoursService _coloursService;
        public List<ColourItem> Colours { get; set; }

        public CustomColourSelectPageViewModel(IColoursService coloursService)
        {
            _coloursService = coloursService;

            Colours = _coloursService.GetColours();
        }
	}
}
