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
    [Activity(MainLauncher = true)]
    public class MenuActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);

            Window.SetFlags(Android.Views.WindowManagerFlags.Fullscreen, Android.Views.WindowManagerFlags.Fullscreen);
            // Create your application here

            SetContentView(Resource.Layout.Menu);

            var startGameButton = this.FindViewById<Button>(Resource.Id.startGameButton);
            startGameButton.Click += startMainActivity;

            var showResultsButton = this.FindViewById<Button>(Resource.Id.showResultsButton);
            showResultsButton.Click += startScoresActivity;

            var settingsButton = this.FindViewById<Button>(Resource.Id.settingsButton);
            settingsButton.Click += startSettingsActivity;

            var helloTextView = this.FindViewById<TextView>(Resource.Id.helloTextView);
            helloTextView.Text = "Witaj " + ActualPlayer.Instance.Name + "!";

           

            //DatabaseHelper database = new DatabaseHelper();

            //database.CreateDatabase();

            //database.Insert(new Result("ARTUR", 10));
            //database.Insert(new Result("KRYSTIAN", 50));
            //database.Insert(new Result("DAMIAN", 26));
            //database.Insert(new Result("ROMEK", 0));
            //database.Insert(new Result("PIOTREK", 11));
            //database.Insert(new Result("ŁUKASZ", 110));
            //database.Insert(new Result("TOMEK", 111));
            //database.Insert(new Result("AREK", 98));
            //database.Insert(new Result("PAWEŁ", 78));
            //database.Insert(new Result("MATI", 55));
            //database.Insert(new Result("KUBA", 44));
            //database.Insert(new Result("KACPET", 23));
            //database.Insert(new Result("DANIEL", 11));
            //database.Insert(new Result("FILIP", 66));
            //database.Insert(new Result("BARTEK", 77));

            ActualPlayer.Instance.LoadSettings();
        }

        protected override void OnResume()
        {
            base.OnResume();

            var helloTextView = this.FindViewById<TextView>(Resource.Id.helloTextView);
            helloTextView.Text = "Witaj " + ActualPlayer.Instance.Name + "!";
        }

        private void startMainActivity(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }

        private void startScoresActivity(object sender, EventArgs e)
        {
            StartActivity(typeof(ScoresActivity));
        }

        private void startSettingsActivity(object sender,EventArgs e)
        {
            StartActivity(typeof(SettingsActivity));
        }
    }
}