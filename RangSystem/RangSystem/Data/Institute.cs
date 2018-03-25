using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangSystem
{
    class Institute
    {
        //--Класс описывает сущность "институт"

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
        }
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
        }

        public Institute(string name, int id)
        {
            _name = name;
            _id = id;
        }
    }
}
