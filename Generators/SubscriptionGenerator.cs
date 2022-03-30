using EBS.Models;
using EBS.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.Generators
{
    class SubscriptionGenerator
    {
        readonly int numberCompany;
        readonly int numberValue;
        readonly int numberDrop;
        readonly int numberVariation;
        readonly int numberDate;
        readonly int numberSubscriptions;
        readonly int numberEquals;

        readonly double lowerBoundValue;
        readonly double upperBoundValue;
        readonly double lowerBoundDrop;
        readonly double upperBoundDrop;
        readonly double lowerBoundVariation;
        readonly double upperBoundVariation;

        public SubscriptionGenerator(int numberCompany,
            int numberValue, double lowerBoundValue, double upperBoundValue,
            int numberDrop, double lowerBoundDrop, double upperBoundDrop,
            int numberVariation, double lowerBoundVariation, double upperBoundVariation,
            int numberDate,
            int numberSubscriptions,
            int numberEquals)
        {
            this.numberCompany = numberCompany;
            this.numberValue = numberValue;
            this.numberDrop = numberDrop;
            this.numberVariation = numberVariation;
            this.numberDate = numberDate;
            this.numberSubscriptions = numberSubscriptions;
            this.numberEquals = numberEquals;
            this.lowerBoundValue = lowerBoundValue;
            this.upperBoundValue = upperBoundValue;
            this.lowerBoundDrop = lowerBoundDrop;
            this.upperBoundDrop = upperBoundDrop;
            this.lowerBoundVariation = lowerBoundVariation;
            this.upperBoundVariation = upperBoundVariation;
        }
        public List<Subscription> GetSubscriptions()
        {
            List<Subscription> subscriptions = new List<Subscription>();
            List<Condition> conditions = GetConditions();
            for(int i = 0; i< numberSubscriptions; i++)
            {
                subscriptions.Add(new Subscription());
            }
            int index = 0;
            foreach (Condition condition in conditions)
            {
                Subscription subscription = subscriptions[index];
                while(subscription.checkIfConditionAlreadyExists(condition.field))
                {
                    index = index == subscriptions.Count - 1 ? 0 : index + 1;
                    subscription = subscriptions[index];
                }
                subscription.addCondition(condition);
                index = index == subscriptions.Count - 1 ? 0 : index + 1;
            }
            return subscriptions;
        }
        private List<Condition> GetConditions()
        {
            List<Condition> conditions = new List<Condition>();
            for (int i = 0; i < numberCompany; i++)
            {
                conditions.Add(new Condition("company", i < numberEquals ? Operators.Equal : Operators.NotEqual, Generator.GenerateCompany()));
            }
            for (int i = 0; i < numberValue; i++)
            {
                conditions.Add(new Condition("value", Generator.GenerateOperator(), Generator.GenerateDouble(lowerBoundValue, upperBoundValue)));
            }
            for (int i = 0; i < numberDrop; i++)
            {
                conditions.Add(new Condition("drop", Generator.GenerateOperator(), Generator.GenerateDouble(lowerBoundDrop, upperBoundDrop)));
            }
            for (int i = 0; i < numberVariation; i++)
            {
                conditions.Add(new Condition("variation", Generator.GenerateOperator(), Generator.GenerateDouble(lowerBoundVariation, upperBoundVariation)));
            }
            for (int i = 0; i < numberDate; i++)
            {
                conditions.Add(new Condition("date", Generator.GenerateOperator(), Generator.GenerateDate()));
            }
            return conditions;
        }
    }
}
