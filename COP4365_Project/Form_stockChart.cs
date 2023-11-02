using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COP4365_Project
{
    public partial class Form_stockChart : Form_stockLoader
    {
        // Private BindingList of each Candlestick object, that other objects can bind to when the list changes
        private BindingList<Candlestick> candlesticks {  get; set; }

        // Private List that contains all Candlesticks in the current stock file including those outside the selected date range
        private List<Candlestick> unfilteredCandlesticksList { get; set; }


        // Public member function that initializes the entire form object
        public Form_stockChart(string filePath, List<Candlestick> unfilteredCandlesticksList, DateTime startDate, DateTime endDate)
        {
            // Initialize Component
            InitializeComponent();

            // Set the private members based on the passed in input parameters
            this.unfilteredCandlesticksList = unfilteredCandlesticksList;

            // Set the values of the dateTime pickers based on the passed in input parameters
            dateTimePicker_startDate.Value = startDate;
            dateTimePicker_endDate.Value = endDate;

            // Set the chart title name
            chart_candlesticks.Titles.Add(Path.GetFileNameWithoutExtension(filePath));

            // Call the filterCandlesticks function to filter the candlesticks by date and set the chart data source
            filterCandlesticks();
        }

        // Private member function that filters the candlestick binding list based on "new" user selected dates
        private void button_updateChart_Click(object sender, EventArgs e)
        {
            // Call the function that filters out the candlesticks based on the current user selected dates
            filterCandlesticks();
        }

        // Private member function to filter the candlesticks based on user selected dates
        public void filterCandlesticks()
        {
            // Initialize a new BindingList for the candlesticks member
            candlesticks = new BindingList<Candlestick>();

            // Make sure the candlesticks are in range with most recent row to date first in list candlesticks
            foreach (Candlestick cs in unfilteredCandlesticksList)
            {
                // Add only the candlesticks that are in the specified date range
                // If current date is greater than end date break because all remaining candlesticks will be outside of range
                if (cs.date > dateTimePicker_endDate.Value)
                {
                    break;
                }
                // If current date is within range add it to the candlesticks binding list
                if (cs.date >= dateTimePicker_startDate.Value)
                {
                    candlesticks.Add(cs);
                }
            }

            // Set the chart data source to the candlesticks binding list and bind the chart to the data source
            chart_candlesticks.DataSource = candlesticks;
            chart_candlesticks.DataBind();
        }
    }
}
