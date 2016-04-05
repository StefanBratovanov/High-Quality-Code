namespace AirConditionerTestingSystem
{
    using System.Globalization;
    using System.Threading;
    using Core;
    using UserInterface;

    public class AirConditionerTestingSystemMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var engine = new AirConditionerTestingSystemSystemEngine();
            engine.Run();
        }
    }
}
