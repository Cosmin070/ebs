using EBS.Generators;
using EBS.Models;
using EBS.Models.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace EBS
{
    class Runner
    {
        public static void Main(string[] args)
        {
            // Config Publication
            const double MIN_VALUE = 0.2f;
            const double MAX_VALUE = 0.8f;
            const double MIN_DROP = 0.2f;
            const double MAX_DROP = 0.8f;
            const double MIN_VARIATION = 0.2f;
            const double MAX_VARIATION = 0.8f;
            // Config Subscription
            const int NUMBER_OF_SUBSCRIPTIONS = 10;
            const int COMPANY_SUBSCRIPTION_FREQUENCY = 100;
            const int VALUE_SUBSCRIPTION_FREQUENCY = 80;
            const int DROP_SUBSCRIPTION_FREQUENCY = 80;
            const int VARIATION_SUBSCRIPTION_FREQUENCY = 100;
            const int DATE_SUBSCRIPTION_FREQUENCY = 0;

            const int EQUAL_FREQUENCY = 70;

            int NUMBER_OF_COMPANY = Convert.ToInt32(Math.Round((decimal)COMPANY_SUBSCRIPTION_FREQUENCY / NUMBER_OF_SUBSCRIPTIONS, 0));
            int NUMBER_OF_VALUE = Convert.ToInt32(Math.Round((decimal)VALUE_SUBSCRIPTION_FREQUENCY / NUMBER_OF_SUBSCRIPTIONS, 0));
            int NUMBER_OF_DROP = Convert.ToInt32(Math.Round((decimal)DROP_SUBSCRIPTION_FREQUENCY / NUMBER_OF_SUBSCRIPTIONS, 0));
            int NUMBER_OF_VARIATION = Convert.ToInt32(Math.Round((decimal)VARIATION_SUBSCRIPTION_FREQUENCY / NUMBER_OF_SUBSCRIPTIONS, 0));
            int NUMBER_OF_DATE = Convert.ToInt32(Math.Round((decimal)DATE_SUBSCRIPTION_FREQUENCY / NUMBER_OF_SUBSCRIPTIONS, 0));
            int NUMBER_OF_EQUAL = Convert.ToInt32(Math.Round((decimal)EQUAL_FREQUENCY / NUMBER_OF_SUBSCRIPTIONS, 0));
            //
            PublicationGenerator generator = new PublicationGenerator();
            Console.WriteLine(generator.Generate(MIN_VALUE, MAX_VALUE, MIN_DROP, MAX_DROP, MIN_VARIATION, MAX_VARIATION));
            Console.WriteLine(generator.Generate(MIN_VALUE, MAX_VALUE, MIN_DROP, MAX_DROP, MIN_VARIATION, MAX_VARIATION));
            Console.WriteLine(generator.Generate(MIN_VALUE, MAX_VALUE, MIN_DROP, MAX_DROP, MIN_VARIATION, MAX_VARIATION));
            Console.WriteLine(generator.Generate(MIN_VALUE, MAX_VALUE, MIN_DROP, MAX_DROP, MIN_VARIATION, MAX_VARIATION));
            Console.WriteLine(generator.Generate(MIN_VALUE, MAX_VALUE, MIN_DROP, MAX_DROP, MIN_VARIATION, MAX_VARIATION));
            // generam 100% si cazuri < 100% handle -> split 30 40 30 -> 30%, 40%, 30% 
            if (COMPANY_SUBSCRIPTION_FREQUENCY + VALUE_SUBSCRIPTION_FREQUENCY + DROP_SUBSCRIPTION_FREQUENCY + VARIATION_SUBSCRIPTION_FREQUENCY + DATE_SUBSCRIPTION_FREQUENCY < 100)
            {
                Environment.Exit(-1);
            }

            SubscriptionGenerator subscriptionGenerator =
                new SubscriptionGenerator(NUMBER_OF_COMPANY,
                    NUMBER_OF_VALUE, MIN_VALUE, MAX_VALUE,
                    NUMBER_OF_DROP, MIN_DROP, MAX_DROP,
                    NUMBER_OF_VARIATION, MIN_VARIATION, MAX_VARIATION,
                    NUMBER_OF_DATE,
                    NUMBER_OF_SUBSCRIPTIONS,
                    NUMBER_OF_EQUAL);

            List<Subscription> subscriptions = subscriptionGenerator.GetSubscriptions();
            string json = JsonConvert.SerializeObject(subscriptions);
            Console.WriteLine(json);
            string date = DateTime.Now.ToString("MM.dd.yyyy.HHmmss");
            File.WriteAllText($"subscriptions_{date}.json", json);
        }
    }
}
