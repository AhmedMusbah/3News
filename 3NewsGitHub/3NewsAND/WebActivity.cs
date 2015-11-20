using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Webkit;

namespace _3NewsAND
{
    [Activity(Label = "WebActivity", Theme = "@android:style/Theme.Holo.Light.NoActionBar.Fullscreen")]
    public class WebActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.WebActivity);

            WebView view = FindViewById<WebView>(Resource.Id.DetailView);
            var url = Intent.GetStringExtra("link");
            view.SetWebViewClient(new WebViewClient());
            view.Settings.JavaScriptEnabled = true;
            view.LoadUrl(url);
        }
    }
}