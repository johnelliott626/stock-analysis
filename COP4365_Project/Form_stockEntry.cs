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
    public partial class Form_stockEntry : Form
    {
        // Private BindingList of each Candlestick object, that other objects can bind to when the list changes
        private BindingList<Candlestick> candlesticks {  get; set; }

        // Private temporary list for initial loading of stock data with memory allocation set to 1024 as most CSV files are in this range
        private List<Candlestick> tempList = new List<Candlestick>(1024);
        public Form_stockEntry()
        {
            InitializeComponent();
        }

        // Private member function that executes when loadStocks button is clicked
        private void button_loadStocks_Click(object sender, EventArgs e)
        {
            // Show the openFileDialog so user can select a stock and ensure a file is selected
            DialogResult result = openFileDialog_stockLoader.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Declare variables to store the selected file name and header format of the CSV files
                String fn = openFileDialog_stockLoader.FileName;
                Text = fn;
                String referenceString = "\"Ticker\",\"Period\",\"Date\",\"Open\",\"High\",\"Low\",\"Close\",\"Volume\"";


                // try multiselect and clear old data
                string[] filenames = openFileDialog_stockLoader.FileNames;
                tempList.Clear();

                // Use stream reader to read in file data
                using (StreamReader sr = new StreamReader(fn))
                {
                    // Variable to store each CSV line of data
                    string line;

                    // First read the CSV header
                    string header = sr.ReadLine();

                    // If the header is correct
                    if (header == referenceString)
                    {
                        // Read in the CSV file line by line
                        while ((line = sr.ReadLine()) != null)
                        {
                            // Instantiate new candlestick
                            Candlestick cs = new Candlestick(line);

                            // Add it to the temporary list
                            tempList.Add(cs);
                        }
                        // Make templist in chronological order
                        tempList.Reverse();

                        // Call function that filters the candlesticks based on the user selected dates
                        filterCandlesticks();

                        // Clear the old chart title and set it to the currently selected path
                        chart_candlesticks.Titles.Clear();
                        chart_candlesticks.Titles.Add(Path.GetFileNameWithoutExtension(openFileDialog_stockLoader.FileName));
                    }
                }
            }
        }

        // Private member function to filter the candlesticks based on user selected dates
        private void filterCandlesticks()
        {
            // Initialize a new BindingList for the candlesticks member
            candlesticks = new BindingList<Candlestick>();

            // Make sure the candlesticks are in range with most recent row to date first in list candlesticks
            foreach (Candlestick cs in tempList)
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

            // Connect the dataGridView to the updated list of candlesticks
            dataGridView_stockData.DataSource = candlesticks;
        }

        // Private member function that filters the candlestick binding list based on "new" user selected dates
        private void button_updateChart_Click(object sender, EventArgs e)
        {
            // Call the function that filters out the candlesticks based on the current user selected dates
            filterCandlesticks();
        }
    }
}
