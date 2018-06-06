using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionManager.Model
{
    public class ProductionPhase
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductionPhaseModel : BasicModel
    {
        private LiteDatabase db;
        private LiteCollection<ProductionPhase> collection;
        private ProductionPhase productionPhase;

        public int Id
        {
            get
            {
                return productionPhase.Id;
            }
            set
            {
                if (value != productionPhase.Id)
                {
                    productionPhase.Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        public string Name
        {
            get
            {
                return productionPhase.Name;
            }
            set
            {
                if (value != productionPhase.Name)
                {
                    productionPhase.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public ProductionPhaseModel(LiteDatabase liteDatabase)
        {
            this.db = liteDatabase ?? throw new ArgumentNullException(nameof(liteDatabase));

            collection = db.GetCollection<ProductionPhase>("phases");
        }

        public int AddProductionPhase(string name) => collection.Insert(new ProductionPhase() { Name = name });
        public ProductionPhase GetProductionPhase(int id) => collection.FindById(id);
        public IEnumerable<ProductionPhase> ProductionPhases => collection.FindAll();
    }
}
