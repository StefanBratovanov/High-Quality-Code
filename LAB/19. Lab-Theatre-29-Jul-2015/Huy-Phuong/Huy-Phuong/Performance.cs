

using System;

namespace Huy_Phuong
{
    public class Performance : IComparable<Performance>

    {
        public Performance(string theaterName, string performanceTitle, DateTime performanceDateStart, TimeSpan duration, decimal price)
        {
            this.TheaterName = theaterName;
            this.PerformanceTitle = performanceTitle;
            this.PerformanceDateStart = performanceDateStart;
            this.Duration = duration;
            this.Price = price;
        }

        public string TheaterName { get; set; }

        public string PerformanceTitle { get; set; }

        public DateTime PerformanceDateStart { get; set; }

        public TimeSpan Duration { get; private set; }

        public decimal Price { get; protected set; }

        public int CompareTo(Performance otherPerformance)
        {
            int result = this.PerformanceDateStart.CompareTo(otherPerformance.PerformanceDateStart);
            return result;
        }

        public override string ToString()
        {
            string result = string.Format("Performance(Theatre: {0}; Title: {1}; Starts on: {2}, Duration: {3}, Price: {4})",
                this.TheaterName,
                this.PerformanceTitle,
                this.PerformanceDateStart.ToString("dd.MM.yyyy HH:mm"),
                this.Duration.ToString("hh':'mm"),
                this.Price.ToString("f2"));
            return result;
        }
    }
}
