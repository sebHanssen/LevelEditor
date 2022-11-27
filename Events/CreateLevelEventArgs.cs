using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor.Events
{
    public class CreateLevelEventArgs
    {
        public string? Height { get; set; }
        public string? Width { get; set; }
    }
}
