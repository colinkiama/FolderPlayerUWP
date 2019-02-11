using FolderPlayerUWP.Helpers;
using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FolderPlayerUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NowPlayingView : Page
    {



        public Windows.UI.Color albumGlowColor
        {
            get { return (Windows.UI.Color)GetValue(albumGlowColorProperty); }
            set { SetValue(albumGlowColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for albumGlowColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty albumGlowColorProperty =
            DependencyProperty.Register("albumGlowColor", typeof(Windows.UI.Color), typeof(NowPlayingView), new PropertyMetadata(null));



        bool isNotMobile = false;

        
        public NowPlayingView()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().BackRequested += NowPlayingView_BackRequested;
            isNotMobile = !DeviceFamilyHelper.checkIfMoblie();
            AlbumImage.ImageOpened += ArtistImage_ImageOpened;
        }

        private async void ArtistImage_ImageOpened(object sender, RoutedEventArgs e)
        {
            Image openedImage = sender as Image;
            albumGlowColor = await ImageColorHelper.GetDominantColorFromImageAsync(openedImage);
            
        }



        private async void NowPlayingView_BackRequested(object sender, BackRequestedEventArgs e)
        {
            await HideView();
            e.Handled = true;
        }

        private async Task HideView()
        {
            var anim = this.Offset(0, (float)Window.Current.Bounds.Height);
            anim.Completed += Anim_Completed;
            await anim.StartAsync();
        }

        private void Anim_Completed(object sender, AnimationSetCompletedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private async void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            await HideView();
        }
    }
}
