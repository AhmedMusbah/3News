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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace _3NewsWIN
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FilGoal : Page
    {
        public FilGoal()
        {
            this.InitializeComponent();
            var feeds = new Feeds();
            feeds.Go(ref Items, "http://www.filgoal.com/arabic/rss/rss.xml");

            btnFilGoal.IsEnabled = false;
        }

        private void btnYoum7_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Youm7));
        }

        private void btnFilGoal_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(FilGoal));
        }

        private void btnWPcentral_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WPcentral));
        }
    }
}
