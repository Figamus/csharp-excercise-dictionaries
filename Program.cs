using System;
using System.Collections.Generic;

namespace dictionaries {
    class Program
    {
        static void Main (string[] args)
        {
            // A block of publicly traded stock has a variety of attributes, we'll look at a few of them. A stock has a ticker symbol and a company name. Create a simple dictionary with ticker symbols and company names in the Main method.
            Dictionary<string, string> stocks = new Dictionary<string, string> ();
            stocks.Add ("GM", "General Motors");
            stocks.Add ("CAT", "Caterpillar");
            stocks.Add ("AMZN", "Amazon");
            stocks.Add ("GOOGL", "Google");

            // To find a value in a Dictionary, you can use square bracket notation much like JavaScript object key lookups.
            // string GM = stocks["GM"]; < -- - "General Motors"

            // Next, create a list to hold stock purchases by an investor. The list will contain dictionaries.
            List<Dictionary<string, double>> purchases = new List<Dictionary<string, double>> ();
            // Then add some purchases.
            purchases.Add (new Dictionary<string, double> () { { "GM", 230.21 } });
            purchases.Add (new Dictionary<string, double> () { { "GM", 580.77 } });
            purchases.Add (new Dictionary<string, double> () { { "CAT", 130.36 } });
            purchases.Add (new Dictionary<string, double> () { { "CAT", 480.98 } });
            purchases.Add (new Dictionary<string, double> () { { "AMZN", 530.21 } });
            purchases.Add (new Dictionary<string, double> () { { "AMZN", 680.98 } });
            purchases.Add (new Dictionary<string, double> () { { "GOOGL", 780.23 } });
            purchases.Add (new Dictionary<string, double> () { { "GOOGL", 499.45 } });

            // Create a total ownership report that computes the total value of each stock that you have purchased. This is the basic relational database join algorithm between two tables.
            // Iterate over the purchases and record the valuation for each stock.
            Dictionary<string, double> stockReport = new Dictionary<string, double> ();

            foreach (Dictionary<string, double> purchase in purchases)
            {
                foreach (KeyValuePair<string, double> transaction in purchase)
                {
                    Console.WriteLine(transaction.Key);
                    string fullCompanyName = stocks[transaction.Key];
                    if (stockReport.ContainsKey(fullCompanyName))
                    {
                        stockReport[fullCompanyName] += transaction.Value;
                        // stockReport[fullCompanyName] = stockReport[fullCompanyName] + transaction.Value;
                    } else {
                        stockReport.Add(fullCompanyName, transaction.Value);
                        // stockReport[fullCompanyName] = transaction.Value;
                    }
                }
            }

            // Display all holdings and their valuations
            foreach (KeyValuePair<string, double> valuation in stockReport)
            {
                Console.WriteLine($"{valuation.Key} has a valuation of {valuation.Value.ToString("C")}");
            }
        }
    }
}