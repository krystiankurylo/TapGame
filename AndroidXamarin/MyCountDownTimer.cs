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
    public class MyCountDownTimer : CountDownTimer
    {
        string minutesString;
        string secondsString;
        string message;
        TextView view;
        public static Action GameFinished;

        public MyCountDownTimer(long milisInFuture,long interval, TextView textView) : base(milisInFuture,interval)
        {
            view = textView;
        }

        public override void OnFinish()
        {
            message = "00:00";
            view.Text = message;

            GameFinished?.Invoke();
        }

        public override void OnTick(long millisUntilFinished)
        {
            int seconds = (int)(millisUntilFinished / 1000) % 60;
            int minutes = (int)((millisUntilFinished / (1000 * 60)) % 60);
            minutesString = minutes.ToString();
            if (minutesString.Length < 2)
                minutesString = "0" + minutesString;

            secondsString = seconds.ToString();
            if (secondsString.Length < 2)
                secondsString = "0" + secondsString;

            message = minutesString + ":" + secondsString;

            view.Text = message;
        }
    }
}