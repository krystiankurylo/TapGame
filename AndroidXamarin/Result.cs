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
using SQLite;

namespace TapGame
{
    public class Result
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string GamerName { get; set; }

        public int Points { get; set; }

        public override string ToString()
        {
            return GamerName + " " + Points;
        }

        public Result(string gamerName,int points)
        {
            GamerName = gamerName;
            Points = points;
        }

        public Result()
        {
            GamerName = "no_name";
            Points = 0;
        }
    }
}