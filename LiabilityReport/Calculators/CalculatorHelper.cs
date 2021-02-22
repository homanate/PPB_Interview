using System;
using System.Linq;

namespace LiabilityReport.Calculator
{
    public class CalculatorHelper
    {
        public OutputDataReportOne CalculateGbpDataReportOne(IGrouping<string, BetInputDto> bets, string gbp)
        {
            var outputGbp = new OutputDataReportOne();

            foreach (var bet in bets)
            {
                outputGbp.SelectionName = bet.SelectionName;
                outputGbp.Currency = gbp;
                outputGbp.NumOfBets = CalculateNumberOfBets(bets, gbp);
                outputGbp.TotalStakes = CalculateStakes(bets, gbp);
                outputGbp.TotalLiability = CalculateLiabilities(bets, gbp);
                break;
            }
            return outputGbp;
        }

        public OutputDataReportOne CalculateEurDataReportOne(IGrouping<string, BetInputDto> bets, string eur)
        {
            var outputEur = new OutputDataReportOne();

            foreach (var bet in bets)
            {
                outputEur.SelectionName = bet.SelectionName;
                outputEur.Currency = eur;
                outputEur.NumOfBets = CalculateNumberOfBets(bets, eur);
                outputEur.TotalStakes = CalculateStakes(bets, eur);
                outputEur.TotalLiability = CalculateLiabilities(bets, eur);
                break;
            }

            return outputEur;
        }

        internal OutputDataReportTwo CalculateGbpDataReportTwo(IGrouping<string, BetInputDto> bets, string currency)
        {
            var outputGbp = new OutputDataReportTwo();

            foreach (var bet in bets)
            {
                outputGbp.Currency = bet.Currency;
                outputGbp.NumOfBets = CalculateNumberOfBets(bets, currency);
                outputGbp.TotalStakes = CalculateStakes(bets, currency);
                outputGbp.TotalLiability = CalculateLiabilities(bets, currency);
                break;
            }
            return outputGbp;
        }

        internal OutputDataReportTwo CalculateEurDataReportTwo(IGrouping<string, BetInputDto> bets, string currency)
        {
            var outputEur = new OutputDataReportTwo();

            foreach (var bet in bets)
            {
                outputEur.Currency = bet.Currency;
                outputEur.NumOfBets = CalculateNumberOfBets(bets, currency);
                outputEur.TotalStakes = CalculateStakes(bets, currency);
                outputEur.TotalLiability = CalculateLiabilities(bets, currency);
                break;
            }
            return outputEur;
        }

        public int CalculateNumberOfBets(IGrouping<string, BetInputDto> bets, string currency)
        {
            int numOfBets = 0;

            foreach (var bet in bets)
            {
                if (bet.Currency == currency)
                {
                    numOfBets++;
                }
            }
            return numOfBets;
        }

        public double CalculateLiabilities(IGrouping<string, BetInputDto> bets, string currency)
        {
            double liability = 0.0;
            foreach (var bet in bets)
            {
                if (bet.Currency == currency)
                {
                    liability += bet.Stake * bet.Price;
                }
            }
            return Math.Round(liability, 2);
        }

        public double CalculateStakes(IGrouping<string, BetInputDto> bets, string currency)
        {
            double stakes = 0.0;
            foreach (var bet in bets)
            {
                if (bet.Currency == currency)
                    stakes += bet.Stake;
            }

            return Math.Round(stakes, 2);
        }
    }
}
