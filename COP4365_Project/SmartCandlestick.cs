using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4365_Project
{
    internal class SmartCandlestick : Candlestick
    {
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


        // Class constructor that will initialize base class members based on an input of the base class "Candlestick"
        public SmartCandlestick(Candlestick candlestick) : base(candlestick)
        {
            setSmartProperties();
            setCandlestickPatterns();
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
            // Calculate if candlestick is Bullish
            isBullish = close > open;

            // Calculate if candlestick is Bearish
            isBearish = close < open;

            // Calculate if candlestick is Neutral
            // Check if upper or lower tail is within 20% of whichever tail if larger
            if (topTail > bottomTail) 
            {
                Decimal neutralRange = topTail * .20M;   
                isNeutral = bottomTail >= (topTail - neutralRange);    // Neutral if bottomTail is within 20% of topTail
            }
            else
            {
                Decimal neutralRange = bottomTail * .20M;    
                isNeutral = topTail >= (bottomTail - neutralRange);    // Neutral if topTail is within 20% of bottomTail
            }

            // Calculate if candlestick is Marubozu
            // Check if the bodyRange is within 12.5% of the range
            Decimal marubozuRange = range * .125M;
            isMarubozu = bodyRange >= (range - marubozuRange);

            // Calculate if candlestick is Doji
            // Check if the bottomPrice is within 1% of the topPrice
            Decimal dojiRange = topPrice * .01M;
            isDoji = bottomPrice >= (topPrice - dojiRange);
            

            // Calculate if candlestick is a dragonfly or gravestone Doji
            // First check if the candlestick is a doiji
            if (isDoji)
            {
                // Check if the candlestick body is within the top (dragonfly) or bottom (gravestone) 25% of the total candlestick range 
                Decimal specificDojiRange = range * .25M;
                isDragonFlyDoji = bottomPrice >= (high - specificDojiRange);
                isGravestoneDoji = topPrice <= (low + specificDojiRange);
            }
            else
            {
                isDragonFlyDoji = false;
                isGravestoneDoji = false;
            }

            // Calculate if candlestick is a hammer or inverted hammer
            // Calculate if candlestick bodyRange length is between 25%-50% of total range length 
            Decimal hammerLowerBound = range * .25M;
            Decimal hammerUpperBound = range * .50M;
            if (bodyRange >= hammerLowerBound && bodyRange <= hammerUpperBound)
            {
                // calculate if the top or bottom tail is within 10% of the total range length
                Decimal tailRange = range * .10M;
                isHammer = topTail <= tailRange;
                isInvertedHammer = bottomTail <= tailRange;
            }
            else
            {
                isHammer = false;
                isInvertedHammer = false;
            }
        }
    }
}
