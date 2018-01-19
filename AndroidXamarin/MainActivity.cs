using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;
namespace TapGame
{
    [Activity]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Remove title bar
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);

            Window.SetFlags(Android.Views.WindowManagerFlags.Fullscreen, Android.Views.WindowManagerFlags.Fullscreen);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            var trans = FragmentManager.BeginTransaction();
            var newFragment = new MainFragment();
            trans.Replace(Resource.Id.fragmentContainer, newFragment, "MainFragment");
            trans.Commit();

        }
    }
}

