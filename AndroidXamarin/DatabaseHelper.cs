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
using Android.Util;

namespace TapGame
{
    class DatabaseHelper
    {
        string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public bool CreateDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folderPath, "tap_game.db")))
                {
                    connection.CreateTable<Result>();
                    return true;
                }
            }
            catch(SQLiteException exc)
            {
                Log.Info("SQLiteExc", exc.Message);
                return false;
            }
        }

        public bool Insert(Result result)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folderPath, "tap_game.db")))
                {
                    connection.Insert(result);
                    return true;
                }
            }
            catch (SQLiteException exc)
            {
                Log.Info("SQLiteExc", exc.Message);
                return false;
            }
        }

        public List<Result> GetAll()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folderPath, "tap_game.db")))
                {
                    return connection.Table<Result>().ToList();
                }
            }
            catch (SQLiteException exc)
            {
                Log.Info("SQLiteExc", exc.Message);
                return null;
            }
        }

        public List<Result> GetTopOf(int number)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folderPath, "tap_game.db")))
                {
                    return connection.Query<Result>("SELECT * FROM Result ORDER BY Points DESC LIMIT ?", number).ToList();
                }
            }
            catch (SQLiteException exc)
            {
                Log.Info("SQLiteExc", exc.Message);
                return null;
            }
        }

        public bool Update(Result result)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folderPath, "tap_game.db")))
                {
                    connection.Query<Result>("UPDATE Result set GamerName=?,Points=? WHERE ID=?", result.GamerName, result.Points,result.ID);
                    return true;
                }
            }
            catch (SQLiteException exc)
            {
                Log.Info("SQLiteExc", exc.Message);
                return false;
            }
        }

        public bool Remove(Result result)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folderPath, "tap_game.db")))
                {
                    connection.Delete(result);
                    return true;
                }
            }
            catch (SQLiteException exc)
            {
                Log.Info("SQLiteExc", exc.Message);
                return false;
            }
        }

        public Result Get(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folderPath, "tap_game.db")))
                {
                    return connection.Query<Result>("SELECT * FROM Result WHERE ID=?", id).FirstOrDefault();
                }
            }
            catch (SQLiteException exc)
            {
                Log.Info("SQLiteExc", exc.Message);
                return null;
            }
        }


    }
}