namespace SOLIDprinciplesLogger.Models.Appenders
{
    using System;
    using Interfaces;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(DateTime date, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                var formattedLogEntry = this.DsiplayLogEntry(date, reportLevel, message);

                Console.Write(formattedLogEntry);
            }
        }
    }
}
