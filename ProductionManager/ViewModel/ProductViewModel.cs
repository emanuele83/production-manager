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
    public class ProductViewModel : BasicViewModel
    {
        public override string Name => this.GetType().Name;

        private IRepository<Product> _repository;
        private IRepository<ProductCategory> _categoryRepository;
        
        private Product _newProduct;

        public Product NewProduct
        {
            get => _newProduct;
            set
            {
                _newProduct = value;
                RaisePropertyChanged("NewProduct");
            }
        }

        public IEnumerable<Product>         Products     => _repository.Find(new ProductSpecification());
        public IEnumerable<ProductCategory> Categories   => _categoryRepository.Find(ProductCategorySpecification.All);

        public ProductViewModel()
        {
            _repository = Database.CreateRepositoryForModel<Product>();
            _categoryRepository = Database.CreateRepositoryForModel<ProductCategory>();

            NewProduct = new Product();

            Reset();
        }

        private void Reset()
        {
            NewProduct.Reset();
        }

        #region Product CRUD
        public int AddProduct()
        {
            int productId = 0;

            if (NewProduct.IsValid())
            {
                productId = _repository.Insert(NewProduct);
                RaisePropertyChanged("Products");

                Reset();
            }

            return productId;
        }
        public bool DeleteProduct(int id)
        {
            bool result = _repository.Delete(id);
            if (result)
                RaisePropertyChanged("Products");

            return result;
        }
        #endregion

        #region Product Commands
        public ICommand AddProductCommand
        {
            get
            {
                return new RelayCommand(
                        p => AddProduct(),
                        p => true);
            }
        }
        public ICommand DeleteProductCommand
        {
            get
            {
                return new RelayCommand(
                        p => DeleteProduct((int)p),
                        p => true);
            }
        }
        #endregion
    }
}
