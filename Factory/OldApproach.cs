using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public enum CoordinateSystem
    {
        Cartesian,
        Polar
    }
    public class PointOldPApproach
    {
        private double x, y;
        /// <summary>
        /// intializes A point from Either cartesian or polar
        /// </summary>
        /// <param name="a">x if cartesian, rho if polar</param>
        /// <param name="b">y if cartesian, Theta if polar</param>
        /// <param name="system">Enum for Cartesian or polar</param>
        public PointOldPApproach(double a, double b,
            CoordinateSystem system = CoordinateSystem.Cartesian)
        {
            switch (system)
            {
                case CoordinateSystem.Cartesian:
                    x = a;
                    y = b;
                    break;
                case CoordinateSystem.Polar:
                    x = a * Math.Cos(b);
                    y = a * Math.Sin(b);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(system), system, null);
            }
        }

        public override string ToString()
        {
            return $" {nameof(x)}: {x} and {nameof(y)}: {y}";
        }
    }
}
