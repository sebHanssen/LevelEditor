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

namespace LevelEditor.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        private Image ImageTest = new();
        private string? selectedUserTile;
        public MainViewModel()
        {
        }

        public void SelectUserTile()
        {

        }
    }
}
