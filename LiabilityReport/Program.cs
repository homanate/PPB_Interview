using System;

namespace LiabilityReport
{
    class Program
    {
        const string FileLocation = @"D:\C#\LiabilityReport\Data.txt";

        static void Main()
        {
            var calc = new Calculator.Calculator();
            var writer = new ConsoleWriter.ConsoleWriter();

            var betData = ConsoleReader.ReadData(FileLocation);

            var outputDataReportOne = calc.RunReportOne(betData);
            var outputDataReportTwo = calc.RunReportTwo(betData);


            Console.WriteLine("****************  Report One  ***************");
            Console.WriteLine();
            writer.Run(outputDataReportOne);
            Console.WriteLine();
            Console.WriteLine("****************  Report Two  ***************");
            writer.Run(outputDataReportTwo);
            Console.WriteLine();


            Console.WriteLine("****************  CSV Report One  ***************");
            Console.WriteLine(ServiceStack.TextExtensions.ToCsvField(outputDataReportOne));
            Console.WriteLine();
            Console.WriteLine("****************  CSV Report Two  ***************");
            Console.WriteLine(ServiceStack.TextExtensions.ToCsvField(outputDataReportTwo));
 
        }
    }
}
