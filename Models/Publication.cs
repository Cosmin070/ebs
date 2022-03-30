using System;

namespace EBS
{
    class Publication
    {
        public string Company { get; set; }
        public double Value { get; set; }
        public double Drop { get; set; }
        public double Variation { get; set; }
        public DateTime Date { get; set; }

        public Publication(string company, double value, double drop, double variation, DateTime time) 
        {
            this.Company = company;
            this.Value = value;
            this.Drop = drop;
            this.Variation = variation;
            this.Date = time;
        }

        public override string ToString()
        {
            return $"Publication: {this.Company}, Value: {this.Value}, Drop: {this.Drop}, Variation: {this.Variation}, Date: {this.Date.ToString("MM/dd/yyyy")}";
        }
    }
}
