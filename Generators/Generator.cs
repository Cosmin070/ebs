using EBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.Generators
{
    static class Generator
    {
        public static string GenerateCompany()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            return (string)Enum.GetValues(typeof(Company)).GetValue(random.Next(Enum.GetValues(typeof(Company)).Length)).ToString();
        }

        public static double GenerateDouble(double lowerBound, double upperBound)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            return Math.Round(random.NextDouble() * (upperBound - lowerBound) + lowerBound, 2);
        }

        public static DateTime GenerateDate()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            return DateTime.Now.AddDays(-random.Next(90));
        }

        public static string GenerateOperator()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int op = random.Next(5);
            switch (op)
            {
                case 0:
                    return Operators.Equal;
                case 1:
                    return Operators.GreaterEqual;
                case 2:
                    return Operators.LessEqual;
                case 3:
                    return Operators.GreaterThan;
                case 4:
                    return Operators.LessThan;
                default:
                    return Operators.Equal;
            }
        }
    }
}
