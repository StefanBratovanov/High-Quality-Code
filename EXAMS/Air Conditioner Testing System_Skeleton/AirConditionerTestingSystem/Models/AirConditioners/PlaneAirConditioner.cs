namespace AirConditionerTestingSystem.Models.AirConditioners
{
    using System;
    using Utilities;

    public class PlaneAirConditioner : AirConditioner
    {
        private int volumeCovered;

        private int electricityUsed;

        public PlaneAirConditioner(string manufacturer, string model, int volumeCovered, int electricityUsed)
            : base(manufacturer, model)
        {
            this.VolumeCovered = volumeCovered;
            this.ElectricityUsed = electricityUsed;
        }

        public int ElectricityUsed
        {
            get { return this.electricityUsed; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(Constants.Nonpositive, "Electricity Used"));
                }

                this.electricityUsed = value;
            }
        }

        public int VolumeCovered
        {
            get { return this.volumeCovered; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Constants.Nonpositive, "Volume Covered"));
                }

                this.volumeCovered = value;
            }
        }

        public override int Test()
        {
            double sqrtVolume = Math.Sqrt(this.volumeCovered);
            double ratio = this.ElectricityUsed / sqrtVolume;
            if (ratio < Constants.MinPlaneElectricity)
            {
                return 1;
            }

            return 0;
        }
    }
}
