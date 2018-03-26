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
        public int ID
        {
            get
            {
                return _id;
            }
        }
        private int _idCathedra;
        public int IDCathedra
        {
            get
            {
                return _idCathedra;
            }
        }
        private int _idDirection;
        public int IDDirection
        {
            get
            {
                return _idDirection;
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
        public Group(int id, int idCathedra, int idDirection, int numCourse, string name)
        {
            _id = id;
            _idCathedra = idCathedra;
            _idDirection = idDirection;
            _numCourse = numCourse;
            _name = name;

        }
    }
}
