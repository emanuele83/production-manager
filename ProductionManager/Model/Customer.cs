﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionManager.Model
{
    public class Customer : BasicModel
    {
        private string _name;
        
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(Name.Trim())
                    ;
        }

        public override void Reset()
        {
            base.Reset();

            Name = string.Empty;
        }
    }
}
