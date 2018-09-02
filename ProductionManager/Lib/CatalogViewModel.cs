using ProductionManager.Model;
using ProductionManager.Repository;
using System.Collections.Generic;
using System.Windows.Input;

namespace ProductionManager.ViewModel
{
    public abstract class CatalogViewModel<T> : BasicViewModel where T : BasicModel, new()
    {
        #region private variables
        private T _currentRecord;
        private bool _showMode; 
        #endregion

        protected CatalogViewModel()
        {
            Repository = Database.CreateRepositoryForModel<T>();

            Reset();

            ShowMode = true;
        }

        #region public properties
        public T CurrentRecord
        {
            get => _currentRecord;
            set
            {
                _currentRecord = value;
                RaisePropertyChanged("CurrentRecord");
            }
        }
        public IRepository<T> Repository { get; private set; }
        public bool EditMode { get; private set; }
        public bool ShowMode
        {
            get => _showMode;
            set
            {
                _showMode = value;
                EditMode = !_showMode;
                RaisePropertyChanged("ShowMode");
                RaisePropertyChanged("EditMode");
            }
        } 
        #endregion

        public abstract IEnumerable<T> AllRecords { get; }
        
        public virtual void Reset()
        {
            CurrentRecord = new T();
        }

        #region crud
        public virtual void AddRecord()
        {
            Reset();
            ShowMode = false;
        }
        public virtual void EditRecord()
        {
            ShowMode = false;
        }
        public virtual bool SaveRecord()
        {
            bool result = false;
            if (CurrentRecord.IsValid())
            {
                if (CurrentRecord.Id > 0)
                {
                    result = Repository.Update((T)CurrentRecord);
                }
                else
                {
                    result = Repository.Insert((T)CurrentRecord) > 0;
                }
                if (result)
                {
                    RefreshData();
                }
            }
            return result;
        }
        public virtual bool DeleteRecord()
        {
            bool result = false;
            if (CurrentRecord.Id > 0)
            {
                result = Repository.Delete(CurrentRecord.Id);
                if (result)
                {
                    RefreshData();
                }
            }

            return result;
        }
        #endregion


        private void RefreshData()
        {
            Reset();
            RaisePropertyChanged("AllRecords");
            ShowMode = true;
        }
        public virtual void CloseRecord()
        {
            RefreshData();
            ShowMode = true;
        }
        public virtual void PopulateForm(T model)
        {
            CurrentRecord = model;
        }

        #region commands allowing
        public virtual bool AllowAddCommand()
        {
            return true;
        }
        public virtual bool AllowDeleteCommand()
        {
            if (CurrentRecord != null)
            {
                return CurrentRecord.Id > 0;
            }
            return false;
        }
        public virtual bool AllowEditCommand()
        {
            if (CurrentRecord != null)
            {
                return CurrentRecord.Id > 0;
            }
            return false;
        }
        public virtual bool AllowSaveCommand()
        {
            return true;
        } 
        #endregion

        #region Commands
        public ICommand AddCommand
        {
            get
            {
                return new RelayCommand(
                        p => AddRecord(),
                        p => AllowAddCommand());
            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand(
                        p => DeleteRecord(),
                        p => AllowDeleteCommand());
            }
        }
        public ICommand EditCommand
        {
            get
            {
                return new RelayCommand(
                        p => EditRecord(),
                        p => AllowEditCommand());
            }
        }
        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand(
                        p => SaveRecord(),
                        p => AllowSaveCommand());
            }
        }
        public ICommand CloseCommand
        {
            get
            {
                return new RelayCommand(
                        p => CloseRecord(),
                        p => true);
            }
        }
        public ICommand PopulateFormCommand
        {
            get
            {
                return new RelayCommand(
                        p => PopulateForm((T)p),
                        p => true);
            }
        }
        #endregion
    }
}
