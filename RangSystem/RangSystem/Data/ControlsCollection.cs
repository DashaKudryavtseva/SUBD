﻿using RangSystem.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangSystem.Data
{
    class ControlsCollection
    {
        private ObservableCollection<IntermediateControl> _controlList;
        public ObservableCollection<IntermediateControl> ControlList
        {
            get
            {
                return _controlList;
            }

        }
        public ControlsCollection(int teachId, int discId, int groupId)
        {
            _controlList = DBCommunicate.GetIntermediateControlls(teachId, discId, groupId);
        }

        internal void AllUpdate()
        {
            foreach(var v in _controlList)
            {
                if (v.isEdit)
                    DBCommunicate.UpdateControl(v);
            }
        }
    }
}
