using System;
using System.Data.SQLite;
using System.Windows;

namespace Expense_Tracker.Backend
{
    class DB_Handler
    {
        public const string connectionString = "Data Source=..\\..\\Backend\\expenses.db;Version=3;";

        #region Write to DB
        public static bool SaveExpense(Expense newExpense)
        {
            uint newId = newExpense.Id;
            string newName = newExpense.Name;
            double newCost = Math.Round(newExpense.Cost, 2);
            string newDate = newExpense.Date;
            string newCategory = newExpense.Category;
            string newHour = newExpense.Hour;
            string details = newExpense.Details;

            try {
                using (SQLiteConnection con = new SQLiteConnection(connectionString)) {
                    con.Open();

                    string query = "INSERT INTO expense VALUES (@0, @1, @2, @3, @4, @5, @6);";
                    using (SQLiteCommand command = new SQLiteCommand(query, con)) {
                        command.Parameters.AddWithValue("@0", newId);
                        command.Parameters.AddWithValue("@1", newName);
                        command.Parameters.AddWithValue("@2", newCost);
                        command.Parameters.AddWithValue("@3", newDate);
                        command.Parameters.AddWithValue("@4", newCategory);
                        command.Parameters.AddWithValue("@5", newHour);
                        command.Parameters.AddWithValue("@6", details);

                        command.ExecuteNonQuery();
                    }
                    con.Dispose();
                }
                return true;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        #endregion

        #region Read from DB
        public static uint Count
        {
            get
            {
                try {
                    uint result;
                    using (SQLiteConnection con = new SQLiteConnection(connectionString)) {
                        con.Open();

                        string query = "SELECT seq FROM sqlite_sequence WHERE name = 'expense';";
                        using (SQLiteCommand command = new SQLiteCommand(query, con)) {
                            object obj = command.ExecuteScalar();
                            result = uint.Parse(obj.ToString()) + 1;
                        }
                        con.Dispose();
                    }
                    return result;
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
        #endregion
    }
}
