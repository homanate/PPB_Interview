using System.Collections.Generic;
using System.Linq;

namespace LiabilityReport.Calculator
{
    public class Calculator
    {
        CalculatorHelper calculatorHelp = new CalculatorHelper();
        public List<OutputDataReportOne> RunReportOne(List<BetInputDto> betData)
        {
            List<OutputDataReportOne> outputData = new List<OutputDataReportOne>();
            var grouped = betData.GroupBy(bet => bet.SelectionName);
            
            foreach(var bets in grouped)
            {
                var outputGbp = new OutputDataReportOne();
                var outputEur = new OutputDataReportOne();
                foreach (var bet in bets)
                {
                    outputEur = calculatorHelp.CalculateEurDataReportOne(bets, Currencies.Eur);
                    outputGbp = calculatorHelp.CalculateGbpDataReportOne(bets, Currencies.Gbp);

                    outputData.Add(outputEur);
                    outputData.Add(outputGbp);
                    break;
                }
            }

            return outputData;
        }

        internal List<OutputDataReportTwo> RunReportTwo(List<BetInputDto> betData)
        {
            List<OutputDataReportTwo> outputData = new List<OutputDataReportTwo>();
            var grouped = betData.GroupBy(bet => bet.Currency);

            foreach (var bets in grouped)
            {
                var outputGbp = new OutputDataReportTwo();
                var outputEur = new OutputDataReportTwo();
                foreach (var bet in bets)
                {
                    if (bet.Currency == Currencies.Eur)
                    {
                        outputEur = calculatorHelp.CalculateEurDataReportTwo(bets, Currencies.Eur);
                        outputData.Add(outputEur);
                    }
                    else
                    {
                        outputGbp = calculatorHelp.CalculateGbpDataReportTwo(bets, Currencies.Gbp);
                        outputData.Add(outputGbp);
                    }

                    break;
                }
            }

            return outputData;
        }
    }
}
