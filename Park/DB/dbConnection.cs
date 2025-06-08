using Park;
using Park.spectre;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Park.Menu.MainMenu;
using Park.utils;
using Park.DB;
using Microsoft.Data.Sqlite;
namespace Park.DB;

public class dbConnection
{
    public void SqliteConnection()
    {
        string dbPath = "./DB/park.sqlite"; // ou le chemin vers ta base
        DatabaseManager db = new DatabaseManager(dbPath);
        db.Connect();
        

    }
}