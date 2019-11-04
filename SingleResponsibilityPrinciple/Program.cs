using System;
using System.Reflection;

using SingleResponsibilityPrinciple.AdoNet;

namespace SingleResponsibilityPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            var tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SingleResponsibilityPrinciple.trades.txt");

            var logger = new ConsoleLogger();
            var tradeValidator = new SimpleTradeValidator(logger);
            //Added the ReadURLTradeData class and test it here
            var tradeDataProvider = new ReadURLTradeData("http://faculty.css.edu/tgibbons/trades4.txt");
            var tradeMapper = new SimpleTradeMapper();
            var tradeParser = new SimpleTradeParser(tradeValidator, tradeMapper);
            var tradeStorage = new AdoNetTradeStorage(logger);

            var tradeProcessor = new TradeProcessor(tradeDataProvider, tradeParser, tradeStorage);
            tradeProcessor.ProcessTrades();

            Console.ReadKey();
        }
    }
}
