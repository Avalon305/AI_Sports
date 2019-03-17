using System;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public static class DataAccess
    {
        public static void InitializeDatabase()
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS MyTable (Primary_Key INTEGER PRIMARY KEY, " +
                    "Text_Entry NVARCHAR(2048) NULL)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }
    }
    
}
