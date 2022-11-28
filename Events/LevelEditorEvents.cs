using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor.Events
{
    public class LevelEditorEvents
    {
        public delegate void CreateLevelEventHandler(object sender, CreateLevelEventArgs e);

        public event CreateLevelEventHandler? CreateLevel;

        public virtual void OnCreateLevel(string? height, string? width)
        {
            CreateLevel?.Invoke(this, new CreateLevelEventArgs { Height = height, Width = width});
        }


        public delegate void DeployLevelEventHandler(object sender, DeployLevelEventArgs e);

        public event DeployLevelEventHandler? DeployLevel;

        public virtual void OnDeployLevel(int height, int width)
        {
            DeployLevel?.Invoke(this, new DeployLevelEventArgs { Height = height, Width = width });
        }


        public delegate void SelectTileEventHandler(object sender, SelectTileEventArgs e);

        public event SelectTileEventHandler? SelectTile;

        public virtual void OnSelectTile(string? tile)
        {
            SelectTile?.Invoke(this, new SelectTileEventArgs { Tile = tile });
        }


        public delegate void MapTileClickEventHandler(object sender, MapTileClickEventArgs e);

        public event MapTileClickEventHandler? MapTileClick;

        public virtual void OnMapTileClick(int xCord, int yCord)
        {
            MapTileClick?.Invoke(this, new MapTileClickEventArgs {XCord = xCord, YCord = yCord });
        }


        public delegate void ChangeMapTileEventHandler(object sender, ChangeMapTileEventArgs e);

        public event ChangeMapTileEventHandler? ChangeMapTile;

        public virtual void OnChangeMapTile(string? selectedTile, int xCord, int yCord)
        {
            ChangeMapTile?.Invoke(this, new ChangeMapTileEventArgs { SelectedTile = selectedTile, XCord = xCord, YCord = yCord});
        }
    }
}
