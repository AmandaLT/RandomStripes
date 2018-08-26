using Newtonsoft.Json;
using RandomStripes.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;

namespace RandomStripes.Services
{
    public class AppDataService : IAppDataService
     {
        private IApplicationWrapper _applicationWrapper;

        public AppDataService(IApplicationWrapper applicationWrapper)
        {
            _applicationWrapper = applicationWrapper;
        }

        public int RowCount
        {
            get
            {
                object rowObject;
                var hasRowCount = _applicationWrapper.Properties.TryGetValue("RowCount", out rowObject);
                var row = hasRowCount ? rowObject.ToString() : "0";
                return int.Parse(row);
            }
            set
            {
                _applicationWrapper.Properties["RowCount"] = value;
                Application.Current.SavePropertiesAsync();
            }
        }

        public List<int> RowHeights
        {
            get
            {
                object rowHeightsObject;
                var hasRowCount = _applicationWrapper.Properties.TryGetValue("RowHeights", out rowHeightsObject);
                var rowHeights = hasRowCount ? JsonConvert.DeserializeObject<List<int>>(rowHeightsObject.ToString()) : new List<int>();
                return rowHeights;
            }
            set
            {
                _applicationWrapper.Properties["RowHeights"] = JsonConvert.SerializeObject(value);
                Application.Current.SavePropertiesAsync();
            }
        }

        public List<ColourItem> SelectedColours
        {
            get
            {
                object coloursObject;
                var hasSelectedColours = _applicationWrapper.Properties.TryGetValue("SelectedColours", out coloursObject);
                var colours = hasSelectedColours ? JsonConvert.DeserializeObject<List<ColourItem>>(coloursObject.ToString()) : new List<ColourItem>();
                return colours;
            }
            set
            {
                Application.Current.Properties["SelectedColours"] = JsonConvert.SerializeObject(value);
                Application.Current.SavePropertiesAsync();
            }
        }
    }
}
