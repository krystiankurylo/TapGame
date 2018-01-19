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
    class ScoreAdapter : BaseAdapter<Result>
    {
        Context context;
        Result[] results;
        LayoutInflater inflater;

        public ScoreAdapter(Context context, Result[] results)
        {
            this.context = context;
            this.results = results;
            inflater = (LayoutInflater) this.context.GetSystemService(Context.LayoutInflaterService);
        }

        public override Result this[int position]
        {
            get
            {
                return results[position];
            }
        }

        public override int Count
        {
            get
            {
                return results.Length;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = inflater.Inflate(Resource.Layout.ScoreItem, null);
            var placeTextView = view.FindViewById<TextView>(Resource.Id.placeTextView);
            var nameTextView = view.FindViewById<TextView>(Resource.Id.nameTextView);
            var scoreTextView = view.FindViewById<TextView>(Resource.Id.scoreTextView);

            var currentScore = results[position];
            placeTextView.Text = (position + 1).ToString();
            nameTextView.Text = currentScore.GamerName;
            scoreTextView.Text = currentScore.Points.ToString();

            return view;
        }
    }
}