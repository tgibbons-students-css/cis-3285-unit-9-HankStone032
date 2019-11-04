
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class SimpleTradeValidator : ITradeValidator
    {
        private readonly ILogger logger;

        public SimpleTradeValidator(ILogger logger)
        {
            this.logger = logger;
        }

        public bool Validate(string[] tradeData)
        {
            if (tradeData.Length != 3)
            {
                logger.LogWarning("Line malformed. Only {0} field(s) found.", tradeData.Length);
                return false;
            }

            if (tradeData[0].Length != 6)
            {
                logger.LogWarning("Trade currencies malformed: '{0}'", tradeData[0]);
                return false;
            }

            int tradeAmount;
            if (!int.TryParse(tradeData[1], out tradeAmount))
            {
                logger.LogWarning("Trade not a valid integer: '{0}'", tradeData[1]);
                return false;
            }
            //Request 403 - "As a Traders I want to prevent dangerous trades so that one typo doesn't ruin the company."  
            //Details: Trade amounts must be between 1,000 and 100,000 units.If the trade is outside these bounds it should be ignored.
            if (tradeAmount<1000)
            {
                logger.LogWarning("Trade amount below 1000: '{0}'", tradeData[1]);
                return false;
            }
            if (tradeAmount>100000)
            {
                logger.LogWarning("Trade amount below 1000: '{0}'", tradeData[1]);
                return false;
            }
            decimal tradePrice;
            if (!decimal.TryParse(tradeData[2], out tradePrice))
            {
                logger.LogWarning("Trade price not a valid decimal: '{0}'", tradeData[2]);
                return false;
            }

            return true;
        }
    }
}
