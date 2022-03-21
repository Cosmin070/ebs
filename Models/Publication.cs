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
            this.Value = Math.Round(value, 2);
            this.Drop = Math.Round(drop,2);
            this.Variation = Math.Round(variation, 2);
            this.Date = time;
        }
        public override string ToString()
        {
            return $"Publication: {this.Company}, Value: {this.Value}, Drop: {this.Drop}, Variation: {this.Variation}, Date: {this.Date}";
        }
    }
}
