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
        private int _idPlan;
        public int IdPlan
        {
            get
            {
                return _idPlan;
            }
        }
        private ControlTypes _type;
        public ControlTypes Type
        {
            get
            {
                return _type;
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
        public IntermediateControl(int id, int idPlan, ControlTypes Type, int maxBall)
        {
            _id = id;
            _type = Type;
            _idPlan = idPlan;
            _maxBall = maxBall;
            isEdit = false;
        }

        public bool isEdit;
    }
}
