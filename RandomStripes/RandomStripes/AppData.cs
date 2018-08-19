using Newtonsoft.Json;
using RandomStripes.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RandomStripes
{
    public static class AppData
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

        public static int RowCount
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
    }
}
