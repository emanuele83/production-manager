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
    public class ProductCategoryViewModel : BasicViewModel
    {
        public override string Name => this.GetType().Name;

        private IRepository<ProductCategory> _repository;
        private string _productCategoryName;

        public string ProductCategoryName
        {
            get => _productCategoryName;
            set
            {
                _productCategoryName = value;
                RaisePropertyChanged("ProductCategoryName");
            }
        }

        public IEnumerable<ProductCategory> ProductCategories => _repository.Find(ProductCategorySpecification.All);

        public ProductCategoryViewModel()
        {
            _repository = Database.CreateRepositoryForModel<ProductCategory>();

            Reset();
        }

        private void Reset()
        {
            ProductCategoryName = string.Empty;
        }

        #region ProductCategory CRUD
        public int AddProductCategory()
        {
            int productCategoryId = 0;

            if (!string.IsNullOrEmpty(ProductCategoryName.Trim()))
            {
                productCategoryId = _repository.Insert(new ProductCategory() { Name = ProductCategoryName });
                RaisePropertyChanged("ProductCategories");

                Reset();
            }

            return productCategoryId;
        }
        public bool DeleteProductCategory(int id)
        {
            bool result = _repository.Delete(id);
            if (result)
                RaisePropertyChanged("ProductCategories");

            return result;
        }
        #endregion

        #region ProductCategory Commands
        public ICommand AddProductCategoryCommand
        {
            get
            {
                return new RelayCommand(
                        p => AddProductCategory(),
                        p => true);
            }
        }
        public ICommand DeleteProductCategoryCommand
        {
            get
            {
                return new RelayCommand(
                        p => DeleteProductCategory((int)p),
                        p => true);
            }
        }
        #endregion
    }
}
