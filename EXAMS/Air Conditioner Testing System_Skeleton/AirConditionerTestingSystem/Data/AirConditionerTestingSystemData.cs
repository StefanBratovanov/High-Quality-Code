namespace AirConditionerTestingSystem.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Models.AirConditioners;

    public class AirConditionerTestingSystemData
    {

        public AirConditionerTestingSystemData()
        {
            this.AirConditioners = new List<AirConditioner>();
            this.Reports = new List<Reprot>();
        }

        public List<AirConditioner> AirConditioners { get; private set; }

        public List<Reprot> Reports { get; private set; }

        public void AddAirConditioner(StationaryAirConditioner airConditioner)
        {
            this.AirConditioners.Add(airConditioner);
        }

        public void RemoveAirConditioner(StationaryAirConditioner airConditioner)
        {
            this.AirConditioners.Remove(airConditioner);
        }

        public StationaryAirConditioner GetAirConditioner(string manufacturer, string model)
        {
            return (StationaryAirConditioner)this.AirConditioners.First(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public int GetAirConditionersCount()
        {
            return this.AirConditioners.Count;
        }

        public void AddReport(Reprot report)
        {
            this.Reports.Add(report);
        }

        public void RemoveReport(Reprot report)
        {
            this.Reports.Remove(report);
        }

        public Reprot GetReport(string manufacturer, string model)
        {
            return this.Reports.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public int GetReportsCount()
        {
            return this.Reports.Count;
        }

        public List<Reprot> GetReportsByManufacturer(string manufacturer)
        {
            return this.Reports.Where(x => x.Manufacturer == manufacturer).ToList();
        }
    }
}
