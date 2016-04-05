namespace Huy_Phuong
{
    using System;
    using System.Threading;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Huy_Phuong.Exceptions;
    using Huy_Phuong.Interfaces;

    internal partial class TheatersMain
    {
        private static IPerformanceDatabase performanceDB = new PerformanceDatabase();

        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == null)
                {
                    return;
                }

                if (inputLine != string.Empty)
                {
                    string command = ParseCommand(inputLine);
                    string[] commandParameters = GetCommandParameters(inputLine);

                    ExecuteCommand(command, commandParameters);
                }
            }
        }

        private static void ExecuteCommand(string command, string[] commandParameters)
        {
            string commandResult = string.Empty;
            try
            {
                switch (command)
                {
                    case "AddTheatre":
                        commandResult = ExecuteAddTheatreCommand(commandParameters);
                        break;
                    case "PrintAllTheatres":
                        commandResult = ExecutePrintAllTheatresCommand();
                        break;
                    case "AddPerformance":
                        commandResult = ExecuteAddPerformanceCommand(commandParameters);
                        break;
                    case "PrintAllPerformances":
                        commandResult = ExecutePrintAllPerformancesCommand();
                        break;
                    case "PrintPerformances":
                        commandResult = ExecutePrintPerformancesCommand(commandParameters);
                        break;
                    default:
                        commandResult = "Invalid command!";
                        break;
                }
            }
            catch (Exception ex)
            {
                commandResult = "Error: " + ex.Message;
            }

            Console.WriteLine(commandResult);
        }

        private static string ExecutePrintPerformancesCommand(string[] commandParameters)
        {
            string theatre = commandParameters[0];
            var performances = performanceDB
                .ListPerformances(theatre)
                .Select(p => string.Format("({0}, {1})",
                    p.PerformanceTitle,
                    p.PerformanceDateStart.ToString("dd.MM.yyyy HH:mm")))
                .ToList();

            if (performances.Any())
            {
                return string.Join(", ", performances);
            }
            return "No performances";
        }

        private static string ExecutePrintAllPerformancesCommand()
        {
            var performances = performanceDB
                .ListAllPerformances()
                .Select(p => string.Format("({0}, {1}, {2})",
                p.PerformanceTitle,
                p.TheaterName,
                p.PerformanceDateStart.ToString("dd.MM.yyyy HH:mm")))
                .ToList();
            if (performances.Any())
            {
                return string.Join(", ", performances);
            }

            return "No performances";
        }

        private static string ExecuteAddPerformanceCommand(string[] commandParameters)
        {
            string theatreName = commandParameters[0];
            string performanceTitle = commandParameters[1];
            DateTime startDateTime = DateTime.ParseExact(commandParameters[2], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse(commandParameters[3]);
            decimal price = decimal.Parse(commandParameters[4], CultureInfo.InvariantCulture);

            performanceDB.AddPerformance(theatreName, performanceTitle, startDateTime, duration, price);
            return "Performance added";
        }

        private static string ExecutePrintAllTheatresCommand()
        {
            var theatres = performanceDB.ListTheatres().ToList();
            if (theatres.Any())
            {
                return string.Join(", ", theatres);
            }

            return "No theatres";
        }

        private static string ExecuteAddTheatreCommand(string[] commandParameters)
        {
            string theatreName = commandParameters[0];
            performanceDB.AddTheatre(theatreName);
            return "Theatre added";
        }

        private static string ParseCommand(string inputLine)
        {
            string[] commandTokens = inputLine.Split('(');
            string command = commandTokens[0];
            return command;
        }

        private static string[] GetCommandParameters(string inputLine)
        {
            string[] commandTokens = inputLine.Split(new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
            string[] commandParameters = commandTokens
                .Skip(1)
                .Select(p => p.Trim())
                .ToArray();

            return commandParameters;
        }
    }
}
