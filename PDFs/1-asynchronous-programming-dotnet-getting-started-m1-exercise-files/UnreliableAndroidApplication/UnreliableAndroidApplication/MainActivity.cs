using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Net;

namespace UnreliableAndroidApplication
{
    [Activity(Label = "UnreliableAndroidApplication", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.Main);
            
            var counterButton = FindViewById<Button>(Resource.Id.CounterButton);
            var rssButton = FindViewById<Button>(Resource.Id.RssButton);

            counterButton.Click += delegate {
                var counterTextView = FindViewById<TextView>(Resource.Id.CounterText);
                counterTextView.Text = $"Counter {count++}";
            };

            rssButton.Click += delegate {
                var client = new WebClient();
                var data = client.DownloadString("http://www.filipekberg.se/rss/");

                var rssTextView = FindViewById<TextView>(Resource.Id.Rss);

                rssTextView.Text = data;
            };
        }
    }
}

