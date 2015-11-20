using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Net.Http;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;
using Android.Util;
using System.Collections.Generic;

namespace _3NewsAND
{
    [Activity(Label = "FilGoal", Icon = "@drawable/filgoal", Theme = "@android:style/Theme.Holo.Light")]
    public class FeedFilGoal : ListActivity
    {
        private RssItem[] _items;

        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            using (var client = new HttpClient())
            {
                var xmlFeed = await client.GetStringAsync("http://www.filgoal.com/arabic/rss/rss.xml");
                var doc = XDocument.Parse(xmlFeed);

                //XNamespace dc = "http://www.filgoal.com/arabic/rss/rss.xml";
                _items = (from item in doc.Descendants("item")
                          select new RssItem
                          {
                              Title = item.Element("title").Value,
                              PubDate = item.Element("pubDate").Value,
                              //Creator = item.Element(dc + "creator").Value,
                              Link = item.Element("link").Value
                          }).ToArray();

                ListAdapter = new FeedAdapter(this, _items);
            }
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);

            var second = new Intent(this, typeof(WebActivity));
            second.PutExtra("link", _items[position].Link);
            StartActivity(second);
        }

        /*
		 * attach the menu to the menu button of the device
		 * for this activity
		 */
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            base.OnCreateOptionsMenu(menu);

            MenuInflater inflater = this.MenuInflater;

            inflater.Inflate(Resource.Menu.mainmenu, menu);

            return true;
        }

        /// <param name="item">The menu item that was selected.</param>
		/// <summary>
		/// This hook is called whenever an item in your options menu is selected.
		/// </summary>
		/// <returns>To be added.</returns>
		public override bool OnOptionsItemSelected(IMenuItem item)
        {
            base.OnOptionsItemSelected(item);

            switch (item.ItemId)
            {
                case Resource.Id.btnYoum7:
                    {
                        Finish();
                        StartActivity(new Intent(this, typeof(FeedYoum7)));
                        break;
                    }

                case Resource.Id.btnFilGoal:
                    {
                        Finish();
                        StartActivity(new Intent(this, typeof(FeedFilGoal)));
                        break;
                    }

                case Resource.Id.btnWPcentral:
                    {
                        Finish();
                        StartActivity(new Intent(this, typeof(FeedWPcentral)));
                        break;
                    }
            }

            return true;
        }
    }
}

