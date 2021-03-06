﻿using ProductionManager.Model;
using ProductionManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionManager.Specification
{
    class OrderSpecification : BasicSpecification<Order>
    {
        public OrderSpecification()
        {
            AddInclude(x => x.Customer);
            AddInclude(x => x.OrderProducts);
        }
    }
}
