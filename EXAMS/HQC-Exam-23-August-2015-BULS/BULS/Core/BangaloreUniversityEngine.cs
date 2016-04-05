namespace BangaloreUniversityLearningSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using buls;
    using Models;
    using Interfaces;
    using Data;
    using Controllers;

    public class BangaloreUniversityEngine : IBangaloreUniversityEngine
    {
        public void Run()
        {
            var database = new BangaloreUniversityData();
            User currentUser = null;
            while (true)
            {
                string routeUrl = Console.ReadLine();
                if (routeUrl == null)
                {
                    break;
                }

                var route = new Route(routeUrl);
                var expectedController = route.ControllerName;
                var controllerType = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(type => type.Name == expectedController);

                var controller = Activator.CreateInstance
                    (controllerType,
                    database,
                    currentUser) as Controller;

                var action = controllerType.GetMethod(route.ActionName);

                object[] argumentsToPass = MapParameters(route, action);
                try
                {
                    var view = action.Invoke(controller, argumentsToPass) as IView;
                    var output = view.Display();
                    Console.WriteLine(output);

                    currentUser = controller.CurrentUser;
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        private static object[] MapParameters(Route route, MethodInfo action)
        {
            var expectedMethodparameters = action.GetParameters();
            var argumentsToPass = new List<object>();

            foreach (ParameterInfo param in expectedMethodparameters)
            {
                var currentArgument = route.Parameters[param.Name];
                if (param.ParameterType == typeof(int))
                {
                    argumentsToPass.Add(int.Parse(currentArgument));
                }
                else
                {
                    argumentsToPass.Add(currentArgument);
                }
            }

            return argumentsToPass.ToArray();

            //return action.GetParameters()
            //    .Select<ParameterInfo, object>(p =>
            //    {
            //        if (p.ParameterType == typeof(int))
            //        {
            //            return int.Parse(route._parameters[p.Name]);
            //        }

            //        return route._parameters[p.Name];
            //    })
            //    .ToArray();
        }
    }
}