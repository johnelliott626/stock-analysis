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
        // Static list of all single Candlestick patterns
        private static List<string> candlestickPatterns = new List<string>{"None", "Bullish", "Bearish", "Neutral", "Marubozu", "Doji", "DragonFly Doji", "Gravestone Doji", "Hammer", "Inverted Hammer"};
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

            // Set the combo box source
            comboBox_selectPattern.DataSource = candlestickPatterns;

            // Call the filterCandlesticks function to filter the candlesticks by date and set the chart data source
            filterCandlesticks();
            
        }

        // Private member function that filters the candlestick binding list based on "new" user selected dates
        private void button_updateChart_Click(object sender, EventArgs e)
        {
            // Call the function that filters out the candlesticks based on the current user selected dates
            filterCandlesticks();

            // Change the selected pattern to "None"
            comboBox_selectPattern.SelectedIndex = 0;
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

        // Private member function that annotated a specified candlestick
        private void annotateCandlestick(int indexOfPoint, SmartCandlestick scs)
        {
            // Create a rectangle annotation and arrow annotation
            RectangleAnnotation annotation = new RectangleAnnotation();
            ArrowAnnotation arrowAnnotation = new ArrowAnnotation();

            
            // Set the rectangle annotation position and size to outline the specific Candlestick
            annotation.AxisX = chart_candlesticks.ChartAreas["ChartArea_OHLC"].AxisX;
            annotation.AxisY = chart_candlesticks.ChartAreas["ChartArea_OHLC"].AxisY;
            annotation.IsSizeAlwaysRelative = false;
            annotation.Height = (double)scs.bodyRange;
            annotation.Width = .8;
            annotation.X = indexOfPoint + .6;
            annotation.Y = (double)scs.bottomPrice;

            // Set the rectangle annotation style
            annotation.BackColor = Color.Transparent;
            annotation.LineColor = Color.Blue;

            
            // Set the arrow annotation position to point to the top of the specific Candlestick
            arrowAnnotation.AxisX = chart_candlesticks.ChartAreas["ChartArea_OHLC"].AxisX;
            arrowAnnotation.AxisY = chart_candlesticks.ChartAreas["ChartArea_OHLC"].AxisY;
            arrowAnnotation.IsSizeAlwaysRelative = false;
            arrowAnnotation.Height = 10000;
            arrowAnnotation.X = indexOfPoint + 1;
            arrowAnnotation.Y = (double)scs.high * 1.01;
            arrowAnnotation.Width = 1;
            arrowAnnotation.LineColor = Color.Blue;

            // Add the annotations to the chart
            chart_candlesticks.Annotations.Add(annotation);
            chart_candlesticks.Annotations.Add(arrowAnnotation);
        }

        // Private membert that annotated the corresponding Candlesticks when a pattern is selected or changed
        private void comboBox_selectPattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            // First clear all the old annotations
            chart_candlesticks.Annotations.Clear();

            // if the selected pattern is not "None" which is at index 0
            if (comboBox_selectPattern.SelectedIndex != 0)
            {
                int selectedPatternIndex = comboBox_selectPattern.SelectedIndex;

                for (int i = 0; i < filteredSmartCandlesticksList.Count; i++)
                {
                    // Declare variables to track if the candlestick is the selected pattern and store the current candlestick
                    bool isPattern = false;
                    SmartCandlestick currentCS = filteredSmartCandlesticksList[i];

                    // Find the boolean value of the current candlestick based on the selected pattern
                    switch(selectedPatternIndex)
                    {
                        case 1:
                            isPattern = currentCS.isBullish;
                            break;
                        case 2:
                            isPattern = currentCS.isBearish;
                            break;
                        case 3:
                            isPattern = currentCS.isNeutral;
                            break;
                        case 4:
                            isPattern = currentCS.isMarubozu;
                            break;
                        case 5:
                            isPattern = currentCS.isDoji;
                            break;
                        case 6:
                            isPattern = currentCS.isDragonFlyDoji;
                            break;
                        case 7:
                            isPattern = currentCS.isGravestoneDoji;
                            break;
                        case 8:
                            isPattern = currentCS.isHammer;
                            break;
                        case 9:
                            isPattern = currentCS.isInvertedHammer;
                            break;
                    }

                    // If the current candlestick is the selected pattern, then annotate it
                    if (isPattern)
                    {
                        annotateCandlestick(i, currentCS);
                    }
                }   
            }
            
        }
    }
}
