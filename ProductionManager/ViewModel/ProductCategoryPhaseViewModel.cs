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
    public class ProductCategoryPhaseViewModel : BasicViewModel
    {
        public override string Name => this.GetType().Name;

        private IRepository<ProductCategoryPhase> _repository;
        private IRepository<ProductCategory> _categoryRepository;
        private IRepository<ProductionPhase> _phaseRepository;

        private ProductCategoryPhase _newCategoryPhase;

        public ProductCategoryPhase NewCategoryPhase
        {
            get => _newCategoryPhase;
            set
            {
                _newCategoryPhase = value;
                RaisePropertyChanged("NewCategoryPhase");
            }
        }

        public IEnumerable<ProductCategoryPhase> ProductCategoryPhases => _repository.Find(new ProductCategoryPhaseSpecification());
        public IEnumerable<ProductCategory> Categories => _categoryRepository.Find(ProductCategorySpecification.All);
        public IEnumerable<ProductionPhase> Phases => _phaseRepository.Find(ProductionPhaseSpecification.All);

        public ProductCategoryPhaseViewModel()
        {
            _repository = Database.CreateRepositoryForModel<ProductCategoryPhase>();
            _categoryRepository = Database.CreateRepositoryForModel<ProductCategory>();
            _phaseRepository = Database.CreateRepositoryForModel<ProductionPhase>();

            NewCategoryPhase = new ProductCategoryPhase();

            Reset();
        }

        private void Reset()
        {
            NewCategoryPhase.Reset();
        }

        #region Product CRUD
        public int AddProductCategoryPhase()
        {
            int productId = 0;

            if (NewCategoryPhase.IsValid())
            {
                productId = _repository.Insert(NewCategoryPhase);
                RaisePropertyChanged("ProductCategoryPhases");

                Reset();
            }

            return productId;
        }
        public bool DeleteProductCategoryPhase(int id)
        {
            bool result = _repository.Delete(id);
            if (result)
                RaisePropertyChanged("ProductCategoryPhases");

            return result;
        }
        #endregion

        #region Product Commands
        public ICommand AddProductCategoryPhaseCommand
        {
            get
            {
                return new RelayCommand(
                        p => AddProductCategoryPhase(),
                        p => true);
            }
        }
        public ICommand DeleteProductCategoryPhaseCommand
        {
            get
            {
                return new RelayCommand(
                        p => DeleteProductCategoryPhase((int)p),
                        p => true);
            }
        }
        #endregion
    }
}
