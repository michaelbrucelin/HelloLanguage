using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Tools.Excel;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace ExcelWorkbook0
{
    public static class BasicHelper
    {
        public static Excel.Application ExcelApp;
        public static Office.CommandBar cmdbar;
        //这个是最重要的一个对象
        public static Microsoft.Office.Tools.ActionsPane actpane;
    }
}
