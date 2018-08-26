using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RandomStripes
{
    public class ApplicationWrapper: IApplicationWrapper
    {
        public IDictionary<string, object> Properties
        {
            get { return Application.Current.Properties; }            
        }
    }
}
