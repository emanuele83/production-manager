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
    public class ProductCategoryViewModel : CatalogViewModel<ProductCategory>
    {
        public override IEnumerable<ProductCategory> AllRecords => Repository.Find(ProductCategorySpecification.All);
    }
}
