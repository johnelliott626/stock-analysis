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
    // Form that displays the candlestick stock chart of a selected stock file
    public partial class Form_stockChart : Form_stockLoader
    {
        // Static list of all single Candlestick patterns
        private static List<string> candlestickPatterns = new List<string>{"None", "Bullish", "Bearish", "Neutral", "Marubozu", "Doji", "DragonFly Doji", "Gravestone Doji", "Hammer", "Inverted Hammer"};

        // Private List of each SmartCandlestick objects to store those to be displayed on the stock chart
        private List<SmartCandlestick> filteredSmartCandlesticksList = new List<SmartCandlestick>();

        // Private List that contains all Smart Candlesticks in the current stock file including those outside the selected date range
        private List<SmartCandlestick> unfilteredSmartCandlesticksList { get; set; }

        // Private List that contains each Recognizer object
        private List<Recognizer> recognizersList {  get; set; }


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

            // Initialize the recognizer list
            initializeRecognizerList();
           
            // Add each pattern to the comboBox
            foreach (Recognizer recognizer in recognizersList)
            {
                comboBox_selectPattern.Items.Add(recognizer.patternName);
            }

            // Set the stock chart data source
            chart_candlesticks.DataSource = filteredSmartCandlesticksList;

            // Call the filterCandlesticks function to filter the candlesticks by date and set the chart data source
            filterCandlesticks();
        }

        // Private member function that initializes the list of Recognizer objects
        private void initializeRecognizerList()
        {
            // Adds each pattern recognizer to the list
            recognizersList = new List<Recognizer>();
            recognizersList.Add(new NoneRecognizer());
            recognizersList.Add(new BullishRecognizer());
            recognizersList.Add(new BearishRecognizer());
            recognizersList.Add(new NeutralRecognizer());
            recognizersList.Add(new MarubozuRecognizer());
            recognizersList.Add(new DojiRecognizer());
            recognizersList.Add(new DragonFlyDojiRecognizer());
            recognizersList.Add(new GravestoneDojiRecognizer());
            recognizersList.Add(new HammerRecognizer());
            recognizersList.Add(new InvertedHammerRecognizer());
            recognizersList.Add(new PeakRecognizer());
            recognizersList.Add(new ValleyRecognizer());
            recognizersList.Add(new EngulfingRecognizer());
            recognizersList.Add(new BullishEngulfingRecognizer());
            recognizersList.Add(new BearishEngulfingRecognizer());
            recognizersList.Add(new BullishHaramiRecognizer());
            recognizersList.Add(new BearishHaramiRecognizer());
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
            // Clear the old filtered Smart Candlestick list
            filteredSmartCandlesticksList.Clear();

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

            // Manually call the data bind method on the chart, to update it
            chart_candlesticks.DataBind();
        }

        // Private member function that annotates a specified candlestick with a blue rectangle border and blue arrow
        private void annotateCandlestick(int indexOfPoint, SmartCandlestick scs, string name)
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

        /*private void annotatePatter()
        {
            // Name, size
            // Rectangle annotation by size
            // Single arrow annotation and test annotation

        }*/

        // Private membert that annotates the corresponding Candlesticks when a pattern is selected or changed
        private void comboBox_selectPattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            // First clear all the old annotations
            chart_candlesticks.Annotations.Clear();

            // store the selected index the user selected
            int selectedPatternIndex = comboBox_selectPattern.SelectedIndex;

            // Call the Recognize function to get the list of candlesticks to annotate
            List<int> indicesToAnnotate = recognizersList[selectedPatternIndex].recognize(filteredSmartCandlesticksList);

            foreach (int candlestickIndex in indicesToAnnotate)
            {
                annotateCandlestick(candlestickIndex, filteredSmartCandlesticksList[candlestickIndex], recognizersList[selectedPatternIndex].patternName);
            }


        }
    }
}
