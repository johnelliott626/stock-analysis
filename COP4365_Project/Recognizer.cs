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
        public BullishRecognizer() : base(1, "Bullish") { }

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
        public BearishRecognizer() : base(1, "Bearish") { }

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
        public NeutralRecognizer() : base(1, "Neutral") { }

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
        public MarubozuRecognizer() : base(1, "Marubozu") { }

        // Implementation of the abstract class function recognizePattern that returns if the sublist is the specified pattern
        public override bool recognizePattern(List<SmartCandlestick> scsSublist)
        {
            return scsSublist[0].isMarubozu;
        }
    }

    // Class definition of the recognizer class that inherits the Recognizer base class for the Doji pattern
    public class DojiRecognizer : Recognizer
    {
        // Public constructor that calls the base class constructor to set the patternSize and patternName members
        public DojiRecognizer() : base(1, "Doji") { }

        // Implementation of the abstract class function recognizePattern that returns if the sublist is the specified pattern
        public override bool recognizePattern(List<SmartCandlestick> scsSublist)
        {
            return scsSublist[0].isDoji;
        }
    }

    // Class definition of the recognizer class that inherits the Recognizer base class for the DragonFlyDoji pattern
    public class DragonFlyDojiRecognizer : Recognizer
    {
        // Public constructor that calls the base class constructor to set the patternSize and patternName members
        public DragonFlyDojiRecognizer() : base(1, "DragonFly Doji") { }

        // Implementation of the abstract class function recognizePattern that returns if the sublist is the specified pattern
        public override bool recognizePattern(List<SmartCandlestick> scsSublist)
        {
            return scsSublist[0].isDragonFlyDoji;
        }
    }

    // Class definition of the recognizer class that inherits the Recognizer base class for the GravestoneDoji pattern
    public class GravestoneDojiRecognizer : Recognizer
    {
        // Public constructor that calls the base class constructor to set the patternSize and patternName members
        public GravestoneDojiRecognizer() : base(1, "Gravestone Doji") { }

        // Implementation of the abstract class function recognizePattern that returns if the sublist is the specified pattern
        public override bool recognizePattern(List<SmartCandlestick> scsSublist)
        {
            return scsSublist[0].isGravestoneDoji;
        }
    }

    // Class definition of the recognizer class that inherits the Recognizer base class for the Hammer pattern
    public class HammerRecognizer : Recognizer
    {
        // Public constructor that calls the base class constructor to set the patternSize and patternName members
        public HammerRecognizer() : base(1, "Hammer") { }

        // Implementation of the abstract class function recognizePattern that returns if the sublist is the specified pattern
        public override bool recognizePattern(List<SmartCandlestick> scsSublist)
        {
            return scsSublist[0].isHammer;
        }
    }

    // Class definition of the recognizer class that inherits the Recognizer base class for the InvertedHammer pattern
    public class InvertedHammerRecognizer : Recognizer
    {
        // Public constructor that calls the base class constructor to set the patternSize and patternName members
        public InvertedHammerRecognizer() : base(1, "Inverted Hammer") { }

        // Implementation of the abstract class function recognizePattern that returns if the sublist is the specified pattern
        public override bool recognizePattern(List<SmartCandlestick> scsSublist)
        {
            return scsSublist[0].isInvertedHammer;
        }
    }

    // Class definition of the recognizer class that inherits the Recognizer base class for the Peak pattern
    public class PeakRecognizer : Recognizer
    {
        // Public constructor that calls the base class constructor to set the patternSize and patternName members
        public PeakRecognizer() : base(3, "Peak") { }

        // Implementation of the abstract class function recognizePattern that returns if the sublist is the specified pattern
        public override bool recognizePattern(List<SmartCandlestick> scsSublist)
        {
            Decimal leftHigh = scsSublist[0].high;
            Decimal middleHigh = scsSublist[1].high;
            Decimal rightHigh = scsSublist[2].high;

            return (leftHigh < middleHigh) && (middleHigh > rightHigh);
        }
    }

    // Class definition of the recognizer class that inherits the Recognizer base class for the Valley pattern
    public class ValleyRecognizer : Recognizer
    {
        // Public constructor that calls the base class constructor to set the patternSize and patternName members
        public ValleyRecognizer() : base(3, "Valley") { }

        // Implementation of the abstract class function recognizePattern that returns if the sublist is the specified pattern
        public override bool recognizePattern(List<SmartCandlestick> scsSublist)
        {
            Decimal leftLow = scsSublist[0].low;
            Decimal middleLow = scsSublist[1].low;
            Decimal rightLow = scsSublist[2].low;

            return (leftLow > middleLow) && (middleLow < rightLow);
        }
    }

    // Class definition of the recognizer class that inherits the Recognizer base class for the Engulfing pattern
    public class EngulfingRecognizer : Recognizer
    {
        // Public constructor that calls the base class constructor to set the patternSize and patternName members
        public EngulfingRecognizer() : base(2, "Engulfing") { }

        // Implementation of the abstract class function recognizePattern that returns if the sublist is the specified pattern
        public override bool recognizePattern(List<SmartCandlestick> scsSublist)
        {
            SmartCandlestick left = scsSublist[0];
            SmartCandlestick right = scsSublist[1];

            // Return if sublist is either bullish or bearish engulfing pattern
            return (left.bottomPrice > right.bottomPrice) && (left.topPrice < right.topPrice);
        }
    }

    // Class definition of the recognizer class that inherits the Recognizer base class for the BullishEngulfing pattern
    public class BullishEngulfingRecognizer : Recognizer
    {
        // Public constructor that calls the base class constructor to set the patternSize and patternName members
        public BullishEngulfingRecognizer() : base(2, "Bullish Engulfing") { }

        // Implementation of the abstract class function recognizePattern that returns if the sublist is the specified pattern
        public override bool recognizePattern(List<SmartCandlestick> scsSublist)
        {
            SmartCandlestick left = scsSublist[0];
            SmartCandlestick right = scsSublist[1];

            // Return if sublist is the bullish engulfing pattern
            return (left.isBearish && right.isBullish) && (left.bottomPrice > right.bottomPrice) && (left.topPrice < right.topPrice);
        }
    }

    // Class definition of the recognizer class that inherits the Recognizer base class for the BearishEngulfing pattern
    public class BearishEngulfingRecognizer : Recognizer
    {
        // Public constructor that calls the base class constructor to set the patternSize and patternName members
        public BearishEngulfingRecognizer() : base(2, "Bearish Engulfing") { }

        // Implementation of the abstract class function recognizePattern that returns if the sublist is the specified pattern
        public override bool recognizePattern(List<SmartCandlestick> scsSublist)
        {
            SmartCandlestick left = scsSublist[0];
            SmartCandlestick right = scsSublist[1];

            // Return if sublist is the bearish engulfing pattern
            return (left.isBullish && right.isBearish) && (left.bottomPrice > right.bottomPrice) && (left.topPrice < right.topPrice);
        }
    }

    // Class definition of the recognizer class that inherits the Recognizer base class for the BullishHarami pattern
    public class BullishHaramiRecognizer : Recognizer
    {
        // Public constructor that calls the base class constructor to set the patternSize and patternName members
        public BullishHaramiRecognizer() : base(2, "Bullish Harami") { }

        // Implementation of the abstract class function recognizePattern that returns if the sublist is the specified pattern
        public override bool recognizePattern(List<SmartCandlestick> scsSublist)
        {
            SmartCandlestick left = scsSublist[0];
            SmartCandlestick right = scsSublist[1];

            bool correctColors = left.isBearish && right.isBullish;
            bool leftEnclosesRight = (left.bottomPrice < right.bottomPrice) && (left.topPrice > right.topPrice);
            // Gap up is atleast 20% of the left candlestick body range
            bool gapUp = ((left.bottomPrice + (left.bodyRange * .20M)) < right.bottomPrice);
 
            return correctColors && leftEnclosesRight && gapUp;
        }
    }

    // Class definition of the recognizer class that inherits the Recognizer base class for the BearishHarami pattern
    public class BearishHaramiRecognizer : Recognizer
    {
        // Public constructor that calls the base class constructor to set the patternSize and patternName members
        public BearishHaramiRecognizer() : base(2, "Bearish Harami") { }

        // Implementation of the abstract class function recognizePattern that returns if the sublist is the specified pattern
        public override bool recognizePattern(List<SmartCandlestick> scsSublist)
        {
            SmartCandlestick left = scsSublist[0];
            SmartCandlestick right = scsSublist[1];

            bool correctColors = left.isBullish && right.isBearish;
            bool leftEnclosesRight = (left.bottomPrice < right.bottomPrice) && (left.topPrice > right.topPrice);
            // Gap down is atleast 20% of the left candlestick body range
            bool gapDown = ((left.topPrice - (left.bodyRange * .20M)) > right.topPrice);

            return correctColors && leftEnclosesRight && gapDown;
        }
    }

    // Class definition to represent when no pattern is selected or "None" is selected
    public class NoneRecognizer : Recognizer
    {
        // Public constructor that calls the base class constructor to set the patternSize and patternName members
        public NoneRecognizer() : base(1, "None") { }

        // Implementation of the abstract class function recognizePattern that returns if the sublist is the specified pattern
        public override bool recognizePattern(List<SmartCandlestick> scsSublist)
        {
            // No Candlestick should be annotated when "None" is selected, so always return false
            return false;
        }
    }

}
