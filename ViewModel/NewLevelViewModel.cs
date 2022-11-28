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

namespace LevelEditor.ViewModel
{
    public partial class NewLevelViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? errorText;
        public NewLevelViewModel()
        {
            App.events.CreateLevel += HandleCreateLevel;
        }

        private void HandleCreateLevel(object sender, CreateLevelEventArgs e)
        {
            bool heightSuccess = int.TryParse(e.Height, out int HeightValue);
            if (!heightSuccess)
            {
                ErrorText = "Invalid Input: Only numbers allowed";
            }

            bool widthSuccess = int.TryParse(e.Width, out int WidthValue);
            if (!widthSuccess)
            {
                ErrorText = "Invalid Input: Only numbers allowed";
            }

            if(heightSuccess && widthSuccess)
            {
                if(HeightValue > 0 && HeightValue <= 100 && WidthValue > 0 && WidthValue <= 100)
                {
                    ErrorText = "";
                    App.events.OnDeployLevel(HeightValue, WidthValue);
                } else
                {
                    ErrorText = "Invalid Input: Only values between 1 and 100 allowed";
                }
            }
        }
    }
}
