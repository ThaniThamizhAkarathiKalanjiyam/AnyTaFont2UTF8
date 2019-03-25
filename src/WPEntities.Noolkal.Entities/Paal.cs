using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPEntities.Noolkal.Entities
{
    public class Paal
    {
        private int _PaalId = 0;

        public int PaalId
        {
            get { return _PaalId; }
            set { _PaalId = value; }
        }


        private string _PaalName = "";

        public string PaalName
        {
            get { return _PaalName; }
            set { _PaalName = value; }
        }
        private List<Iyal> _Iyalkal = new List<Iyal>();

        public List<Iyal> Iyalkal
        {
            get { return _Iyalkal; }
            set { _Iyalkal = value; }
        }
    }
}
