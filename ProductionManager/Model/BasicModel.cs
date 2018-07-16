using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionManager.Model
{
    public abstract class BasicModel : ObservableObject
    {
        private int _id;

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }

        public virtual void Reset()
        {
            Id = 0;
        }

        public abstract bool IsValid();
    }
}
