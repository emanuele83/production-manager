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
        private string _phaseName;

        public string PhaseName
        {
            get => _phaseName;
            set
            {
                _phaseName = value;
                RaisePropertyChanged("PhaseName");
            }
        }

        public IEnumerable<ProductionPhase> ProductionPhases => collection.FindAll();

        public ProductionPhaseViewModel(LiteDatabase db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));

            collection = db.GetCollection<ProductionPhase>("phases");

            _phaseName = string.Empty;
        }

        #region Phase CRUD
        public int AddProductionPhase()
        {
            int phaseId = collection.Insert(new ProductionPhase() { Name = PhaseName });
            PhaseName = string.Empty;
            RaisePropertyChanged("ProductionPhases");

            return phaseId;
        }
        public bool DeleteProductionPhase(int id)
        {
            bool result = collection.Delete(id);
            if (result)
                RaisePropertyChanged("ProductionPhases");

            return result;
        }
        //public ProductionPhase GetProductionPhase(int id) => collection.FindById(id); 
        #endregion

        #region Phase Commands
        public ICommand AddPhaseCommand
        {
            get
            {
                return new RelayCommand(
                        p => AddProductionPhase(),
                        p => true);
            }
        }
        public ICommand DeletePhaseCommand
        {
            get
            {
                return new RelayCommand(
                        p => DeleteProductionPhase((int)p),
                        p => true);
            }
        } 
        #endregion
    }
}
