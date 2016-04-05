

namespace SOLIDprinciplesLogger.Models.Layouts
{
    using System;
    using Interfaces;
    using System.Text;

    public class XmlLayout : ILayout
    {
        public string FormatLog(DateTime date, ReportLevel reportLevel, string message)
        {
            var formattedLog = new StringBuilder();

            formattedLog.AppendLine("<log>");
            formattedLog.AppendLine($"\t<date>{date}</date>");
            formattedLog.AppendLine($"\t<level>{reportLevel}</level>");
            formattedLog.AppendLine($"\t<message>{message}</message>");
            formattedLog.AppendLine("</log>");

            return formattedLog.ToString();
        }
    }
}
