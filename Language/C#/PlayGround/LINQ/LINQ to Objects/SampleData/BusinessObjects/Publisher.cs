using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LinqInAction.LinqBooks.Common
{
    public class Publisher
    {
        public String Name { get; set; }
        public Bitmap Logo { get; set; }
        public String WebSite { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
