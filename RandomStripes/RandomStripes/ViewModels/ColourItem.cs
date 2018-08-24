using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RandomStripes.ViewModels
{
    public class ColourItem : BindableBase
    {
        public string Name { get; set; }
        //public Color ColourData { get; set; }
        public string ColourData { get; set; }

        private bool _isSelected;
        public bool IsSelected { get { return _isSelected; } set { SetProperty(ref _isSelected, value); } }
    }
}
