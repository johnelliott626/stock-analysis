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
using System.Windows.Forms.DataVisualization.Charting;

namespace COP4365_Project
{
    public partial class Form_stockChart : Form_stockLoader
    {
        // Private BindingList of each SmartCandlestick object, that other objects can bind to when the list changes
        private BindingList<SmartCandlestick> filteredSmartCandlesticksList {  get; set; }

        // Private List that contains all Smart Candlesticks in the current stock file including those outside the selected date range
        private List<SmartCandlestick> unfilteredSmartCandlesticksList { get; set; }


        // Public member function that initializes the entire form object
        public Form_stockChart(string filePath, List<Candlestick> unfilteredCandlesticksList, DateTime startDate, DateTime endDate)
        {
            // Initialize Component
            InitializeComponent();

            // Set the private members based on the passed in input parameters

            // Initialize the unfilitered SmartCandlestick list member to an empty list
            unfilteredSmartCandlesticksList = new List<SmartCandlestick>();

            // Convert the unfilteredCandlesticks into a list of SmartCandlesticks
            foreach (Candlestick cs in unfilteredCandlesticksList)
            {
                // Create a SmartCandlestick instance
                SmartCandlestick smartCS = new SmartCandlestick(cs);

                // Add the SmartCandlestick instance to the class member unfilteredSmartCandlesticksList
                unfilteredSmartCandlesticksList.Add(smartCS);
            }

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

            AnnotateCandlestick(chart_candlesticks.Series["Series_OHLC"].Points[0], 2, "hello");
        }

        // Private member function to filter the candlesticks based on user selected dates
        public void filterCandlesticks()
        {
            // Initialize a new BindingList for the candlesticks member
            filteredSmartCandlesticksList = new BindingList<SmartCandlestick>();

            // Make sure the candlesticks are in range with most recent row to date first in list candlesticks
            foreach (SmartCandlestick scs in unfilteredSmartCandlesticksList)
            {
                // Add only the candlesticks that are in the specified date range
                // If current date is greater than end date break because all remaining candlesticks will be outside of range
                if (scs.date > dateTimePicker_endDate.Value)
                {
                    break;
                }
                // If current date is within range add it to the candlesticks binding list
                if (scs.date >= dateTimePicker_startDate.Value)
                {
                    filteredSmartCandlesticksList.Add(scs);
                }
            }

            // Set the chart data source to the SmartCandlestick binding list and bind the chart to the data source so the chart updates when list changes
            chart_candlesticks.DataSource = filteredSmartCandlesticksList;
            chart_candlesticks.DataBind();
        }

        private void AnnotateCandlestick(DataPoint dataPoint, double indexOfPoint, string annotationText)
        {
            chart_candlesticks.Annotations.Clear();

            // Create a rectangle annotation
            RectangleAnnotation annotation = new RectangleAnnotation();

            double height = chart_candlesticks.ChartAreas["ChartArea_OHLC"].AxisY.Maximum * 1.05;
            // Set the annotation position and size based on the candlestick
            annotation.AxisX = chart_candlesticks.ChartAreas["ChartArea_OHLC"].AxisX;
            annotation.AxisY = chart_candlesticks.ChartAreas["ChartArea_OHLC"].AxisY;
            annotation.IsSizeAlwaysRelative = false;
            annotation.Width = 1;
            annotation.X = indexOfPoint + .5; // Adjust the position based on your requirements
            // high, low, open, close
            annotation.Y = dataPoint.YValues[0] + (dataPoint.YValues[0] - dataPoint.YValues[1]); // Adjust the position based on your requirements
            //annotation.Width = chart_candlesticks.Series["Series_OHLC"].MarkerSize; // Adjust the size based on your requirements
            //annotation.Height = 10; // Adjust the size based on your requirements

            // Set the annotation style
            annotation.Text = "Marubozu";
            annotation.LineDashStyle = ChartDashStyle.Dash;
            annotation.LineWidth = 2;

            // Add the annotation to the chart
            chart_candlesticks.Annotations.Add(annotation);
        }
    }
}
