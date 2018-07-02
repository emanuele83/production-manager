using ProductionManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductionManager.Specification
{
    public class ProductionPhaseSpecification : BasicSpecification<ProductionPhase>
    {
        //public ProductionPhaseSpecification()
        //{
        //    // add include if necessary
        //    AddInclude(x => x.);
        //}

        public override Expression<Func<ProductionPhase, bool>> ToExpression()
        {
            return x => true; // todo...
        }
    }
}
