using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangSystem.Data
{
    class Student
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
        private string _fio;
        public string FIO
        {
            get
            {
                return _fio;
            }
        }
        private string _numRecordBook;
        public string NumRecordBook
        {
            get
            {
                return _numRecordBook;
            }
        }

        public Student(int id, int idGroup, string fio, string numRecordBook)
        {
            _idGroup = idGroup;
            _id = id;
            _fio = fio;
            _numRecordBook = numRecordBook;
        }
    }
}
