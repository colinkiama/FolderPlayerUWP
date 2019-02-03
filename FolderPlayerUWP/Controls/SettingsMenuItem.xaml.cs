using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace FolderPlayerUWP.Controls
{
    public sealed partial class SettingsMenuItem : UserControl
    {


        #region Dependency Properties
        public string Glyph
        {
            get { return (string)GetValue(GlyphProperty); }
            set { SetValue(GlyphProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Glyph.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GlyphProperty =
            DependencyProperty.Register("Glyph", typeof(string), typeof(SettingsMenuItem), new PropertyMetadata(""));


        public string ItemName
        {
            get { return (string)GetValue(ItemNameProperty); }
            set { SetValue(ItemNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemNameProperty =
            DependencyProperty.Register("ItemName", typeof(string), typeof(SettingsMenuItem), new PropertyMetadata(""));



        public string ItemDescription
        {
            get { return (string)GetValue(ItemDescriptionProperty); }
            set { SetValue(ItemDescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemDescription.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemDescriptionProperty =
            DependencyProperty.Register("ItemDescription", typeof(string), typeof(SettingsMenuItem), new PropertyMetadata(""));



        #endregion



        public SettingsMenuItem()
        {
            this.InitializeComponent();
        }
    }
}
