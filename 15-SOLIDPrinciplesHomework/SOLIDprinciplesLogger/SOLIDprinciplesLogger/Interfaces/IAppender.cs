namespace SOLIDprinciplesLogger.Interfaces
{
    using System;
    using Models;

    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }

        ILayout Layout { get; }

        void Append(DateTime date, ReportLevel reportLevel, string message);
    }
}
