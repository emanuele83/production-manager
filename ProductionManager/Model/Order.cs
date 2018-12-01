using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionManager.Model
{
    public class Order : BasicModel
    {
        private string _externalReference;
        private DateTime _orderDate;
        private DateTime _orderDeliveryRequestDate;

        private Customer _customer;

        public string ExternalReference
        {
            get
            {
                return _externalReference;
            }
            set
            {
                if (value != _externalReference)
                {
                    _externalReference = value;
                    RaisePropertyChanged("ExternalReference");
                }
            }
        }

        public DateTime OrderDate
        {
            get => _orderDate;
            set
            {
                if (value != _orderDate)
                {
                    _orderDate = value;
                    RaisePropertyChanged("OrderDate");
                }
            }
        }

        public DateTime OrderDeliveryRequestDate
        {
            get => _orderDeliveryRequestDate;
            set
            {
                if (value != _orderDeliveryRequestDate)
                {
                    _orderDeliveryRequestDate = value;
                    RaisePropertyChanged("OrderDeliveryRequestDate");
                }
            }
        }

        // add foreign key
        [BsonRef("Customer")]
        public Customer Customer
        {
            get => _customer;
            set
            {
                _customer = value;
                RaisePropertyChanged("Customer");
            }
        }

        // add foreign key
        [BsonRef("OrderProduct")]
        public List<OrderProduct> OrderProducts { get; } = new List<OrderProduct>();

        public void AddProduct(OrderProduct product)
        {
            OrderProducts.Add(product);
            RaisePropertyChanged("OrderProducts");
        }
        public void RemoveProduct(OrderProduct product)
        {
            OrderProducts.Remove(product);
            RaisePropertyChanged("OrderProducts");
        }

        public override bool IsValid()
        {
            return Customer != null
                && OrderDate != null
                && OrderDate > DateTime.MinValue
                    ;
        }

        public override void Reset()
        {
            base.Reset();

            ExternalReference = string.Empty;
            OrderDate = DateTime.Now;
            OrderDeliveryRequestDate = DateTime.MaxValue;

            Customer = null;

            OrderProducts.Clear();
        }
    }
}
