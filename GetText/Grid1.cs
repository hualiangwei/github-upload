using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unvell.ReoGrid;
using unvell.ReoGrid.IO;

namespace GetText
{
    public class Grid1 : ReoGridControl
    {
        public Grid1()
        {
            CurrentWorksheet.Cells["B1"].Style.HAlign = ReoGridHorAlign.Left;
            CurrentWorksheet.SetSettings( WorksheetSettings.View_AllowCellTextOverflow,false);
        }
        public void Fill(string  data)
        {
            CurrentWorksheet["B1"] = data;
        }
    
    }
}

