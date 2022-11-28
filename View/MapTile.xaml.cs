﻿using System;
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


namespace LevelEditor.View
{
    /// <summary>
    /// Interaction logic for MapTile.xaml
    /// </summary>
    public partial class MapTile : UserControl
    {
        
        public MapTile()
        {
            InitializeComponent();
        }

        public string? ImageSource
        {
            get
            {
                return (string)GetValue(ImageSourceProperty);
            }
            set
            {
                SetValue(ImageSourceProperty, value);
            }
        }
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(string),
                typeof(MapTile), new PropertyMetadata("/Resources/empty.png"));


        private void ClickMapTile(object sender, RoutedEventArgs e)
        {

        }
    }
}
