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
    public class ActualPlayer
    {
        private static ActualPlayer instance;


        public static ActualPlayer Instance
        {
            get
            {
                if (instance == null)
                    instance = new ActualPlayer();

                return instance;
            }
        }


        public string Name
        {
            get;
            set;
        }

        private ActualPlayer()
        {
            Name = "Anonim";
        }

        public void SaveSettings()
        {
            //store
            var prefs = Application.Context.GetSharedPreferences("TapGame", FileCreationMode.Private);
            var prefEditor = prefs.Edit();
            prefEditor.PutString("PlayerName", Name);
            prefEditor.Commit();
        }

        public void LoadSettings()
        {
            //retreive 
            var prefs = Application.Context.GetSharedPreferences("TapGame", FileCreationMode.Private);
            var somePref = prefs.GetString("PlayerName", null);

            if(!string.IsNullOrEmpty(somePref))
            {
                Name = somePref;
            }        
        }
    }
}