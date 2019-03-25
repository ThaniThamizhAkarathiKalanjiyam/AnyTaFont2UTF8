using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPEntities.Noolkal.Entities
{
    public class Kural : Venba
    {
        private int _KuralId = 0;

        public int KuralId
        {
            get { return _KuralId; }
            set { _KuralId = value; }
        }


        //public  string l1
        //{
        //    get;
        //    set;
        //}

        //public  string l2
        //{
        //    get;
        //    set;
        //}
    }
}
