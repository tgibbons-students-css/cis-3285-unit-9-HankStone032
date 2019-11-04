using SingleResponsibilityPrinciple.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    //Request  407 - "As a trader I want to be able to able to read trades from the companies new web service provider so I can enter trades from different apps." 
    //Details: Solution: Create a new URLTradeDataProvider() class similar to the StreamTradeDataProvider class. The new class should read data from the 
    //URL http://faculty.css.edu/tgibbons/trades4.txt. Here is some starting code to read from a url.


    class ReadURLTradeData : ITradeDataProvider
    {
        private string tradeURL;
        public ReadURLTradeData(string url)
        {
            tradeURL = url;
        }

        public IEnumerable<string> GetTradeData()
        {
            var tradeData = new List<string>();
            var client = new WebClient();
            using (var stream = client.OpenRead(tradeURL))
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    tradeData.Add(line);
                }
            }
            return tradeData;
        }
    }
}