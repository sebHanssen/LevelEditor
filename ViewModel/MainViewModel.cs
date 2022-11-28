using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Navigation;
using Newtonsoft.Json;
using System.Windows.Media.Animation;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Printing;
using CommunityToolkit.Mvvm.Input;
using System.IO;
using LevelEditor.Events;
using System.Windows.Controls;
using System;
using System.Diagnostics;
using LevelEditor.View;

namespace LevelEditor.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? selectedUserTile;

        public MainViewModel()
        {
            SelectedUserTile = "/Resources/empty.png";
            App.events.SelectTile += HandleSelectTile;
            App.events.MapTileClick += HandleMapTileClick;
        }

        public void HandleSelectTile(object sender, SelectTileEventArgs e)
        {
            SelectedUserTile = e.Tile;
        }

        public void HandleMapTileClick(object sender, MapTileClickEventArgs e)
        {
            App.events.OnChangeMapTile(SelectedUserTile, e.XCord, e.YCord);
        }
    }
}
