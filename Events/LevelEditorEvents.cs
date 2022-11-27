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
    }
}
