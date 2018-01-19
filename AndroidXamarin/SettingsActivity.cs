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
    [Activity(Label = "SettingsActivity")]
    public class SettingsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);

            Window.SetFlags(Android.Views.WindowManagerFlags.Fullscreen, Android.Views.WindowManagerFlags.Fullscreen);

            SetContentView(Resource.Layout.Settings);

            var saveChangesButton = FindViewById<Button>(Resource.Id.acceptChangesButton);
            saveChangesButton.Click += SaveChanges;

            ActualPlayer.Instance.LoadSettings();

            var playerNameEditText = FindViewById<EditText>(Resource.Id.playerNameEditText);
            playerNameEditText.Text = ActualPlayer.Instance.Name;
            playerNameEditText.SelectAll();
            
        }

        private void SaveChanges(object sender, EventArgs e)
        {
          

            var playerNameEditText = FindViewById<EditText>(Resource.Id.playerNameEditText);

            playerNameEditText.Error = null;

            var name = playerNameEditText.Text;

            if(string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                playerNameEditText.Error = "Nazwa użytkownika nie może być pusta";
            }
            else if(name.Length>10)
            {
                playerNameEditText.Error = "Nazwa użytkownika jest za długa (max 10 znaków)";
            }
            else
            {
                ActualPlayer.Instance.Name = name;
                ActualPlayer.Instance.SaveSettings();
            }
        }
    }
}