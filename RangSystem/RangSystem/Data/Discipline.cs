using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangSystem.Data
{
    class Discipline
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



        public Discipline(int id, string name)
        {
            _id = id;
            _name = name;
        }
    }
}
