using ProductionManager.Model;
using ProductionManager.Repository;
using ProductionManager.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionManager.ViewModel
{
    class OrderViewModel : CatalogViewModel<Order>
    {
        public override IEnumerable<Order> AllRecords => Repository.Find(new OrderSpecification());

        private IRepository<Customer> _customerRepository;
        public IEnumerable<Customer> Customers => _customerRepository.Find(CustomerSpecification.All);

        public OrderViewModel() : base()
        {
            _customerRepository = Database.CreateRepositoryForModel<Customer>();
        }
    }
}
