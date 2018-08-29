using Prism.Mvvm;
using System.Collections.Generic;

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
