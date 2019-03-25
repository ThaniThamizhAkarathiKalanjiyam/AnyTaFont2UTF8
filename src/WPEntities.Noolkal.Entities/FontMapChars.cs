using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPEntities.Noolkal.Entities
{
    public class FontMapChars
    {
        string taChar;

        public string TaChar
        {
            get { return taChar; }
            set { taChar = value; }
        }

        string taCharUtf8;

        public string TaCharUtf8
        {
            get { return taCharUtf8; }
            set { taCharUtf8 = value; }
        }
    }
}
