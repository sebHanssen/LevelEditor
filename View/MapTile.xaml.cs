using LevelEditor.Events;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace LevelEditor.View
{
    /// <summary>
    /// Interaction logic for MapTile.xaml
    /// </summary>
    public partial class MapTile : UserControl
    {
        public int xCord;
        public int yCord;
        public MapTile()
        {
            DataContext = new MainViewModel();
            InitializeComponent();
            App.events.ChangeMapTile += HandleChangeMapTile;
        }

        private string? ImageSource
        {
            get
            {
                return (string)GetValue(ImageSourceProperty);
            }
            set
            {
                SetValue(ImageSourceProperty, value);
            }
        }
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(string),
                typeof(MapTile), new PropertyMetadata("/Resources/empty.png"));

        private void onClick(object sender, RoutedEventArgs e)
        {
            App.events.OnMapTileClick(xCord, yCord);
        }

        private void onEnter(object sender, RoutedEventArgs e)
        {
            if(Mouse.LeftButton == MouseButtonState.Pressed) 
            {
                App.events.OnMapTileClick(xCord, yCord);
            }
        }

        public void HandleChangeMapTile(object sender, ChangeMapTileEventArgs e)
        {
            if (xCord == e.XCord && yCord == e.YCord)
            {
                MapTileImage.Source = new BitmapImage(new Uri(e.SelectedTile, UriKind.Relative));

            }
        }
    }
}
