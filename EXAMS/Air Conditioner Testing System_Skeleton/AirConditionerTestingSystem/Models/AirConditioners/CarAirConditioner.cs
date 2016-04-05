using System;
using AirConditionerTestingSystem.Utilities;

namespace AirConditionerTestingSystem.Models.AirConditioners
{
    public class CarAirConditioner : AirConditioner
    {
        private int volumeCovered;

        public CarAirConditioner(string manufacturer, string model, int volumeCovered)
             : base(manufacturer, model)
        {
            this.VolumeCovered = volumeCovered;
        }

        public int VolumeCovered
        {
            get
            {
                return this.volumeCovered;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(Constants.Nonpositive, "Volume Covered"));
                }

                this.volumeCovered = value;
            }
        }

        public override int Test()
        {
            double sqrtVolume = Math.Sqrt(this.VolumeCovered);
            if (sqrtVolume >= Constants.MinCarVolume)
            {
                return 1;
            }

            return 0;
        }
    }
}
