using System;
/// <summary>
///  Problem To solve
///  constructor has some proplems such as in overloading with the same no. and type of parameters
///  so we go to factory pattern to intiate objects
/// </summary>
namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            //Origin Point
            Console.WriteLine(Point.Origin);

            Console.WriteLine();
            Console.WriteLine("____________________________________");
            Console.WriteLine();

            #region OldApproach
            PointOldPApproach POld1 = new PointOldPApproach(5, 15, CoordinateSystem.Cartesian);
            PointOldPApproach POld2 = new PointOldPApproach(6, 30, CoordinateSystem.Polar);
            Console.WriteLine(POld1);
            Console.WriteLine(POld2);
            #endregion

            Console.WriteLine();
            Console.WriteLine("____________________________________");
            Console.WriteLine();

            #region FactoryMethodApproach
            Point PCartesian = Point.Factory.NewCartesianPoint(5, 15);
            Point PPolar = Point.Factory.NewPolarPoint(6, 30);
            Console.WriteLine(PCartesian);
            Console.WriteLine(PPolar);
            #endregion
        }
    }
}
