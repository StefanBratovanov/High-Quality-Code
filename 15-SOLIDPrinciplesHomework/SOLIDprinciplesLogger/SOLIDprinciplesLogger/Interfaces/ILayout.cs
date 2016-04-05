namespace SOLIDprinciplesLogger.Interfaces
{
    using System;
    using Models;

    public interface ILayout
    {
        string FormatLog(DateTime date, ReportLevel reportLevel, string message);
    }
}
