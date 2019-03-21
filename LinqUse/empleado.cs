using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqUse
{
    class empleado
    {
        private int _id;
        private string _Name;
        private string _LName;

        public int ID{
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        
        public string LName
        {
            get { return _LName; }
            set { _LName = value; }
        }
    }
}
