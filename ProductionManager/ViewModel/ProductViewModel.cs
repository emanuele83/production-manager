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

        private string _productName;
        private ProductCategory _productCategory;

        public string ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
                RaisePropertyChanged("ProductName");
            }
        }

        public ProductCategory ProductCategory
        {
            get => _productCategory;
            set
            {
                _productCategory = value;
                RaisePropertyChanged("ProductCategory");
            }
        }

        public IEnumerable<Product>         Products     => _repository.Find(new ProductSpecification());
        public IEnumerable<ProductCategory> Categories   => _categoryRepository.Find(ProductCategorySpecification.All);

        public ProductViewModel()
        {
            _repository = Database.CreateRepositoryForModel<Product>();
            _categoryRepository = Database.CreateRepositoryForModel<ProductCategory>();

            Reset();
        }

        private void Reset()
        {
            ProductName = string.Empty;
            ProductCategory = null;
        }

        #region Product CRUD
        public int AddProduct()
        {
            int productId = 0;

            if (!string.IsNullOrEmpty(ProductName.Trim()) && ProductCategory != null)
            {
                productId = _repository.Insert(new Product() { Name = ProductName, Category = ProductCategory });
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
