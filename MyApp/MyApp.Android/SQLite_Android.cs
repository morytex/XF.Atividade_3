﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using MyApp;
using MyApp.Android;
using MyApp.Data;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace MyApp.Android
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }

        public SQLite.SQLiteConnection GetConexao()
        {
            var arquivodb = "fiapdb.db";
            string caminho = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var local = Path.Combine(caminho, arquivodb);

            var conexao = new SQLite.SQLiteConnection(local);
            return conexao;
        }
    }
}