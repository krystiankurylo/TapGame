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
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Xamarin.Android;

namespace TapGame
{
    [Activity(Label = "GraphActivity")]
    public class GraphActivity : Activity
    {
        private PlotView plotView;
        public PlotModel MyModel { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            // BarChartView

            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);

            Window.SetFlags(Android.Views.WindowManagerFlags.Fullscreen, Android.Views.WindowManagerFlags.Fullscreen);

            SetContentView(Resource.Layout.Graph);

            plotView = FindViewById<PlotView>(Resource.Id.plotView);



            MyModel = new PlotModel { Title = "Wyniki poszczególnych graczy" };
            DatabaseHelper database = new DatabaseHelper();
            var results = database.GetAll().OrderByDescending(r=> r.Points);
            List<BarItem> barItems = new List<BarItem>();

            var gamerNames = results.Select(r => r.GamerName).Distinct().ToList();

            var barSeries = new BarSeries();

            foreach(var gamerName in gamerNames)
            {
                var queryResult = results
             .Where(r => r.GamerName == gamerName).Max(r => r.Points);

                System.Diagnostics.Debug.WriteLine("RESULT: " + queryResult);
                barSeries.Items.Add(new BarItem(queryResult));
            }
            barSeries.LabelPlacement = LabelPlacement.Inside;

            MyModel.Series.Add(barSeries);

            MyModel.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Left,
                Key = "GamerNames",
                ItemsSource = gamerNames.ToArray()
            });

            plotView.Model = MyModel;


        }
    }
}