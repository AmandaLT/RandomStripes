using Prism.Mvvm;

namespace RandomStripes.ViewModels
{
    public class ColourItem : BindableBase
    {
        public string Name { get; set; }
        public string ColourData { get; set; }
        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }
    }
}
