﻿using LiteDB;

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

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(Name.Trim())
                    && Category != null
                    ;
        }

        public override void Reset()
        {
            base.Reset();

            Name = string.Empty;
            Category = null;
        }
    }
}