using LiteDB;
using ProductionManager.Model;
using ProductionManager.Repository;
using ProductionManager.Specification;
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
        public override string Name => this.GetType().Name;

        private IRepository<ProductionPhase> _repository;
        private string _phaseName;

        public string PhaseName
        {
            get => _phaseName;
            set
            {
                if (!string.IsNullOrEmpty(value.Trim()) && value != _phaseName)
                {
                    _phaseName = value;
                    RaisePropertyChanged("PhaseName");
                }
            }
        }

        public IEnumerable<ProductionPhase> ProductionPhases => _repository.Find(ProductionPhaseSpecification.All);

        public ProductionPhaseViewModel()
        {
            _repository = Database.CreateRepositoryForModel<ProductionPhase>();

            Reset();
        }

        private void Reset()
        {
            _phaseName = string.Empty;
        }

        #region Phase CRUD
        public int AddProductionPhase()
        {
            int phaseId = _repository.Insert(new ProductionPhase() { Name = PhaseName });
            RaisePropertyChanged("ProductionPhases");

            Reset();

            return phaseId;
        }
        public bool DeleteProductionPhase(int id)
        {
            bool result = _repository.Delete(id);
            if (result)
                RaisePropertyChanged("ProductionPhases");

            return result;
        }
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
