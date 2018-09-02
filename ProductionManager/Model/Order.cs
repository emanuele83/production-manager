using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionManager.Model
{
    class Order : BasicModel
    {
        private string _externalReference;
        private DateTime _incomingDate;
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

        public DateTime IncomingDate
        {
            get => _incomingDate;
            set
            {
                if (value != _incomingDate)
                {
                    _incomingDate = value;
                    RaisePropertyChanged("IncomingDate");
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

        public override bool IsValid()
        {
            return Customer != null
                && IncomingDate != null
                && IncomingDate > DateTime.MinValue
                    ;
        }

        public override void Reset()
        {
            base.Reset();

            ExternalReference = string.Empty;
            Customer = null;
            IncomingDate = DateTime.Now;
        }
    }
}
