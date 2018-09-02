namespace ProductionManager.Model
{
    public abstract class BasicModel : ObservableObject
    {
        private int _id;

        protected BasicModel()
        {
            Reset();
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }

        public abstract bool IsValid();

        public virtual void Reset()
        {
            Id = 0;
        }

        public override bool Equals(object obj)
        {
            var model = obj as BasicModel;
            return model != null &&
                   _id == model._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}
