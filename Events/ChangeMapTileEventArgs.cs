﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor.Events
{
    public class ChangeMapTileEventArgs
    {
        public string? SelectedTile { get; set; }
        public int XCord { get; set; }
        public int YCord { get; set; }
    }
}
