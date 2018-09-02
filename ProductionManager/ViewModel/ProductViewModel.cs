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
    public class ProductViewModel : CatalogViewModel<Product>
    {
        public override IEnumerable<Product> AllRecords => Repository.Find(new ProductSpecification());

        private IRepository<ProductCategory> _categoryRepository;
        public IEnumerable<ProductCategory> Categories   => _categoryRepository.Find(ProductCategorySpecification.All);

        public ProductViewModel() : base()
        {
            _categoryRepository = Database.CreateRepositoryForModel<ProductCategory>();
        }
    }
}
