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
    public partial class Form_stockLoader : Form
    {
        // Private static variable for defining the format of the CSV file headers
        private static String referenceHeaderString = "\"Ticker\",\"Period\",\"Date\",\"Open\",\"High\",\"Low\",\"Close\",\"Volume\"";
        
        // Form constructor member
        public Form_stockLoader()
        {
            InitializeComponent();
        }

        // Private member function that executes when the button_loadStocks is clicked
        private void button_loadStocks_Click(object sender, EventArgs e)
        {
            // Show the openFileDialog so the user can select a stock to load
            DialogResult result = openFileDialog_stockLoader.ShowDialog();
        }

        // Private member helper function to load each candlestick in a file into a list of Candlestick objects
        private List<Candlestick> loadCandlesticks(string filename)
        {
            // Declare local list to return
            List<Candlestick> resultingList = new List<Candlestick>(1024);

            // Use stream reader to read in file data
            using (StreamReader sr = new StreamReader(filename))
            {
                // Variable to store each CSV line of data
                string line;

                // First read the CSV header
                string header = sr.ReadLine();

                // If the header is correct
                if (header == referenceHeaderString)
                {
                    // Read in the CSV file line by line
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Instantiate new candlestick
                        Candlestick cs = new Candlestick(line);

                        // Add it to the temporary list
                        resultingList.Add(cs);
                    }
                    // Make templist in chronological order
                    resultingList.Reverse();
                }
            }

            // Return the resulting list
            return resultingList;
        }

        private void openFileDialog_stockLoader_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog openFileDialog = (OpenFileDialog)sender;
            foreach (string filePath in openFileDialog.FileNames)
            {
                // For each file, load the file into a list of Candlesticks and create a stockChart form
                List<Candlestick> unfilteredCandlesticksList = loadCandlesticks(filePath);
                Form_stockChart currentChart = new Form_stockChart(filePath, unfilteredCandlesticksList, dateTimePicker_startDate.Value, dateTimePicker_endDate.Value);
                currentChart.Show();
            }
        }
    }
}
