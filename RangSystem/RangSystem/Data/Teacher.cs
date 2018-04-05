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
        private string _degree;
        public string Degree
        {
            get
            {
                return _degree;
            }
        }
        private bool _adminRights;
        public bool AdminRights
        {
            get
            {
                return _adminRights;
            }
        }

        public Teacher(int id, int idCathedra, string degree, string fio, string password, bool adminRights)
        {
            _fio = fio;
            _password = password;
            _id = id;
            _degree = degree;
            _idCathedra = idCathedra;
            _adminRights = adminRights;
        }
    }
}
