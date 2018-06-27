using LiteDB;
using ProductionManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionManager.ViewModel
{
    public abstract class BasicViewModel : ObservableObject
    {
        public abstract string Name
        {
            get;
        }
    }
}
