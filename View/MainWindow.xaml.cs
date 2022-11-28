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
using LevelEditor.Events;
using System.Windows.Media.Media3D;
using System.Diagnostics;

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
            App.events.DeployLevel += HandleDeployLevel;
        }

        private void NewLevelClick(object sender, RoutedEventArgs e)
        {
            newLevelWindow.Show();
        }

        private void LoadDefaultUserTiles(object sender, RoutedEventArgs e)
        {
            UserTileGrid.Children.Clear();

            UserTile defaultTile1 = new()
            {
                ImageSource = "/Resources/empty.png"
            };
            DockPanel.SetDock(defaultTile1, Dock.Top);
            UserTileGrid.Children.Add(defaultTile1);

            UserTile defaultTile2 = new()
            {
                ImageSource = "/Resources/grass.png"
            };
            DockPanel.SetDock(defaultTile2, Dock.Top);
            UserTileGrid.Children.Add(defaultTile2);

            UserTile defaultTile3 = new()
            {
                ImageSource = "/Resources/water.png"
            };
            DockPanel.SetDock(defaultTile3, Dock.Top);
            UserTileGrid.Children.Add(defaultTile3);
        }

        private void HandleDeployLevel(object sender, DeployLevelEventArgs e)
        {
            TileGrid.Children.Clear();
            for (int i = 0; i < e.Height; i++)
            {
                DockPanel dockPanel = new DockPanel();
                dockPanel.VerticalAlignment = VerticalAlignment.Top;
                DockPanel.SetDock(dockPanel, Dock.Top);
                TileGrid.Children.Add(dockPanel);
                for(int j = 0; j < e.Width; j++)
                {
                    MapTile mapTile = new()
                    {
                        ImageSource = "/Resources/empty.png"
                    };
                    DockPanel.SetDock(mapTile, Dock.Left);
                    dockPanel.Children.Add(mapTile);
                }
            }
        }
    }
}
