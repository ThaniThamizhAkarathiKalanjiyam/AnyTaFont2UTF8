using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPEntities.Noolkal.Entities
{
    public class Iyal
    {
        private int _IyalId = 0;

        public int IyalId
        {
            get { return _IyalId; }
            set { _IyalId = value; }
        }
        private string _IyalName = "";

        public string IyalName
        {
            get { return _IyalName; }
            set { _IyalName = value; }
        }
        private List<Adhikaram> _Adhikarankal = new List<Adhikaram>();

        public List<Adhikaram> Adhikarankal
        {
            get { return _Adhikarankal; }
            set { _Adhikarankal = value; }
        }
    }
}
