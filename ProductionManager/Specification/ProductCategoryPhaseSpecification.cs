using ProductionManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionManager.Specification
{
    class ProductCategoryPhaseSpecification : BasicSpecification<ProductCategoryPhase>
    {
        public ProductCategoryPhaseSpecification()
        {
            AddInclude(x => x.Category);
            AddInclude(x => x.Phase);
        }
    }
}
