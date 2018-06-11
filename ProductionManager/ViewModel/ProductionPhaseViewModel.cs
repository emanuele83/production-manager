using LiteDB;
using ProductionManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductionManager.ViewModel
{
    public class ProductionPhaseViewModel : BasicViewModel
    {
        private readonly LiteDatabase db;
        private LiteCollection<ProductionPhase> collection;

        public ProductionPhaseViewModel(LiteDatabase db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));

            collection = db.GetCollection<ProductionPhase>("phases");
        }

        public int AddProductionPhase(string name) => collection.Insert(new ProductionPhase() { Name = name });
        public ProductionPhase GetProductionPhase(int id) => collection.FindById(id);
        public IEnumerable<ProductionPhase> ProductionPhases => collection.FindAll();

        public ICommand AddPhaseCommand
        {
            get
            {
                return new RelayCommand(
                        p => AddProductionPhase(p.ToString()),
                        p => true);
            }
        }
    }
}
