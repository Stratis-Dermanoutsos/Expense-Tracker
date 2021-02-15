using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker.Backend
{
    class Expense
    {
        #region Member variables
        private uint id;
        private string name;
        private float cost;
        private Int16 day;
        private Int16 dayOfMonth;
        private Int16 month;
        private Int16 category;
        private Int16 hour;
        #endregion

        #region Properties - Getters
        public uint Id { get { return this.id; } }
        public string Name { get { return this.name; } }

        public float Cost { get { return this.cost; } }

        public string Day
        {
            get
            {
                switch (this.day) {
                    case 1:
                        return "Sunday";
                    case 2:
                        return "Monday";
                    case 3:
                        return "Tuesday";
                    case 4:
                        return "Wednesday";
                    case 5:
                        return "Thursday";
                    case 6:
                        return "Friday";
                    default:
                        return "Saturday";
                }
            }
        }

        public Int16 DayOfMonth { get { return this.dayOfMonth; } }

        public string Month
        {
            get
            {
                switch (this.month) {
                    case 1:
                        return "January";
                    case 2:
                        return "February";
                    case 3:
                        return "March";
                    case 4:
                        return "April";
                    case 5:
                        return "May";
                    case 6:
                        return "June";
                    case 7:
                        return "July";
                    case 8:
                        return "August";
                    case 9:
                        return "September";
                    case 10:
                        return "October";
                    case 11:
                        return "November";
                    default:
                        return "December";
                }
            }
        }

        public string Category
        {
            get
            {
                switch (this.category) {
                    case 1:
                        return "health care";
                    case 2:
                        return "food";
                    case 3:
                        return "drink";
                    case 4:
                        return "entertainment";
                    case 5:
                        return "car";
                    case 6:
                        return "gift";
                    case 7:
                        return "pet";
                    default:
                        return "other";
                }
            }
        }

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
        #endregion

        #region Properties - Validation Checks
        public bool NameIsValid { get { return !this.name.Equals(string.Empty); } }
        public bool CostIsValid { get { return this.cost > 0; } }
        public bool DayIsValid { get { return this.day > 0 && this.day < 8; } }
        public bool DayOfMonthIsValid { get { return this.dayOfMonth > 0 && this.dayOfMonth < 32; } }
        public bool MonthIsValid { get { return this.month > 0 && this.month < 13; } }
        public bool CategoryIsValid { get { return this.category > 0 && this.category < 9; } }
        public bool HourIsValid { get { return this.hour > 0 && this.hour < 25; } }
        #endregion

        #region Constructors
        public Expense(uint id, string name, float cost, Int16 day, Int16 dayOfMonth, Int16 month, Int16 category, Int16 hour)
        {
            this.id = id;
            this.name = name;
            this.cost = cost;
            this.day = day;
            this.dayOfMonth = dayOfMonth;
            this.month = month;
            this.category = category;
            this.hour = hour;
        }

        public Expense(uint id, string name, float cost, Int16 day, Int16 dayOfMonth, Int16 month, Int16 hour)
        {
            this.id = id;
            this.name = name;
            this.cost = cost;
            this.day = day;
            this.dayOfMonth = dayOfMonth;
            this.month = month;
            this.category = 8;
            this.hour = hour;
        }
        #endregion
    }
}
