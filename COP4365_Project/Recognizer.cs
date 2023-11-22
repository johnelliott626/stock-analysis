using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4365_Project
{
    // Abstract Recognizer base class that each specific recongizer class will inherit
    public abstract class Recognizer
    {
        public int patternSize; // Private member to store the number of Candlesticks in the pattern
        public string patternName;  // Private member to store the name of specified Candlestick Pattern

        // Constructor that sets the patternSize and patternName members
        public Recognizer(int patternSize, string patternName)
        {
            this.patternSize = patternSize;
            this.patternName = patternName;
        }

        // Public member function that returns a list of indices of Candlesticks that identify as the selected pattern
        public List<int> recognize(List<SmartCandlestick> scsList)
        {
            // List to store the result in a list of integers that represent indices
            List<int> result = new List<int>();

            // If the selected pattern is a single candlestick pattern
            if (patternSize == 1)
            {
                // Iterate through the smart candlesticks on the chart
                for (int i = 0; i < scsList.Count; i++)
                {
                    // Put the current candlestick in a list of length 1
                    List<SmartCandlestick> currentSingleSublist = new List<SmartCandlestick> { scsList[i] };

                    // If the current candlestick is the selected pattern add it to the result
                    if (recognizePattern(currentSingleSublist))
                    {
                        result.Add(i);
                    }
                }
            }

            // Else the selected pattern is a multicandlestick pattern
            else
            {
                // Adjust the start index of the for loop, because you can only look backward in multi-candlestick patterns
                int iterationStartIndex = patternSize - 1;
                for(int i = iterationStartIndex;i < scsList.Count;i++)
                {
                    // Retrieve the Candlesticks where i is the last index in the subset
                    int subsetStartIndex = i - (patternSize - 1); // Calculate subset start index based on pattern size
                    List<SmartCandlestick> currentSublist = scsList.GetRange(subsetStartIndex, patternSize); // Store sublist

                    // Add the last candlestick of the sublist to the result list if it is the specified pattern
                    if (recognizePattern(currentSublist))
                    {
                        result.Add(i);
                    }
                }
            }

            // Return the result list: storing the indices of the Smart Candlesticks that are the selected pattern            
            return result;
        }

        // Abstract member function that will call the recognize function based on the specified pattern Recognizer
        public abstract bool recognizePattern(List<SmartCandlestick> scsSublist);
    }

    // Class definition of the recognizer class that inherits the Recognizer base class for the Bullish pattern
    public class BullishRecognizer : Recognizer
    {
        // Public constructor that calls the base class constructor to set the patternSize and patternName members
        public BullishRecognizer(int patternSize, string patternName) : base(patternSize, patternName) { }

        // Implementation of the abstract class function recognizePattern that returns if the sublist is the specified pattern
        public override bool recognizePattern(List<SmartCandlestick> scsSublist)
        {
            return scsSublist[0].isBullish;
        }
    }

    // Class definition of the recognizer class that inherits the Recognizer base class for the Bearish pattern
    public class BearishRecognizer : Recognizer
    {
        // Public constructor that calls the base class constructor to set the patternSize and patternName members
        public BearishRecognizer(int patternSize, string patternName) : base(patternSize, patternName) { }

        // Implementation of the abstract class function recognizePattern that returns if the sublist is the specified pattern
        public override bool recognizePattern(List<SmartCandlestick> scsSublist)
        {
            return scsSublist[0].isBearish;
        }
    }

    // Class definition of the recognizer class that inherits the Recognizer base class for the Neutral pattern
    public class NeutralRecognizer : Recognizer
    {
        // Public constructor that calls the base class constructor to set the patternSize and patternName members
        public NeutralRecognizer(int patternSize, string patternName) : base(patternSize, patternName) { }

        // Implementation of the abstract class function recognizePattern that returns if the sublist is the specified pattern
        public override bool recognizePattern(List<SmartCandlestick> scsSublist)
        {
            return scsSublist[0].isNeutral;
        }
    }

    // Class definition of the recognizer class that inherits the Recognizer base class for the Marubozu pattern
    public class MarubozuRecognizer : Recognizer
    {
        // Public constructor that calls the base class constructor to set the patternSize and patternName members
        public MarubozuRecognizer(int patternSize, string patternName) : base(patternSize, patternName) { }

        // Implementation of the abstract class function recognizePattern that returns if the sublist is the specified pattern
        public override bool recognizePattern(List<SmartCandlestick> scsSublist)
        {
            return scsSublist[0].isMarubozu;
        }
    }
}
