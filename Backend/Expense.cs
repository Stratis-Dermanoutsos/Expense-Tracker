namespace Expense_Tracker.Backend
{
    public class Expense
    {
        #region Member variables
        private uint id;
        private string name;
        private double cost;
        private string date;
        private uint year;
        private string category;
        private short hour;
        private string details;
        #endregion

        #region Properties - Getters
        public uint Id { get { return this.id; } }
        public string Name { get { return this.name; } }

        public double Cost { get { return this.cost; } }

        public string Date { get { return this.date; } }
        public uint Year { get { return this.year; } }

        public string Category { get { return this.category; } }
        public int CategoryIndex { 
            get { 
                switch (this.category) {
                    case "health care":
                        return 0;
                    case "food":
                        return 1;
                    case "drink":
                        return 2;
                    case "entertainment":
                        return 3;
                    case "vehicle":
                        return 4;
                    case "gift":
                        return 5;
                    case "pet":
                        return 6;
                    default:
                        return 7;
                } 
            } 
        }

        public short Hour { get { return this.hour; } }

        public string Details { get { return this.details; } }
        #endregion

        #region Properties - Validation Checks
        public bool HasValidName { get { return !this.name.Equals(string.Empty); } }
        public bool HasValidCost { get { return this.cost > 0; } }
        public bool HasValidHour { get { return this.hour >= 0 && this.hour <= 23; } }
        #endregion

        #region Constructors
        public Expense(uint id, string name, double cost, string date, uint year, string category, short hour, string details)
        {
            this.id = id;
            this.name = name;
            this.cost = cost;
            this.date = date;
            this.year = year;
            this.category = category;
            this.hour = hour;
            this.details = details;
        }

        public Expense(uint id, string name, double cost, string date, uint year, string category, short hour)
        {
            this.id = id;
            this.name = name;
            this.cost = cost;
            this.date = date;
            this.year = year;
            this.category = category;
            this.hour = hour;
            this.details = "-";
        }

        public Expense(uint id, string name, double cost, string date, uint year, short hour, string details)
        {
            this.id = id;
            this.name = name;
            this.cost = cost;
            this.date = date;
            this.year = year;
            this.category = "other";
            this.hour = hour;
            this.details = details;
        }

        public Expense(uint id, string name, double cost, string date, uint year, short hour)
        {
            this.id = id;
            this.name = name;
            this.cost = cost;
            this.date = date;
            this.year = year;
            this.category = "other";
            this.hour = hour;
            this.details = "-";
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            string myString = string.Format("{0}\n{1}\n{2}\n{3}-{4}\n{5}\n{6}\n{7}",
                this.id, this.name, this.cost, this.date, this.year, this.category, this.hour, this.details);

            return myString;
        }
        #endregion
    }
}