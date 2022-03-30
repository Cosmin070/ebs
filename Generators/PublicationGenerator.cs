using EBS.Generators;
using System;

namespace EBS
{
    class PublicationGenerator
    {
        public Publication Generate(double lowerBoundValue, double upperBoundValue,
            double lowerBoundDrop, double upperBoundDrop,
            double lowerBoundVariation, double upperBoundVariation)
        {
            string company = Generator.GenerateCompany();
            double value = Generator.GenerateDouble(lowerBoundValue, upperBoundValue);
            double drop = Generator.GenerateDouble(lowerBoundDrop, upperBoundDrop);
            double variation = Generator.GenerateDouble(lowerBoundVariation, upperBoundVariation);
            DateTime date = Generator.GenerateDate();
            Publication pub = new Publication(company, value, drop, variation, date);
            return pub;
        }
    }
}
