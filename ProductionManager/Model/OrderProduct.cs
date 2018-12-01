using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionManager.Model
{
    public class OrderProduct : BasicModel
    {
        private string _productName;
        private int _quantity;
        private DateTime _productDeliveryRequestDate;

        private Product _product;
        
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                if (value != _quantity)
                {
                    _quantity = value;
                    RaisePropertyChanged("Quantity");
                }
            }
        }

        public DateTime ProductDeliveryRequestDate
        {
            get => _productDeliveryRequestDate;
            set
            {
                if (value != _productDeliveryRequestDate)
                {
                    _productDeliveryRequestDate = value;
                    RaisePropertyChanged("ProductDeliveryRequestDate");
                }
            }
        }

        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                if (value != _productName)
                {
                    _productName = value;
                    RaisePropertyChanged("ProductName");
                }
            }
        }

        // add foreign key
        [BsonRef("Product")]
        public Product Product
        {
            get => _product;
            set
            {
                _product = value;
                ProductName = _product.Name;
                RaisePropertyChanged("Product");
            }
        }

        public OrderProduct Clone()
        {
            OrderProduct newOrderProduct = (OrderProduct)MemberwiseClone();
            newOrderProduct.Id = 0;
            return newOrderProduct;
        }

        public override bool IsValid()
        {
            return Product != null
                   && Quantity > 0
                    ;
        }

        public override void Reset()
        {
            base.Reset();
            
            Product = null;

            Quantity = 0;
            ProductDeliveryRequestDate = DateTime.MaxValue;
        }
    }
}
