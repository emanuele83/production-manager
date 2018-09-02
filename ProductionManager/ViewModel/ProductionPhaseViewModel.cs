using LiteDB;
using ProductionManager.Model;
using ProductionManager.Repository;
using ProductionManager.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductionManager.ViewModel
{
    public class ProductionPhaseViewModel : CatalogViewModel<ProductionPhase>
    {
        public override IEnumerable<ProductionPhase> AllRecords => Repository.Find(ProductionPhaseSpecification.All);
    }
}
