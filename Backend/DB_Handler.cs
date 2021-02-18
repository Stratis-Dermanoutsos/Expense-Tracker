using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker.Backend
{
    class DB_Handler
    {
        public const string connectionString = "Data Source=..\\..\\..\\Backend\\expenses.db;Version=3;";

        public static uint Count
        {
            get
            {
                try {
                    using (SQLiteConnection con = new SQLiteConnection(connectionString)) {
                        string query = "SELECT COALESCE(MAX(id)+1, 0) FROM expense";
                        using (SQLiteCommand command = new SQLiteCommand(query, con)) {
                            uint result = (uint)command.ExecuteScalar();

                            return result;
                        }
                    }
                } catch (Exception) {
                    return 0;
                }
            }
        }
    }
}
