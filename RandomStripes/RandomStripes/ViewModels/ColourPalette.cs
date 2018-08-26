using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomStripes.ViewModels
{
    public class ColourPalette : BindableBase
    {
        public string Name { get; set; }
        public List<ColourItem> Colours { get; set; }
        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }
    }
}
