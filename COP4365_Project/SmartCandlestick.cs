using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4365_Project
{
    internal class SmartCandlestick : Candlestick
    {
        private const Decimal leeway = 0.05M; // Private const member that defines a leeway percentage for evaluating Candlestick patterns
        public Decimal range {  get; set; } // Public member to store Candlestick range
        public Decimal bodyRange { get; set; } // Public member to store Candlestick body range
        public Decimal topPrice { get; set; } // Public memeber to store Candlestick top price
        public Decimal bottomPrice { get; set; } // Public member to store Candlestick bottom price
        public Decimal topTail {  get; set; } // Public member to store Candlestick upper tail
        public Decimal bottomTail { get; set; } // Public member to store Candlestick lower tail

        public bool isBullish { get; set; } // Public member to identify if the Candlestick is bullish
        public bool isBearish { get; set; } // Public member to identify if the Candlestick is bearish
        public bool isNeutral { get; set; } // Public member to identify if the Candlestick is neutral
        public bool isMarubozu { get; set; } // Public member to identify if the Candlestick is a Marubozu
        public bool isDoji { get; set; } // Public member to identify if the Candlestick is a Doji
        public bool isDragonFlyDoji { get; set; } // Public member to identify if the Candlestick is a DragonFly Doji
        public bool isGravestoneDoji { get; set; } // Public member to identify if the Candlestick is a Gravestone Doji
        public bool isHammer { get; set; } // Public member to identify if the Candlestick is a Hammer
        public bool isInvertedHammer { get; set; } // Public member to identify if the Candlestick is an Inverted Hammer


        // Class constructor that will initialize base class members based on an input row of data
        public SmartCandlestick(string rowOfData) : base(rowOfData)
        {
            setSmartProperties();

        }

        // Private member helper function to set each "Smart" Candlestick higher level property
        private void setSmartProperties()
        {
            // Compute each higher level Candlestick property based on Candlestick values
            range = high - low;
            bodyRange = Math.Abs(open - close);
            topPrice = Math.Max(open, close);
            bottomPrice = Math.Min(open, close);
            topTail = high - topPrice;
            bottomTail = bottomPrice - low;
        }

        // Private member helper function to set each single candlestick pattern
        private void setCandlestickPatterns()
        {
            isBullish = close > open;
            isBearish = close < open;

        }
    }
}
