using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangSystem
{
    public class Teacher
    {
        //--Класс описывает сущность "Преподаватель"

        private string _fio;
        public string FIO
        {
            get
            {
                return _fio;
            }
        }
        private string _password;
        public string Password
        {
            get
            {
                return _password;
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
        private int _idCathedra;
        public int IdCathedra
        {
            get
            {
                return _idCathedra;
            }
        }
        private int _idDegree;
        public int IdDegree
        {
            get
            {
                return _idDegree;
            }
        }


        public Teacher(int idCathedra, int idDegree, int idTeacher, string fio, string password)
        {
            _fio = fio;
            _password = password;
            _idTeacher = idTeacher;
            _idDegree = idDegree;
            _idCathedra = idCathedra;
        }
    }
}
