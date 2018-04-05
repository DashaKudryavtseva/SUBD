using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangSystem
{
    class Cathedra
    {
        //--Класс описывает сущность "Кафедра"

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
        private int _idInstitute;
        public int IdInstitute
        {
            get
            {
                return _idInstitute;
            }
        }

        public Cathedra(int id, int idInstitute, string name)
        {
            _name = name;
            _id = id;
            _idInstitute = idInstitute;
        }
        
    }
}
