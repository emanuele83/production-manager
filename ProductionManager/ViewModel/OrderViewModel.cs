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
    class OrderViewModel : CatalogViewModel<Order>
    {
        public override IEnumerable<Order> AllRecords => Repository.Find(new OrderSpecification());

        private IRepository<Customer> _customerRepository;
        public IEnumerable<Customer> Customers => _customerRepository.Find(CustomerSpecification.All);

        private IRepository<Product> _productRepository;
        public IEnumerable<Product> Products => _productRepository.Find(new ProductSpecification());

        public OrderViewModel() : base()
        {
            _customerRepository = Database.CreateRepositoryForModel<Customer>();
            _productRepository = Database.CreateRepositoryForModel<Product>();
        }

        public void CopyProduct(int productId)
        {
            for (int i = 0; i < CurrentRecord.OrderProducts.Count; i++)
            {
                if (CurrentRecord.OrderProducts[i].Id == productId)
                {
                    CurrentRecord.AddProduct(CurrentRecord.OrderProducts[i].Clone());
                    break;
                }
            }
        }

        public void DeleteProduct(int productId)
        {
            for (int i = 0; i < CurrentRecord.OrderProducts.Count; i++)
            {
                if (CurrentRecord.OrderProducts[i].Id == productId)
                {
                    CurrentRecord.RemoveProduct(CurrentRecord.OrderProducts[i]);
                    break;
                }
            }
        }

        public ICommand CopyProductCommand
        {
            get
            {
                return new RelayCommand(
                        p => CopyProduct((int)p),
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
    }
}
