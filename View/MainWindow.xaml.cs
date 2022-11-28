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
using Newtonsoft.Json;
using System.IO;

namespace LevelEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NewLevelWindow newLevelWindow = new NewLevelWindow();

        private int currentHeight;
        private int currentWidth;

        public MainWindow()
        {
            DataContext = new MainViewModel();
            InitializeComponent();
            App.events.DeployLevel += HandleDeployLevel;

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

        private void NewLevelClick(object sender, RoutedEventArgs e)
        {
            newLevelWindow.Show();
        }

        private void LoadDefaultUserTiles(object sender, RoutedEventArgs e)
        {
            UserTileGrid.Children.RemoveRange(1, UserTileGrid.Children.Count - 1);

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

        private void SaveMap(object sender, RoutedEventArgs e)
        {
            var map = new string[currentHeight, currentWidth];
            foreach (DockPanel d in TileGrid.Children)
            {
                foreach(MapTile m in d.Children)
                {
                    if(m.ImageSource == "/Resources/empty.png")
                    {
                        map[m.yCord - 1, m.xCord - 1] = "x";
                    }
                    if(m.ImageSource == "/Resources/grass.png")
                    {
                        map[m.yCord - 1, m.xCord - 1] = "g";
                    }
                    if(m.ImageSource == "/Resources/water.png")
                    {
                        map[m.yCord - 1, m.xCord - 1] = "w";
                    }
                }
            }
            File.WriteAllText(@"data.json", JsonConvert.SerializeObject(map, Formatting.None));
        }

        private void LoadMap(object sender, RoutedEventArgs e)
        {
            TileGrid.Children.Clear();
            if (!File.Exists(@"data.json"))
            {
                return;
            }
            string json = File.ReadAllText(@"data.json");
            string[,]? map = JsonConvert.DeserializeObject<string[,]>(json);
            int savedHeight = map.GetLength(0);
            int savedWidth = map.GetLength(1);
            for (int i = 0; i < savedHeight; i++) 
            {
                DockPanel dockPanel = new()
                {
                    VerticalAlignment = VerticalAlignment.Top
                };
                DockPanel.SetDock(dockPanel, Dock.Top);
                TileGrid.Children.Add(dockPanel);
                for (int j = 0; j < savedWidth; j++)
                {
                    MapTile mapTile = new()
                    {
                        yCord = i + 1,
                        xCord = j + 1
                    };
                    if (map[i,j] == "x")
                    {
                        mapTile.ImageSource = "/Resources/empty.png";
                    }
                    if (map[i, j] == "g")
                    {
                        mapTile.ImageSource = "/Resources/grass.png";
                    }
                    if (map[i, j] == "w")
                    {
                        mapTile.ImageSource = "/Resources/water.png";
                    }
                    {
                        DockPanel.SetDock(mapTile, Dock.Left);
                        dockPanel.Children.Add(mapTile);
                    }
                }
            }
            currentHeight = savedHeight;
            currentWidth = savedWidth;
        }

        private void HandleDeployLevel(object sender, DeployLevelEventArgs e)
        {
            TileGrid.Children.Clear();
            for (int i = 0; i < e.Height; i++)
            {
                DockPanel dockPanel = new()
                {
                    VerticalAlignment = VerticalAlignment.Top
                };
                DockPanel.SetDock(dockPanel, Dock.Top);
                TileGrid.Children.Add(dockPanel);
                for(int j = 0; j < e.Width; j++)
                {
                    MapTile mapTile = new()
                    {
                        yCord = i + 1,
                        xCord = j + 1
                        
                    };
                    DockPanel.SetDock(mapTile, Dock.Left);
                    dockPanel.Children.Add(mapTile);
                }
            }
            currentHeight = e.Height;
            currentWidth = e.Width;
        }
    }
}
