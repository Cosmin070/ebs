using System;

namespace EBS
{
    class GeneratePublication
    {
        public Publication Generate(double lowerBoundValue, double upperBoundValue,
            double lowerBoundDrop, double upperBoundDrop,
            double lowerBoundVariation, double upperBoundVariation)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            double value = random.NextDouble() * (upperBoundValue - lowerBoundValue) + lowerBoundValue;
            double drop = random.NextDouble() * (upperBoundDrop - lowerBoundDrop) + lowerBoundDrop;
            double variation = random.NextDouble() * (upperBoundVariation - lowerBoundVariation) + lowerBoundVariation;
            string company = (string)Enum.GetValues(typeof(Company)).GetValue(random.Next(Enum.GetValues(typeof(Company)).Length)).ToString();
            Publication pub = new Publication(company, value, drop, variation, DateTime.Now.AddDays(-random.Next(90)));
            return pub;
        }
    }
}
