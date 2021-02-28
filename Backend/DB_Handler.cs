using System;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace Expense_Tracker.Backend
{
    class DB_Handler
    {
        public const string connectionString = "Data Source=..\\..\\expenses.db;Version=3;";

        #region Write to DB
        public static bool SaveExpense(Expense newExpense)
        {
            uint newId = newExpense.Id;
            string newName = newExpense.Name;
            double newCost = Math.Round(newExpense.Cost, 2);
            string newDate = newExpense.Date;
            string newCategory = newExpense.Category;
            short newHour = newExpense.Hour;
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

        public static bool UpdateExpense(Expense newExpense)
        {
            uint newId = newExpense.Id;
            string newName = newExpense.Name;
            double newCost = Math.Round(newExpense.Cost, 2);
            string newDate = newExpense.Date;
            string newCategory = newExpense.Category;
            short newHour = newExpense.Hour;
            string details = newExpense.Details;

            try {
                using (SQLiteConnection con = new SQLiteConnection(connectionString)) {
                    con.Open();

                    string query = "UPDATE expense SET name=@1, cost=@2, date=@3, category=@4, hour=@5, details=@6 WHERE id=@0;";
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

        public static void GetAllExpenses(ListView myList)
        {
            try {
                using (SQLiteConnection con = new SQLiteConnection(connectionString)) {
                    con.Open();

                    string query = "SELECT * FROM expense";
                    using (SQLiteCommand command = new SQLiteCommand(query, con)) {
                        using (SQLiteDataReader reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                myList.Items.Add(new Expense(
                                        uint.Parse(reader[0].ToString()),
                                        reader[1].ToString(),
                                        double.Parse(reader[2].ToString()),
                                        reader[3].ToString(),
                                        reader[4].ToString(),
                                        short.Parse(reader[5].ToString()),
                                        reader[6].ToString()));
                            }
                        }
                    }
                    con.Dispose();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public static Expense GetExpenseFromId(uint id)
        {
            try {
                Expense myExpense = null;

                using (SQLiteConnection con = new SQLiteConnection(connectionString)) {
                    con.Open();

                    string query = "SELECT * FROM expense WHERE Id=@1";
                    using (SQLiteCommand command = new SQLiteCommand(query, con)) {
                        command.Parameters.AddWithValue("@1", id);
                        using (SQLiteDataReader reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                myExpense = new Expense(
                                        uint.Parse(reader[0].ToString()),
                                        reader[1].ToString(),
                                        double.Parse(reader[2].ToString()),
                                        reader[3].ToString(),
                                        reader[4].ToString(),
                                        short.Parse(reader[5].ToString()),
                                        reader[6].ToString());
                            }
                        }
                    }
                    con.Dispose();

                    return myExpense;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);

                return null;
            }
        }
        #endregion

        #region Delete from DB
        public static bool DeleteExpenseWithId(uint id)
        {
            try {
                using (SQLiteConnection con = new SQLiteConnection(connectionString)) {
                    con.Open();

                    string query = "DELETE FROM expense WHERE id=@0;";
                    using (SQLiteCommand command = new SQLiteCommand(query, con)) {
                        command.Parameters.AddWithValue("@0", id);

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
    }
}
