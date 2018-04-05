using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangSystem.Data
{
    class StudentRating
    {
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
        }
        private int _idStudent;
        public int IdStudent
        {
            get
            {
                return _idStudent;
            }
        }
        private int _idIntermediateControl;
        public int IdIntermediateControl
        {
            get
            {
                return _idIntermediateControl;
            }
        }
        private int _ball;
        public int Ball
        {
            get
            {
                return _ball;
            }
        }

        public StudentRating(int id, int idStudent, int idIntermediateControl, int ball)
        {
            _id = id;
            _idStudent = idStudent;
            _idIntermediateControl = idIntermediateControl;
            _ball = ball;
        }
    }
}
