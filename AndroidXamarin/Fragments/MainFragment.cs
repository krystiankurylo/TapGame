using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TapGame
{
    public class MainFragment : Fragment,View.IOnTouchListener
    {
        int counter = 0;
        bool allowTouch = true;
        bool firstTime = true;
        int seconds = 10;
        int minutes = 0;
        CountDownTimer timer;

    public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            MyCountDownTimer.GameFinished += FinishGame;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            MyCountDownTimer.GameFinished -= FinishGame;
        }

        //public override void OnDetach()
        //{
        //    base.OnDetach();
        //    MyCountDownTimer.GameFinished -= FinishGame;
        //    timer = null;
        //}

        //public override void OnAttach(Context context)
        //{
        //    base.OnAttach(context);

        //    counter = 0;
        //    allowTouch = true;
        //    firstTime = true;
        //    seconds = 10;
        //    minutes = 0;

        //}

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.MainFragment, container, false);
            view.SetOnTouchListener(this);
            return view;

        }

        private void FinishGame()
        {
            allowTouch = false;
            var tapView = Activity.FindViewById<TextView>(Resource.Id.tvTap);
            tapView.Text = "KONIEC";


            DatabaseHelper database = new DatabaseHelper();

            database.Insert(new Result(ActualPlayer.Instance.Name, counter));

            AlertDialog.Builder builder = new AlertDialog.Builder(this.Context);
            builder.SetMessage("Chcesz zagrać jeszcze raz?").SetPositiveButton("Tak", Restart).SetNegativeButton("Nie", Back).SetCancelable(false).Show();
        }

        private void Restart(object sender,EventArgs e)
        {
            Activity.Recreate();
        }

        private void Back(object sender,EventArgs e)
        {
            Activity.Finish();
        }

        public bool OnTouch(View v, MotionEvent e)
        {
            switch(e.Action)
            {
                case MotionEventActions.Down:
                    if (allowTouch)
                    {
                        if(firstTime)
                        {
                            var tapView = this.View.FindViewById<TextView>(Resource.Id.tvTap);
                            tapView.Text = "JAZDA";
                            start();
                            
                        }

                        counter++;
                        var textView = this.View.FindViewById<TextView>(Resource.Id.tvCounter);
                        textView.Text = counter.ToString();
                    }
                    break;
                case MotionEventActions.Up:
                    allowTouch = true;
                    break;
                   

            }
            

            return true;
        }

        private void start()
        {
            if(timer == null)
            {
                var textView = this.View.FindViewById<TextView>(Resource.Id.tvTime);
                timer = new MyCountDownTimer(minutes * 60000 + seconds * 1000, 1000, textView);
                timer.Start();
            }
        }

        private void cancel()
        {

        }
    }
}