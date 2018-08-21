using Newtonsoft.Json;
using RandomStripes.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RandomStripes.Services
{
    public class AppDataService : IAppDataService
     {
        //public static PatternDetails PatternDetails
        //{
        //    get
        //    {
        //        var detailsString = Application.Current.Properties["PatternDetails"].ToString();
        //        return JsonConvert.DeserializeObject<PatternDetails>(detailsString);
        //    }
        //    set
        //    {
        //        Application.Current.Properties["PatternDetails"] = JsonConvert.SerializeObject(value);
        //        Application.Current.SavePropertiesAsync();
        //    }
        //}

        public int RowCount
        {
            get
            {
                var rows = Application.Current.Properties["RowCount"].ToString();
                return int.Parse(rows);
            }
            set
            {
                Application.Current.Properties["RowCount"] = value;
                Application.Current.SavePropertiesAsync();
            }
        }

        public List<int> RowHeights
        {
            get
            {
                var heights = Application.Current.Properties["RowHeight"].ToString();
                return JsonConvert.DeserializeObject<List<int>>(heights);
            }
            set
            {
                Application.Current.Properties["RowHeight"] = JsonConvert.SerializeObject(value);
                Application.Current.SavePropertiesAsync();
            }
        }
    }
}
