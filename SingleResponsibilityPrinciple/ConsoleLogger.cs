using System;
using System.IO;
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    //Request  405 - "As a manager, I want to easily monitor the trading errors my traders make so I can provide them better training to avoid errors." 
    //Details: all logs should be sent to an XML file along with outputting to the console. An example xml log would be "     <log><type>INFO</type><message>4 trades processed</message></log> 
    public class ConsoleLogger : ILogger
    {
        public void LogWarning(string message, params object[] args)
        {
            string type = "WARN";
            Console.WriteLine(string.Concat("WARN: ", message), args);

            using (StreamWriter logfile = File.AppendText("log.xml"))
            {
                logfile.WriteLine("<log><type>" + type + "</type><message>" + message + "</message></log> ", args);
            }

        }

        public void LogInfo(string message, params object[] args)
        {
            string type = "WARN";
            Console.WriteLine(string.Concat("INFO: ", message), args);

            using (StreamWriter logfile = File.AppendText("log.xml"))
            {
                logfile.WriteLine("<log><type>" + type + "</type><message>" + message + "</message></log> ", args);
            }
        }
    }
}