using FolderPlayerUWP.Views;
using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FolderPlayerUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Shell : Page
    {
        public Shell()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().BackRequested += Shell_BackRequested;
        }

        private void Shell_BackRequested(object sender, BackRequestedEventArgs e)
        {
            e.Handled = true;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
           base.OnNavigatedTo(e);
            await NowPlayingViewDown();
        }

        private async void MiniPlayer_ExpandButtonClicked(object sender, RoutedEventArgs e)
        {
            await NowPlayingViewDown();
            await NowPlayingViewUp();
            
        }

        private async Task NowPlayingViewUp()
        {
            NowPlayingViewObject.Visibility = Visibility.Visible;
            await NowPlayingViewObject.Offset(0).StartAsync();
        }

        private async Task NowPlayingViewDown()
        {
            NowPlayingViewObject.Visibility = Visibility.Collapsed;
            await NowPlayingViewObject.Offset(0, (float)(Window.Current.Bounds.Height), 0).StartAsync();
        }
    }
}
