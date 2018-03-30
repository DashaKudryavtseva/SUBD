using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangSystem.Data
{
    class IntermediateControl
    {
        //--Класс описывает сущность "Промежуточный контроль"

        private int _id;
        public int Id
        {
            get
            {
                return _id;
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
        private int _idGroup;
        public int IdGroup
        {
            get
            {
                return _idGroup;
            }
        }
        private string _typeOfControl;
        public string TypeOfControl
        {
            get
            {
                return _typeOfControl;
            }
            set
            {
                _typeOfControl = value;
            }
        }
        private int _numTasks;
        public int NumTasks
        {
            get
            {
                return _numTasks;
            }
            set
            {
                _numTasks = value;
            }
        }
        private int _maxBall;
        public int MaxBall
        {
            get
            {
                return _maxBall;
            }
            set
            {
                _maxBall = value;
            }
        }
        public IntermediateControl(int id, int idDiscipline, int idTeacher, int idGroup, 
        string typeOfControl, int numTasks, int maxBall)
        {
            _id = id;
            _idDiscipline = idDiscipline;
            _idTeacher = idTeacher;
            _idGroup = idGroup;
            _typeOfControl = typeOfControl;
            _numTasks = numTasks;
            _maxBall = maxBall;
            isEdit = false;
        }

        public bool isEdit;
    }
}
