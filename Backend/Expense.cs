namespace Expense_Tracker.Backend
{
    class Expense
    {
        #region Member variables
        private uint id;
        private string name;
        private double cost;
        private string date;
        private string category;
        private short hour;
        private string details;
        #endregion

        #region Properties - Getters
        public uint Id { get { return this.id; } }
        public string Name { get { return this.name; } }

        public double Cost { get { return this.cost; } }

        public string Date { get { return this.date; } }

        public string Category { get { return this.category; } }

        public string Hour
        {
            get
            {
                if (this.hour >= 6 && this.hour < 12)
                    return "Morning";
                else if (this.hour == 12)
                    return "Noon";
                else if (this.hour > 12 && this.hour < 18)
                    return "Afternoon";
                else if (this.hour >= 18 && this.hour < 21)
                    return "Evening";
                else
                    return "Night";
            }
        }

        public string Details { get { return this.details; } }
        #endregion

        #region Properties - Validation Checks
        public bool HasValidName { get { return !this.name.Equals(string.Empty); } }
        public bool HasValidCost { get { return this.cost > 0; } }
        public bool HasValidHour { get { return this.hour >= 0 && this.hour <= 23; } }
        #endregion

        #region Constructors
        public Expense(uint id, string name, double cost, string date, string category, short hour, string details)
        {
            this.id = id;
            this.name = name;
            this.cost = cost;
            this.date = date;
            this.category = category;
            this.hour = hour;
            this.details = details;
        }

        public Expense(uint id, string name, double cost, string date, string category, short hour)
        {
            this.id = id;
            this.name = name;
            this.cost = cost;
            this.date = date;
            this.category = category;
            this.hour = hour;
            this.details = "-";
        }

        public Expense(uint id, string name, double cost, string date, short hour, string details)
        {
            this.id = id;
            this.name = name;
            this.cost = cost;
            this.date = date;
            this.category = "other";
            this.hour = hour;
            this.details = details;
        }

        public Expense(uint id, string name, double cost, string date, short hour)
        {
            this.id = id;
            this.name = name;
            this.cost = cost;
            this.date = date;
            this.category = "other";
            this.hour = hour;
            this.details = "-";
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            string myString = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}",
                this.id, this.name, this.cost, this.date, this.category, this.hour, this.details);

            return myString;
        }
        #endregion
    }
}