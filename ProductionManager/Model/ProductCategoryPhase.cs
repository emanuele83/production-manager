using LiteDB;

namespace ProductionManager.Model
{
    public class ProductCategoryPhase : BasicModel
    {
        private ProductCategory _category;
        private ProductionPhase _phase;

        private int _machineHours;
        private int _workerHours;
        private int _workerNumber;

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

        // add foreign key
        [BsonRef("ProductionPhase")]
        public ProductionPhase Phase
        {
            get => _phase;
            set
            {
                _phase = value;
                RaisePropertyChanged("Phase");
            }
        }

        public int MachineHours
        {
            get
            {
                return _machineHours;
            }
            set
            {
                if (value != _machineHours)
                {
                    _machineHours = value;
                    RaisePropertyChanged("MachineHours");
                }
            }
        }

        public int WorkerHours
        {
            get
            {
                return _workerHours;
            }
            set
            {
                if (value != _workerHours)
                {
                    _workerHours = value;
                    RaisePropertyChanged("WorkerHours");
                }
            }
        }

        public int WorkerNumber
        {
            get
            {
                return _workerNumber;
            }
            set
            {
                if (value != _workerNumber)
                {
                    _workerNumber = value;
                    RaisePropertyChanged("WorkerNumber");
                }
            }
        }

        public override bool IsValid()
        {
            return Category != null
                    && Phase != null
                    ;
        }

        public override void Reset()
        {
            base.Reset();

            Category = null;
            Phase = null;

            MachineHours = 0;
            WorkerHours = 0;
            WorkerNumber = 0;
        }
    }
}