using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionManager.Model
{
    public class Product : BasicModel
    {
        private string _name;
        private ProductCategory _category;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        // add foreign key
        [BsonRef("ProductCategory")]
        public ProductCategory Category
        {
            get => _category;
            set
            {
                _category = value;
                RaisePropertyChanged("Category");
            }
        }
    }
}
