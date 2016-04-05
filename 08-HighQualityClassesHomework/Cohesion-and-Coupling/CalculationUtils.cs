namespace CohesionAndCoupling
{
    using System;

    static class CalculationUtils
    {
        public static double Width { get; set; }
        public static double Height { get; set; }
        public static double Depth { get; set; }

        public static double CalcVolume()
        {
            double volume = Width * Height * Depth;

            return volume;
        }

        public static double CalcDiagonalXYZ()
        {
            double distance = CalcDistance3D(0, 0, 0, Width, Height, Depth);

            return distance;
        }

        public static double CalcDiagonalXY()
        {
            double distance = CalcDistance2D(0, 0, Width, Height);
            return distance;
        }

        public static double CalcDiagonalXZ()
        {
            double distance = CalcDistance2D(0, 0, Width, Depth);
            return distance;
        }

        public static double CalcDiagonalYZ()
        {
            double distance = CalcDistance2D(0, 0, Height, Depth);
            return distance;
        }

        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            var deltaX = x2 - x1;
            var deltaY = y2 - y1;

            var distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));

            return distance;
        }

        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            var deltaX = x2 - x1;
            var deltaY = y2 - y1;
            var deltaZ = z2 - z1;

            var distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY) + (deltaZ * deltaZ));

            return distance;
        }
    }
}
