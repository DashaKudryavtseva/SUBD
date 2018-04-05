using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangSystem.Data
{
    class Group
    {
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
        }
        private int _idCathedra;
        public int IdCathedra
        {
            get
            {
                return _idCathedra;
            }
        }
        private string _direction;
        public string Direction
        {
            get
            {
                return _direction;
            }
        }
        private int _numCourse;
        public int NumCourse
        {
            get
            {
                return _numCourse;
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

        public Group(int id, int idCathedra, string direction, int numCourse, string name)
        {
            _id = id;
            _idCathedra = idCathedra;
            _direction = direction;
            _numCourse = numCourse;
            _name = name;

        }
    }
}
