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
    public class ProductCategoryPhaseViewModel : CatalogViewModel<ProductCategoryPhase>
    {
        public override IEnumerable<ProductCategoryPhase> AllRecords => Repository.Find(new ProductCategoryPhaseSpecification());
        
        private IRepository<ProductCategory> _categoryRepository;
        private IRepository<ProductionPhase> _phaseRepository;
        public IEnumerable<ProductCategory> Categories => _categoryRepository.Find(ProductCategorySpecification.All);
        public IEnumerable<ProductionPhase> Phases => _phaseRepository.Find(ProductionPhaseSpecification.All);

        public ProductCategoryPhaseViewModel() : base()
        {
            _categoryRepository = Database.CreateRepositoryForModel<ProductCategory>();
            _phaseRepository = Database.CreateRepositoryForModel<ProductionPhase>();
        }
    }
}
