using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductionManager.ViewModel
{
    public class MainViewModel : BasicViewModel
    {
        public override string Name => this.GetType().Name;

        #region Fields

        private ICommand _changePageCommand;

        private BasicViewModel _currentPageViewModel;
        private Dictionary<string, BasicViewModel> _pageViewModels;

        #endregion

        public MainViewModel()
        {
            // Add available pages
            PageViewModels.Add(typeof(HomeViewModel).Name, new HomeViewModel());
            //PageViewModels.Add(typeof(ProductionPhaseViewModel).Name, new ProductionPhaseViewModel());

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
                        p => ChangeViewModel(p.ToString()),
                        p => true);
                }

                return _changePageCommand;
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

        private void ChangeViewModel(string viewModel)
        {
            if (!PageViewModels.ContainsKey(viewModel))
                PageViewModels.Add(viewModel, (BasicViewModel)Activator.CreateInstance(Type.GetType(viewModel)));

            if (PageViewModels.ContainsKey(viewModel))
                CurrentPageViewModel = PageViewModels[viewModel];
        }

        #endregion
    }
}