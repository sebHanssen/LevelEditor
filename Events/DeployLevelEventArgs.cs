using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor.Events
{
    public class DeployLevelEventArgs
    {
        public int Height { get; set; }
        public int Width { get; set; }
    }
}
