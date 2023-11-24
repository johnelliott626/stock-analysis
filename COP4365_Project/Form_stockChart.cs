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
        private void annotateSingleCandlestick(int indexOfPoint, SmartCandlestick scs)
        {
            // Create a rectangle annotation and arrow annotation
            RectangleAnnotation rectangleAnnotation = new RectangleAnnotation();
            ArrowAnnotation arrowAnnotation = new ArrowAnnotation();

            // Set the rectangle annotation position and size to outline the specific Candlestick
            rectangleAnnotation.AxisX = chart_candlesticks.ChartAreas["ChartArea_OHLC"].AxisX;
            rectangleAnnotation.AxisY = chart_candlesticks.ChartAreas["ChartArea_OHLC"].AxisY;
            rectangleAnnotation.IsSizeAlwaysRelative = false;
            rectangleAnnotation.Height = (double)scs.bodyRange;
            rectangleAnnotation.Width = .8;
            rectangleAnnotation.X = indexOfPoint + .6;
            rectangleAnnotation.Y = (double)scs.bottomPrice;
            // Set the rectangle annotation style
            rectangleAnnotation.BackColor = Color.Transparent;
            rectangleAnnotation.LineColor = Color.Blue;

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
            chart_candlesticks.Annotations.Add(rectangleAnnotation);
            chart_candlesticks.Annotations.Add(arrowAnnotation);
        }

        // Private member function that annotates a specific subset of candlesticks with a blue arrow and rectangle
        private void annotateMultiCandlestick(int patternSize, List<int> scsIndices, List<SmartCandlestick> scsSublist)
        {
            // Create a rectangle annotation and arrow annotation
            RectangleAnnotation rectangleAnnotation = new RectangleAnnotation();
            ArrowAnnotation arrowAnnotation = new ArrowAnnotation();

            // Calculate subset values to be used in the annotations
            double maxHigh = scsSublist.Max(scs => (double)scs.high);
            double minLow = scsSublist.Min(scs => (double)scs.low);
            double averageIndex = scsIndices.Average();

            // Set the rectangle annotation position and size to outline the specific Candlestick
            rectangleAnnotation.AxisX = chart_candlesticks.ChartAreas["ChartArea_OHLC"].AxisX;
            rectangleAnnotation.AxisY = chart_candlesticks.ChartAreas["ChartArea_OHLC"].AxisY;
            rectangleAnnotation.IsSizeAlwaysRelative = false;
            rectangleAnnotation.Height = maxHigh - minLow;
            rectangleAnnotation.Width = patternSize;
            // The rectangle X starts at the leftmost candlestick in the subset and grows to the right
            rectangleAnnotation.X = scsIndices[0] + .5;
            // The rectangle Y starts at the minimum candlestick low in the subset and grows upward
            rectangleAnnotation.Y = minLow;
            // Set the rectangle annotation style
            rectangleAnnotation.BackColor = Color.Transparent;
            rectangleAnnotation.LineColor = Color.Blue;

            // Set the arrow annotation position to point to the top of the specific Candlestick
            arrowAnnotation.AxisX = chart_candlesticks.ChartAreas["ChartArea_OHLC"].AxisX;
            arrowAnnotation.AxisY = chart_candlesticks.ChartAreas["ChartArea_OHLC"].AxisY;
            arrowAnnotation.IsSizeAlwaysRelative = false;
            arrowAnnotation.Height = 10000;
            // The arrow's X value will be in the middle of the candlestick subset that identifies with the pattern
            arrowAnnotation.X = averageIndex + 1;
            // The arrow's Y value will be the just above the maximum candlestick high of the subset
            arrowAnnotation.Y = maxHigh * 1.01;
            arrowAnnotation.Width = 1;
            arrowAnnotation.LineColor = Color.Blue;

            // Add the annotations to the chart
            chart_candlesticks.Annotations.Add(rectangleAnnotation);
            chart_candlesticks.Annotations.Add(arrowAnnotation);
        }

        // Private member function that calls functions to annotate either single or multi candlestick patterns
        private void annotatePattern(int patternSize, int scsIndex)
        {
            // If the selected pattern is a single candlestick pattern 
            if (patternSize == 1)
            {
                // Call the function to annotate a single candlestick
                annotateSingleCandlestick(scsIndex, filteredSmartCandlesticksList[scsIndex]);
            }
            // Else the selected pattern is a multi-candlestick pattern
            else
            {
                // Construct the sublist of indices in the mult-candlestick pattern
                List<int> scsSublistIndices = new List<int>();
                for (int i = (patternSize - 1); i >= 0; i--)
                {
                    scsSublistIndices.Add(scsIndex - i);
                }
                // Construct the sublist of SmartCandlestick indices in the multi-candlestick pattern
                List<SmartCandlestick> scsSublist = new List<SmartCandlestick>();
                foreach (int i in scsSublistIndices)
                {
                    scsSublist.Add(filteredSmartCandlesticksList[i]);
                }

                // Call the function to annotate a multi-candlestick pattern
                annotateMultiCandlestick(patternSize, scsSublistIndices, scsSublist);
            }
        }

        // Private membert that annotates the corresponding Candlesticks when a pattern is selected or changed
        private void comboBox_selectPattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            // First clear all the old annotations
            chart_candlesticks.Annotations.Clear();

            // store the selected index the user selected
            int selectedPatternIndex = comboBox_selectPattern.SelectedIndex;

            // Call the Recognize function to get the list of candlesticks to annotate
            Recognizer selectedRecognizer = recognizersList[selectedPatternIndex];
            List<int> indicesToAnnotate = selectedRecognizer.recognize(filteredSmartCandlesticksList);

            // Iterate over each candlestickIndex and call the function to annotate it
            foreach (int candlestickIndex in indicesToAnnotate)
            {
                annotatePattern(selectedRecognizer.patternSize, candlestickIndex);
            }
        }
    }
}
