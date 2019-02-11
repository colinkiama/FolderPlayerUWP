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
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FolderPlayerUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NowPlayingView : Page
    {

        bool isNotMobile = false;
        public NowPlayingView()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().BackRequested += NowPlayingView_BackRequested;
            isNotMobile = !DeviceFamilyChecker.checkIfMoblie();
        }

        private async void NowPlayingView_BackRequested(object sender, BackRequestedEventArgs e)
        {
            await HideView();
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
