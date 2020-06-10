namespace ProductionManager.Model
{
    public class ProductCategory : BasicModel
    {
        private string _name;

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

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(Name.Trim())
                    ;
        }

        public override void Reset()
        {
            base.Reset();

            Name = string.Empty;
        }
    }
}