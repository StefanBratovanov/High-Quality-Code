using System.Linq;

namespace AirConditionerTestingSystem.Models.AirConditioners
{
    using System;
    using System.Text;
    using Utilities;

    public class StationaryAirConditioner : AirConditioner
    {
        private string requiredEnergyEfficiencyRating;

        private int powerUsage;

        public StationaryAirConditioner(string manufacturer, string model, string requiredEnergyEfficiencyRating, int powerUsage)
            : base(manufacturer, model)

        {
            this.RequiredEnergyEfficiencyRating = requiredEnergyEfficiencyRating;
            this.PowerUsage = powerUsage;
        }

        public int PowerUsage
        {
            get
            {
                return this.powerUsage;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(Constants.Nonpositive, "Power Usage"));
                }

                this.powerUsage = value;
            }
        }

        public string RequiredEnergyEfficiencyRating
        {
            get { return this.requiredEnergyEfficiencyRating; }
            set { this.requiredEnergyEfficiencyRating = value; }
        }

        public override int Test()
        {
            int minPowerUsageValue = 0;
            int maxPowerUsageValue = 0;

            if (this.requiredEnergyEfficiencyRating == "A")
            {
                minPowerUsageValue = 0;
                maxPowerUsageValue = 999;
            }
            else if (this.requiredEnergyEfficiencyRating == "B")
            {
               minPowerUsageValue = 1000;
                maxPowerUsageValue = 1250;
            }
            else if (this.requiredEnergyEfficiencyRating == "C")
            {
               minPowerUsageValue  = 1251;
                maxPowerUsageValue = 1500;
            }
            else if (this.requiredEnergyEfficiencyRating == "D")
            {
                minPowerUsageValue  = 1501;
                maxPowerUsageValue = 2000;
            }
            else if (this.requiredEnergyEfficiencyRating == "E")
            {
                minPowerUsageValue  = 2001;
                maxPowerUsageValue = int.MaxValue;
            }

            if (this.PowerUsage <= minPowerUsageValue && this.PowerUsage <= maxPowerUsageValue)
            {
                return 1;
            }

            return 0;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendFormat("Required energy efficiency rating: {0}", this.RequiredEnergyEfficiencyRating)
                .AppendLine()
                .AppendFormat("Power Usage(KW / h): {0}", this.PowerUsage).AppendLine()
                .AppendLine("====================");

            return sb.ToString().Trim();

        }
    }
}



