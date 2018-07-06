using ProductionManager.ViewModel;
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Shared;
using System;
using System.Windows;

namespace ProductionManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		#region Fields
        private string currentVisualStyle;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the current visual style.
        /// </summary>
        /// <value></value>
        /// <remarks></remarks>
        public string CurrentVisualStyle
        {
            get
            {
                return currentVisualStyle;
            }
            set
            {
                currentVisualStyle = value;
                OnVisualStyleChanged();
            }
        }
        #endregion
        public MainWindow()
        {
            InitializeComponent();
			this.Loaded += OnLoaded;

            MainViewModel context = new MainViewModel();
            DataContext = context;

            // populate menu
            MenuItemAdv FileMenu = new MenuItemAdv() { Header = "File" };
            MainMenu.Items.Add(FileMenu);

            MenuItemAdv ExitMenu = new MenuItemAdv() { Header = "Exit" };
            ExitMenu.Command = context.CloseApplicationCommand;
            FileMenu.Items.Add(ExitMenu);

            MenuItemAdv ProductionMenu = new MenuItemAdv() { Header = "Production" };
            MainMenu.Items.Add(ProductionMenu);

            MenuItemAdv ProductionPhasesMenu = new MenuItemAdv() { Header = "Production Phases" };
            ProductionPhasesMenu.Command = context.ChangePageCommand;
            ProductionPhasesMenu.CommandParameter = typeof(ProductionPhaseViewModel);
            ProductionMenu.Items.Add(ProductionPhasesMenu);

        }
		/// <summary>
        /// Called when [loaded].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            CurrentVisualStyle = "Blend";
        }
		/// <summary>
        /// On Visual Style Changed.
        /// </summary>
        /// <remarks></remarks>
        private void OnVisualStyleChanged()
        {
            VisualStyles visualStyle = VisualStyles.Default;
            Enum.TryParse(CurrentVisualStyle, out visualStyle);            
            if (visualStyle != VisualStyles.Default)
            {
                SfSkinManager.ApplyStylesOnApplication = true;
                SfSkinManager.SetVisualStyle(this, visualStyle);
                SfSkinManager.ApplyStylesOnApplication = false;
            }
        }
    }
}
