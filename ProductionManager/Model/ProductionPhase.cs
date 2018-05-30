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
    
    public class ProductionPhaseModel
    {
        private LiteDatabase db;
        private LiteCollection<ProductionPhase> collection;

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
