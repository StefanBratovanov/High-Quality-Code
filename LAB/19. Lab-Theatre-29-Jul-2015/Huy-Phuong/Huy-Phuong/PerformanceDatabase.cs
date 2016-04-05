namespace Huy_Phuong
{
    using System;
    using System.Collections.Generic;
    using Huy_Phuong.Interfaces;
    using Huy_Phuong.Exceptions;

    public class PerformanceDatabase : IPerformanceDatabase
    {
        private readonly SortedDictionary<string, SortedSet<Performance>> theatrePerformances
            = new SortedDictionary<string, SortedSet<Performance>>();

        public void AddTheatre(string theatreName)
        {
            if (this.theatrePerformances.ContainsKey(theatreName))
            {
                throw new DuplicateTheatreException("Duplicate theatre");
            }

            this.theatrePerformances[theatreName] = new SortedSet<Performance>();
        }

        public IEnumerable<string> ListTheatres()
        {
            var theatres = this.theatrePerformances.Keys;
            return theatres;
        }

        public void AddPerformance(
            string theatreName,
            string performanceTitle,
            DateTime performanceStartDateTime,
            TimeSpan duration,
            decimal price)
        {
            if (!this.theatrePerformances.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var performancesByTheatereName = this.theatrePerformances[theatreName];
            var performanceEndTime = performanceStartDateTime + duration;
            var performancesOverlap = (PerformancesOverlap(performancesByTheatereName, performanceStartDateTime, performanceEndTime));

            if (performancesOverlap)
            {
                throw new TimeDurationOverlapException("Time/duration overlap");
            }

            var performance = new Performance(theatreName, performanceTitle, performanceStartDateTime, duration, price);
            performancesByTheatereName.Add(performance);
        }

        public IEnumerable<Performance> ListAllPerformances()
        {
            var theatres = this.theatrePerformances.Keys;
            var performancesList = new List<Performance>();

            foreach (var theatre in theatres)
            {
                var performances = this.theatrePerformances[theatre];
                performancesList.AddRange(performances);
            }

            return performancesList;
        }

        public IEnumerable<Performance> ListPerformances(string theatreName)
        {
            if (!this.theatrePerformances.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var performances = this.theatrePerformances[theatreName];
            return performances;
        }

        private static bool PerformancesOverlap(
            IEnumerable<Performance> performances,
            DateTime performanceStartDateTime,
            DateTime performanceEndTime)
        {
            foreach (var p in performances)
            {
                var savedPerformanceStart = p.PerformanceDateStart;
                var savedPerformanceEnd = savedPerformanceStart + p.Duration;

                var thereIsOverlapping =
                    (savedPerformanceStart <= performanceStartDateTime && performanceStartDateTime <= savedPerformanceEnd) ||
                    (savedPerformanceStart <= performanceEndTime && performanceEndTime <= savedPerformanceEnd) ||
                    (performanceStartDateTime <= savedPerformanceStart && savedPerformanceStart <= performanceEndTime) ||
                    (performanceStartDateTime <= savedPerformanceEnd && savedPerformanceEnd <= performanceEndTime);

                if (thereIsOverlapping)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
