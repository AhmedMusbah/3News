using System;
using Windows.UI.Xaml.Controls;
using Windows.Web.Syndication;

namespace _3NewsWIN
{
    class Feeds
    {
        private async void load(Windows.UI.Xaml.Controls.ItemsControl list, Uri uri)
        {
            SyndicationClient client = new SyndicationClient();
            SyndicationFeed feed = await client.RetrieveFeedAsync(uri);
            if (feed != null)
            {
                foreach (SyndicationItem item in feed.Items)
                {
                    list.Items.Add(item);
                }
            }
        }

        public void Go(ref ItemsControl list, string value)
        {
            try
            {
                load(list, new Uri(value));
            }
            catch
            {

            }
        }
    }
}
