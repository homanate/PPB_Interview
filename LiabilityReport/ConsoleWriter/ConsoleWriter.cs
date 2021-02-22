using System;
using System.Collections.Generic;
using System.Linq;

namespace LiabilityReport.ConsoleWriter
{
    public class ConsoleWriter
    {
        List<string> columnHeader = new OutputDataReportOne().GetType().GetProperties().Select(name => name.Name).ToList();

        public void Run(List<OutputDataReportOne> inputData)
        {
            Console.WriteLine(string.Format($"|\t{columnHeader[0]}\t|\t{columnHeader[1]}\t|\t{columnHeader[2]}\t|\t{columnHeader[3]}\t|\t{columnHeader[4]}\t|"));
            Console.WriteLine();
            foreach (var bet in inputData)
            {
                var moneySign = "";
                if (bet.Currency == Currencies.Eur)
                    moneySign = "Euro - ";//€ not showing in UTF-8
                else
                    moneySign = "£";
                Console.WriteLine(String.Format("|{0,5}\t\t|{1,10}|{2,10}|{3,10}|{4,10}|", bet.SelectionName, bet.Currency, bet.NumOfBets, moneySign+ (Math.Round(bet.TotalStakes)), moneySign + (Math.Round(bet.TotalLiability))));
            }

        }

        public void Run(List<OutputDataReportTwo> inputData)
        {
            Console.WriteLine(); 
            Console.WriteLine();
            Console.WriteLine(string.Format($"|\t{columnHeader[1]}\t|\t{columnHeader[2]}\t|\t{columnHeader[3]}\t|\t{columnHeader[4]}\t|"));
            Console.WriteLine();
            foreach (var bet in inputData)
            {
                var moneySign = "";
                if (bet.Currency == Currencies.Eur)
                    moneySign = "EURO -";
                else
                    moneySign = "£";
                Console.WriteLine(String.Format("|{0,5}\t\t|{1,10}|{2,10}|{3,10}|",bet.Currency, bet.NumOfBets, moneySign + Math.Round(bet.TotalStakes, 2), moneySign+Math.Round(bet.TotalLiability, 2)));
            }

        }
    }
}
