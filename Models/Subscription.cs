using EBS.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.Models
{
    class Subscription
    {
        public HashSet<Condition> conditions = new HashSet<Condition>();
        public void addCondition(Condition condition)
        {
            this.conditions.Add(condition);
        }

        public bool checkIfConditionAlreadyExists(string field)
        {
            foreach (Condition condition in conditions)
            {
                Console.WriteLine($"{field} {condition.field}");
                if (condition.field == field)
                    return true;
            }
            return false;
        }
    }
}
