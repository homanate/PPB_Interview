using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

namespace LiabilityReport
{
    public class ConsoleReader
    {
        public static bool _columnCheck = false;
        public static List<BetInputDto> ReadData(string dataFile)
        {
            var reader = File.ReadAllLines(dataFile);

            var columnHeader = new BetInputDto().GetType().GetProperties().ToList();
            var headerNames = columnHeader.Select(name => name.Name).ToList();
            var headers = headerNames.ConvertAll(name => name.ToLower());

            List<BetInputDto> dataHeaders = new List<BetInputDto>();
            var dataHeader = new BetInputDto();

            //remove
            foreach (var longString in reader)
            {
                               
                var stringArray = FormatData(longString);

                var b = 0;
                for (int i = 0; i < stringArray.Length; ++i)
                {
                    _columnCheck = false;
                    
                    if (!headers.Contains(stringArray[i].ToLower()) && stringArray[i] != string.Empty)
                        _columnCheck = true;

                    if (_columnCheck)
                    {
                        switch (b)
                        {
                            case 0:
                                dataHeader.BetId = stringArray[i];
                                break;
                            case 1:
                                dataHeader.BetTimestamp = stringArray[i];
                                break;
                            case 2:
                                dataHeader.SelectionId = Convert.ToInt32(stringArray[i]);
                                break;
                            case 3:
                                dataHeader.SelectionName = stringArray[i];
                                break;
                            case 4:
                                dataHeader.Stake = Convert.ToDouble(stringArray[i]);
                                break;
                            case 5:
                                dataHeader.Price = Convert.ToDouble(stringArray[i]);
                                break;
                            case 6:
                                dataHeader.Currency = stringArray[i];
                                break;
                            default:
                                break;
                        }
                        if (b >= 6)
                        {
                            dataHeaders.Add(new BetInputDto(dataHeader));
                            
                            b = 0;
                        }
                        else
                            ++b;
                    }
                }
            }
            return dataHeaders;
        }

        private static string[] FormatData(string longString)
        {
            string name = Regex.Replace(longString, @$"\b{Currencies.Eur}\b", $"{Currencies.Eur},");
            string fullString = Regex.Replace(name, @$"\b{Currencies.Gbp}\b", $"{Currencies.Gbp},");
            string Fulleststring = Regex.Replace(fullString, @$"\b{BetInputColumnHeaders.Currency.ToString().ToLower()}\b", $"{BetInputColumnHeaders.Currency.ToString().ToLower()},");

            return Fulleststring.Split(",", StringSplitOptions.TrimEntries);
        }
    }
}
