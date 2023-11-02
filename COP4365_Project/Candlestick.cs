using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace COP4365_Project
{
    // Class to represent each Candlestick object
    public class Candlestick
    {
        public Decimal open { get; set; }   // Public member to store stock open price
        public Decimal high { get; set; }   // Public member to store stock high price
        public Decimal low { get; set; }    // Public member to store stock low price
        public Decimal close { get; set; }  // Public member to store stock close price
        public long volume { get; set; }    // Public member to store stock trade volume
        public DateTime date { get; set; }  // Public member to store date of candlestick

        // Default Constructor
        public Candlestick() 
        { 
            date = DateTime.Now;
            open = new Decimal(0);
            high = new Decimal(0);
            low = new Decimal(0);
            close = new Decimal(0);
            volume = 0;
        }

        // Constructor with input arguments to initialize class members, each set to a default of zero
        public Candlestick(DateTime date, Decimal open = 0, Decimal high = 0, Decimal low = 0, Decimal close = 0, long volume = 0)
        {
            // Set each instance member according to its corresponding input parameter
            this.date = date;
            this.open = open;
            this.high = high;
            this.low = low;
            this.close = close;
            this.volume = volume;
        }

        // Constructor to create a Candlestick object based on an input row of data that needs to be parsed
        public Candlestick(String rowOfData)
        {
            // Variable declarations
            char[] separators = new char[] { ',', ' ', '"', '-' };  // Variable that stores characters our CSV data is separated by
            string[] separatedRowData = rowOfData.Split(separators, StringSplitOptions.RemoveEmptyEntries);    // Split row of data into a string array

            // Create a dictionary to map Month names to an integer value corresponding to that month
            Dictionary<string, int> map = new Dictionary<string, int>();
            int i = 1;
            map.Add("Jan", i++);
            map.Add("Feb", i++);
            map.Add("Mar", i++);
            map.Add("Apr", i++);
            map.Add("May", i++);
            map.Add("Jun", i++);
            map.Add("Jul", i++);
            map.Add("Aug", i++);
            map.Add("Sep", i++);
            map.Add("Oct", i++);
            map.Add("Nov", i++);
            map.Add("Dec", i++);

            // Declare helper variables to help parse the row of CSV data and assign it to the Candlestick instance
            bool success;
            Decimal decimalTemp;
            long longTemp;
            int day, year;
            String month;

            // Assign class members based on input row of data
            // based on order: "Ticker","Period","Date-Month","Date-Day","Date-Year","Open","High","Low","Close","Volume"
            month = separatedRowData[2];
            success = int.TryParse(separatedRowData[3], out day);
            success = int.TryParse(separatedRowData[4], out year);
            date = new DateTime(year, map[month], day);
            success = Decimal.TryParse(separatedRowData[5], out decimalTemp);
            open = decimalTemp;
            success = Decimal.TryParse(separatedRowData[6], out decimalTemp);
            high = decimalTemp;
            success = Decimal.TryParse(separatedRowData[7], out decimalTemp);
            low = decimalTemp;
            success = Decimal.TryParse(separatedRowData[8], out decimalTemp);
            close = decimalTemp;
            success = long.TryParse(separatedRowData[9], out longTemp);
            volume = longTemp;
        }
    }
}
