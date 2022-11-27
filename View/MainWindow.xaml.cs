using LevelEditor.ViewModel;
using LevelEditor.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LevelEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NewLevelWindow newLevelWindow = new NewLevelWindow();
        public MainWindow()
        {
            DataContext = new MainViewModel();
            InitializeComponent();
        }

        private void NewLevelClick(object sender, RoutedEventArgs e)
        {
            newLevelWindow.Show();
        }
    }
}
