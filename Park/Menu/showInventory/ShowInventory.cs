using Park;
using Park.spectre;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Park.Menu.MainMenus;
using Park.utils;
using Park.Menu.showInventory;
using Park.DB;
using Microsoft.Data.Sqlite;
using Park.Menu;

namespace Park.Menu.showInventory;

public class ShowInventory
{
    private string dbPath;
    private DatabaseManager db;

    public ShowInventory()
    {
        string dbPath = Path.Combine("DB", "park.sqlite"); // chemin vers ta base
        db = new DatabaseManager(dbPath);
        db.Connect(); // OK maintenant
    }

    public void DisplayInventory()
    {
        db.getInventory(); // ta méthode qui affiche l'inventaire
    }
}
