namespace AirConditionerTestingSystem.Models.AirConditioners
{
    using System;
    using System.Text;
    using Utilities;
    using Interfaces;

    public abstract class AirConditioner : IAirConditioner
    {
        private string manufacturer;

        private string model;

        protected AirConditioner(string manufacturer, string model)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < Constants.ManufacturerMinLength)
                {
                    throw new ArgumentException(string.Format(Constants.IncorrectPropertyLength, "Manufacturer", Constants.ManufacturerMinLength));
                }

                this.manufacturer = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < Constants.ModelMinLength)
                {
                    throw new ArgumentException(string.Format(Constants.IncorrectPropertyLength, "Model", Constants.ModelMinLength));
                }

                this.model = value;
            }
        }

        public abstract int Test();

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Air Conditioner")
            .AppendLine("====================")
            .AppendFormat("Manufacturer: {0}", this.Manufacturer).AppendLine()
            .AppendFormat("Model: {0}", this.Model).AppendLine();


            return sb.ToString().Trim();
        }
    }
}
