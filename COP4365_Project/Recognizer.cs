using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4365_Project
{
    internal abstract class Recognizer
    {
        public int patternSize;
        public string patternName;
        // Returns indices of the selected pattern
        Recognizer(int patternSize, string patternName)
        {
            this.patternSize = patternSize;
            this.patternName = patternName;
        }
        public List<int> recognize(List<SmartCandlestick> scsList)
        {
            List<int> result = new List<int>();

            
            for (int i = 0; i < scsList.Count; i++)
            {
                List<SmartCandlestick> currentSublist = new List<SmartCandlestick>();

                if (patternSize == 1)
                {
                    currentSublist.Add(scsList[i]);
                    if (recognizePattern(currentSublist))
                    {
                        result.Add(i);
                    }
                }
                else
                {
                    // You can only look backwards in multi-candlestick patterns
                    int iterationStartIndex = patternSize - 1;
                    if (i >= iterationStartIndex)
                    {
                        int subsetStartIndex = i - (patternSize - 1);
                        currentSublist = scsList.GetRange(subsetStartIndex, patternSize);
                        if (recognizePattern(currentSublist))
                        {
                            result.Add(i);
                        }
                    }
                }

            }
            
            
            return result;
        }
        public abstract bool recognizePattern(List<SmartCandlestick> scsList);
    }
}
