using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.Models.Utils
{
    public class Condition
    {
        public string field { get; }
        public string mathematicalOperator { get; }
        public Object value { get; }

        public Condition(string field, string mathematicalOperator, Object value)
        {
            this.field = field;
            this.mathematicalOperator = mathematicalOperator;
            this.value = value;
        }

        public override string ToString()
        {
            return $"Field: {this.field}, Operator: {this.mathematicalOperator}, Value: {this.value}";
        }
    }
}
