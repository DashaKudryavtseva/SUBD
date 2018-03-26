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
        public int ID
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
        private int _duration;
        public int Duration
        {
            get
            {
                return _duration;
            }
        }
        public Discipline(int id, string name, int duration)
        {
            _id = id;
            _name = name;
            _duration = duration;
        }
    }
}
