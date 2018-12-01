using ProductionManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionManager.Specification
{
    class OrderProductSpecification : BasicSpecification<OrderProduct>
    {
        public OrderProductSpecification()
        {
            AddInclude(x => x.Product);
        }
    }
}
