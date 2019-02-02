using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace FolderPlayerUWP
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        /// 
        UISettings uiSettings = new UISettings();
        
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            uiSettings.ColorValuesChanged += ColorValuesChanged;
        }

        private async void ColorValuesChanged(UISettings sender, object args)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                var appView = ApplicationView.GetForCurrentView();
                var newBackground = sender.GetColorValue(UIColorType.Background);
                UpdateTitleBar(appView, newBackground);
                
            });
        }

        private void UpdateTitleBar(ApplicationView appView, Color newBackground)
        {
            var titleBar = appView.TitleBar;

            if (newBackground == Colors.White)
            {
                var background = Colors.White;
                titleBar.BackgroundColor = background;
                titleBar.ButtonBackgroundColor = background;
                titleBar.InactiveBackgroundColor = background;
                titleBar.ButtonInactiveBackgroundColor = background;
            }
            else
            {
                Color darkColor = Color.FromArgb(255, 25, 25, 25);
                titleBar.BackgroundColor = darkColor;
                titleBar.ButtonBackgroundColor = darkColor;
                titleBar.InactiveBackgroundColor = darkColor;
                titleBar.ButtonInactiveBackgroundColor = darkColor;
            }
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            var appView = ApplicationView.GetForCurrentView();
            appView.SetPreferredMinSize(new Size(300, 400));
            UpdateTitleBar(appView);
           
            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(Shell), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
        }

        private void UpdateTitleBar(ApplicationView appView)
        {
            var backgroundBrush = (SolidColorBrush)Application.Current.Resources["ApplicationPageBackgroundThemeBrush"];
            var titleBar = appView.TitleBar;
            titleBar.BackgroundColor = backgroundBrush.Color;
            titleBar.ButtonBackgroundColor = backgroundBrush.Color;
            titleBar.InactiveBackgroundColor = backgroundBrush.Color;
            titleBar.ButtonInactiveBackgroundColor = backgroundBrush.Color;

        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
