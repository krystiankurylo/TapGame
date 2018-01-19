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

namespace TapGame
{
    [Activity]
    public class ScoresActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            Window.SetFlags(Android.Views.WindowManagerFlags.Fullscreen, Android.Views.WindowManagerFlags.Fullscreen);

            SetContentView(Resource.Layout.Scores);

            var scoresListView = FindViewById<ListView>(Resource.Id.scoresListView);

            DatabaseHelper database = new DatabaseHelper();

            var results = database.GetTopOf(10).ToArray();

            scoresListView.Adapter = new ScoreAdapter(this, results);
            // Create your application here

            var showGraphButton = FindViewById<Button>(Resource.Id.showGraphButton);
            showGraphButton.Click += startGraphActivity;
        }

        void startGraphActivity(object sender,EventArgs e)
        {
            StartActivity(typeof(GraphActivity));
        }
    }
}