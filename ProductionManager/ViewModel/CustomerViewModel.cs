using ProductionManager.Model;
using ProductionManager.Specification;
using System.Collections.Generic;

namespace ProductionManager.ViewModel
{
    public class CustomerViewModel : CatalogViewModel<Customer>
    {
        public override IEnumerable<Customer> AllRecords => Repository.Find(CustomerSpecification.All);
    }
}