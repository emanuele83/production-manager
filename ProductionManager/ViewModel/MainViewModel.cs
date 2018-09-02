using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProductionManager.ViewModel
{
    public class MainViewModel : BasicViewModel
    {
        #region Fields

        private ICommand _changePageCommand;
        private ICommand _closeApplicationCommand;

        private BasicViewModel _currentPageViewModel;
        private Dictionary<string, BasicViewModel> _pageViewModels;

        #endregion

        public MainViewModel()
        {
            // Add starting page
            PageViewModels.Add(typeof(HomeViewModel).Name, new HomeViewModel());

            // Set starting page
            CurrentPageViewModel = PageViewModels[typeof(HomeViewModel).Name];
        }

        #region Properties / Commands

        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand(
                        p => ChangeViewModel((Type)p),
                        p => true);
                }

                return _changePageCommand;
            }
        }

        public ICommand CloseApplicationCommand
        {
            get
            {
                if (_closeApplicationCommand == null)
                {
                    _closeApplicationCommand = new RelayCommand(
                        p => Application.Current.Shutdown(),
                        p => true);
                }

                return _closeApplicationCommand;
            }
        }

        public Dictionary<string, BasicViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new Dictionary<string, BasicViewModel>();

                return _pageViewModels;
            }
        }

        public BasicViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }
        }
        #endregion

        #region Methods

        private void ChangeViewModel(Type viewModel)
        {
            if (!PageViewModels.ContainsKey(viewModel.Name))
            {
                PageViewModels.Add(viewModel.Name, (BasicViewModel)Activator.CreateInstance(viewModel));
            }

            CurrentPageViewModel = PageViewModels[viewModel.Name];
        }

        #endregion
    }
}