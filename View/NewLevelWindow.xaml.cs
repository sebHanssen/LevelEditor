using LevelEditor.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace LevelEditor.View
{
    /// <summary>
    /// Interaction logic for NewLevelWindow.xaml
    /// </summary>
    public partial class NewLevelWindow : Window
    {
        public NewLevelWindow()
        {
            DataContext = new NewLevelViewModel();
            InitializeComponent();
        }

        private void CreateLevelClick(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;
            App.events.OnCreateLevel(HeightBox.Text, WidthBox.Text);
        }
    }
}
