using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPEntities.Noolkal.Entities
{
    public class Adhikaram
    {
        private int _AdhikaramId = 0;

        public int AdhikaramId
        {
            get { return _AdhikaramId; }
            set { _AdhikaramId = value; }
        }
        private string _AdhikaramName = "";

        public string AdhikaramName
        {
            get { return _AdhikaramName; }
            set { _AdhikaramName = value; }
        }
        private List<Kural> _Kuralkal = new List<Kural>();

        public List<Kural> Kuralkal
        {
            get { return _Kuralkal; }
            set { _Kuralkal = value; }
        }
    }
}
