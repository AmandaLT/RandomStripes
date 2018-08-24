using RandomStripes.Models;
using RandomStripes.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomStripes.Services
{
    public interface IAppDataService
    {
        int RowCount { get; set; }
        List<int> RowHeights { get; set; }
        List<ColourItem> SelectedColours { get; set; }
    }
}
