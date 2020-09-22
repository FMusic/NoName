using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementApp.Model
{
    public class Revenue
    {
        public DateTime Date { get; set; }
        public double TotalRevenue { get; set; }
        public string DateV
        {
            get
            {
                return $"{Date.Day}.{Date.Month} - {Date.DayOfWeek}";
            }
        }
    }
}
