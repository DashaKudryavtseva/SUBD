using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangSystem.Data
{
    class AcademicPlan
    {
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
        }
        private int _idGroup;
        public int IdGroup
        {
            get
            {
                return _idGroup;
            }
        }
        private int _idDiscipline;
        public int IdDiscipline
        {
            get
            {
                return _idDiscipline;
            }
        }
        private int _idTeacher;
        public int IdTeacher
        {
            get
            {
                return _idTeacher;
            }
        }
        private int _durability;
        public int Durability
        {
            get
            {
                return _durability;
            }
        }

        public AcademicPlan(int id, int idGroup, int idDiscipline, int idTeacher, int durability)
        {
            _id = id;
            _idGroup = idGroup;
            _idDiscipline = idDiscipline;
            _idTeacher = idTeacher;
            _durability = durability;
        }
    }
}
