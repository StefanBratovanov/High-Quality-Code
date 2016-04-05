using AirConditionerTestingSystem.Interfaces;

namespace AirConditionerTestingSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Data;
    using Models;
    using Models.AirConditioners;
    using Utilities;

    public class Controller : IController
    {
        private AirConditionerTestingSystemData database;

        public Controller()
        {
            this.database = new AirConditionerTestingSystemData();
        }

        public void ProcessCommand(Command command)
        {
            try
            {
                switch (command.Name)
                {
                    case "RegisterStationaryAirConditioner":
                        this.ValidateParametersCount(command, 4);
                        this.ValidateEfficiencyRating(command.Parameters[2]);
                        this.RegisterStationaryAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            command.Parameters[2],
                            int.Parse(command.Parameters[3]));
                        break;
                    case "RegisterCarAirConditioner":
                        this.ValidateParametersCount(command, 3);
                        this.RegisterCarAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            int.Parse(command.Parameters[2]));
                        break;
                    case "RegisterPlaneAirConditioner":
                        this.ValidateParametersCount(command, 4);
                        this.RegisterPlaneAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            int.Parse(command.Parameters[2]),
                            int.Parse(command.Parameters[3]));
                        break;
                    case "TestAirConditioner":
                        this.ValidateParametersCount(command, 2);
                        this.TestAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1]);
                        break;
                    case "FindAirConditioner":
                        this.ValidateParametersCount(command, 2);
                        this.FindAirConditioner(
                            command.Parameters[1],
                            command.Parameters[0]);
                        break;
                    case "FindReport":
                        this.ValidateParametersCount(command, 2);
                        this.FindReport(
                            command.Parameters[0],
                            command.Parameters[1]);
                        break;
                    case "Status":
                        this.ValidateParametersCount(command, 0);
                        this.Status();
                        break;
                    default:
                        throw new IndexOutOfRangeException(Constants.Invalidcommand);
                }
            }
            catch (FormatException ex)
            {
                throw new InvalidOperationException(Constants.Invalidcommand, ex.InnerException);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new InvalidOperationException(Constants.Invalidcommand, ex.InnerException);
            }
        }

        public string RegisterStationaryAirConditioner(string manufacturer, string model, string energyEfficiencyRating, int powerUsage)
        {
            StationaryAirConditioner airConditioner = new StationaryAirConditioner(manufacturer, model, energyEfficiencyRating, powerUsage);
            this.database.AirConditioners.Add(airConditioner);
            throw new InvalidOperationException(string.Format(Constants.Register, airConditioner.Model, airConditioner.Manufacturer));
        }

        public string RegisterCarAirConditioner(string manufacturer, string model, int volumeCoverage)
        {
            CarAirConditioner airConditioner = new CarAirConditioner(manufacturer, model, volumeCoverage);
            this.database.AirConditioners.Add(airConditioner);
            throw new InvalidOperationException(
                string.Format(Constants.Register, airConditioner.Model, airConditioner.Manufacturer));
        }
        /// <summary>
        /// Registers Plane Air Conditioner by given manufacturer, model, volumeCoverage and electricityUsed
        /// </summary>
        /// <param name="manufacturer">The manufacturer of the air conditioner</param>
        /// <param name="model">The model of the air conditioner</param>
        /// <param name="volumeCoverage">The volume coverage of the air conditioner</param>
        /// <param name="electricityUsed">The electricityUsed of the air conditioner</param>
        /// <returns>A message "Air Conditioner [model]  from [manufacturer] registered successfully." in case of success or 
        /// throws an Exception with apprporiate message</returns>
        public string RegisterPlaneAirConditioner(string manufacturer, string model, int volumeCoverage, int electricityUsed)
        {
            PlaneAirConditioner airConditioner = new PlaneAirConditioner(manufacturer, model, volumeCoverage, electricityUsed);
            this.database.AirConditioners.Add(airConditioner);
            throw new InvalidOperationException(
                string.Format(Constants.Test, airConditioner.Model, airConditioner.Manufacturer));
        }

        public string TestAirConditioner(string manufacturer, string model)
        {
            AirConditioner airConditioner = this.database.GetAirConditioner(manufacturer, model);
            var mark = airConditioner.Test();
            this.database.Reports.Add(new Reprot(airConditioner.Manufacturer, airConditioner.Model, mark));
            throw new InvalidOperationException(string.Format(Constants.Test, model, manufacturer));
        }
        /// <summary>
        /// Finds Air Conditioner by given manufacturer, model
        /// </summary>
        /// <param name="manufacturer">The manufacturer of the air conditioner</param>
        /// <param name="model">The model of the air conditioner</param>
        /// <returns>Prints the Air conditioner attributes by type in case of success or
        /// threow NonExistantEntryException</returns>
        public string FindAirConditioner(string manufacturer, string model)
        {
            AirConditioner airConditioner = this.database.GetAirConditioner(manufacturer, model);
            throw new InvalidOperationException(airConditioner.ToString());
        }

        public string FindReport(string manufacturer, string model)
        {
            Reprot report = this.database.GetReport(manufacturer, model);
            throw new InvalidOperationException(report.ToString());
        }

        public string FindAllReportsByManufacturer(string manufacturer)
        {
            List<Reprot> reports = this.database.GetReportsByManufacturer(manufacturer);
            if (reports.Count == 0)
            {
                return Constants.Noreports;
            }

            reports = reports.OrderBy(x => x.Mark).ToList();
            StringBuilder reportsPrint = new StringBuilder();
            reportsPrint.AppendLine(string.Format("Reports from {0}:", manufacturer));
            reportsPrint.Append(string.Join(Environment.NewLine, reports));
            return reportsPrint.ToString();
        }
        /// <summary>
        /// Prints a message displaying the status of the system (percentage of air conditioners tested)
        /// </summary>
        /// <returns>A message displaying the percentage of air conditioners tested rounded to two decimal places</returns>
        public string Status()
        {
            int reports = this.database.GetReportsCount();
            double airConditioners = this.database.GetAirConditionersCount();

            double percent = reports / airConditioners;
            percent = percent * 100;
            return string.Format(Constants.Status, percent);
        }

        public void ValidateParametersCount(Command command, int count)
        {
            if (command.Parameters.Length != count)
            {
                throw new InvalidOperationException(Constants.Invalidcommand);
            }
        }

        private void ValidateEfficiencyRating(string efficiencyRating)
        {
            string[] validEfficiencyRatings = { "A", "B", "C", "D", "E" };

            var isValid = validEfficiencyRatings.Any(t => t == efficiencyRating);

            if (!isValid)
            {
                throw new ArgumentException(Constants.IncorrectRating);
            }
        }
    }
}
