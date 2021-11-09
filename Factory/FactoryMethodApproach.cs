using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{

    public class Point
    {
        private double x, y;

        /// <summary>
        /// private constructor to internal intialization
        /// </summary>
        /// <param name="x">first parameter</param>
        /// <param name="y">second parameter</param>
        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static Point Origin = new Point(0, 0);
        public static class Factory
        {
            /// <summary>
            ///     get new object in cartesian coordinates
            /// </summary>
            /// <param name="x">first diemention</param>
            /// <param name="y">second dimention</param>
            /// <returns>new point in cartesian coordenates</returns>
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            /// <summary>
            ///     get new object in Polar coordinates
            /// </summary>
            /// <param name="x">roh</param>
            /// <param name="y">Theta</param>
            /// <returns>new point in Polar coordenates</returns>
            public static Point NewPolarPoint(double roh, double Theta)
            {
                return new Point(roh * Math.Cos(Theta), roh * Math.Sin(Theta));
            }
        }

        public override string ToString()
        {
            return $" {nameof(x)}: {x} and {nameof(y)}: {y}";
        }
    }
}
