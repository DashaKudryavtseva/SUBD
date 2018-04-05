using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangSystem.Data
{
    class HeadLists
    {
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
        }
        private int _idPlan;
        public int IdPlan
        {
            get
            {
                return _idPlan;
            }
        }
        private int _idStudentRating;
        public int IdStudentRating
        {
            get
            {
                return _idStudentRating;
            }
        }
        private DateTime _finalDate;
        public DateTime FinalDate
        {
            get
            {
                return _finalDate;
            }
        }

        public HeadLists(int id, int idPlan, int idStudentRating, DateTime finalDate)
        {
            _id = id;
            _idPlan = idPlan;
            _idStudentRating = idStudentRating;
            _finalDate = finalDate;
        }

    }
}
