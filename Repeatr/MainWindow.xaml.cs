using System;
using System.Windows;
using System.Windows.Input;
using Myriatek.Cube.Repeatr.Mvvm;
using Myriatek.Cube.Repeatr.Mvvm.ViewModels;

namespace Myriatek.Cube.Repeatr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainWindowViewModel();
        }

        public MainWindowViewModel ViewModel
        {
            get { return (MainWindowViewModel)DataContext; }
            set { DataContext = value; }
        }
       

        private void MainWindow_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl+C everywhere
            if (e.KeyboardDevice.IsKeyDown(Key.C) && e.KeyboardDevice.Modifiers == ModifierKeys.Control)
            {
                Clipboard.SetText(ViewModel.Result);
            }            
        }


        private void MainWindow_OnDeactivated(object sender, EventArgs e)
        {
            // Make it easier if the user forgot to press Ctrl+C.
            if (lostFocusCopyCheck.IsChecked == true)
            {
                Clipboard.SetText(ViewModel.Result);
            }
        }
    }
}
