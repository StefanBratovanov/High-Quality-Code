
namespace Huy_Phuong.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Huy_Phuong.Exceptions;

    /// <summary>
    /// Defines a database repository holding theatres and performances
    /// </summary>
    public interface IPerformanceDatabase
    {
        /// <summary>
        /// Adds a theatre to the database.
        /// </summary>
        /// <param name="theatreName">theatre name</param>
        ///<exception cref="TheatreNotFoundException">Thrown when theatre with the same name exist in DB</exception>
        void AddTheatre(string theatreName);

        /// <summary>
        /// Lists all theatres.
        /// </summary>
        /// <returns>Comma separated theatre names</returns>
        IEnumerable<string> ListTheatres();

        /// <summary>
        /// Adds a new performance to an existing theatre. 
        /// </summary>
        /// <param name="theatreName">theatre name</param>
        /// <param name="performanceTitle">performance title</param>
        /// <param name="performanceStartDateTime">performance start date and time</param>
        /// <param name="duration">performance duration</param>
        /// <param name="price">performance price</param>
        /// <exception cref="TheatreNotFoundException">Thrown when adding performance to non-existing theatre.</exception>
        /// <exception cref="TimeDurationOverlapException">Thrown when performance overlaps with another performance in the same theatre.</exception>
        void AddPerformance(string theatreName, string performanceTitle, DateTime performanceStartDateTime, TimeSpan duration, decimal price);

        /// <summary>
        ///  Lists all Performances.
        /// </summary>
        /// <returns>Comma separated performances and their details</returns>
        IEnumerable<Performance> ListAllPerformances();

        /// <summary>
        /// Lists all performances by theatre.
        /// </summary>
        /// <param name="theatreName">theatre name</param>
        /// <returns>Comma separated performances and their details</returns>
        /// <exception cref="TheatreNotFoundException">Thrown when non-existing theatre is given.</exception>
        IEnumerable<Performance> ListPerformances(string theatreName);
    }
}
