using ProductionManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductionManager.Specification
{
    public class ProductSpecification : BasicSpecification<Product>
    {
        public ProductSpecification()
        {
            AddInclude(x => x.Category);
        }
    }
}
