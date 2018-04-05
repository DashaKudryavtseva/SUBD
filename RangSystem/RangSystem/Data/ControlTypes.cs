using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangSystem.Data
{
    class ControlTypes
    {
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
        }
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
        }

        public ControlTypes(int id, string name)
        {
            _name = name;
            _id = id;
        }
    }
}
