using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Of_List_Multiple_Sheets
{
    public class Point
    {
        private double _xCoordinate;
        private double _yCoordinate;

        public double XCoordinate
        {
            get
            {
                return (this._xCoordinate);
            }
            set
            {
                this._xCoordinate = value;
            }
        }

        public double YCoordinate
        {
            get
            {
                return (this._yCoordinate);
            }
            set
            {
                this._yCoordinate = value;
            }
        }

        public Point(double XCoordinateParameter, double YCoordinateParameter)
        {
            this.XCoordinate = XCoordinateParameter;
            this.YCoordinate = YCoordinateParameter;
        }

        public Point()
        {
            this.XCoordinate = 0;
            this.YCoordinate = 0;
        }

        // Her definerer vi Operator Overload på operatoren + for objekert af klassen Point
        public static Point operator +(Point Point1,
                                       Point Point2)
        {
            Point Point3 = new Point();

            Point3.XCoordinate = Point1.XCoordinate + Point2.XCoordinate;
            Point3.YCoordinate = Point1.YCoordinate + Point2.YCoordinate;

            return (Point3);
        }

        // Klassen skal override Equals metoden for at distinct virker på klassen.
        // Og dermed at man kan fjerne dubletter !!!
        // Og man ikke skal få en compiler warning !!!
        public override bool Equals(object obj)
        {

            var other = obj as Point;
            return ((this.XCoordinate == other.XCoordinate) &&
                    (this.YCoordinate == other.YCoordinate));
        }

        // Klassen skal override GetHashCode metoden for at distinct virker på klassen.
        // Og dermed at man kan fjerne dubletter !!!
        // Og man ikke skal få en compiler warning !!!
        public override int GetHashCode()
        {
            return (this.XCoordinate.GetHashCode() + this.YCoordinate.GetHashCode());
        }

        public static bool operator ==(Point Point1,
                                        Point Point2)
        {
            //if ((Point1.XCoordinate == Point2.XCoordinate) &&
            //     (Point1.YCoordinate == Point2.YCoordinate))
            //    return (true);
            //else
            //    return (false);
            return (Point1.Equals(Point2));
        }

        public static bool operator !=(Point Point1,
                                       Point Point2)
        {
            //if ((Point1.XCoordinate == Point2.XCoordinate) &&
            //    (Point1.YCoordinate == Point2.YCoordinate))
            //    return (false);
            //else
            //    return (true);
            return (!Point1.Equals(Point2));
        }

        // Her overrider vi ASP.NET Frameworkets generelle write metode. 
        // Således vil strengen i Return sætningen blive returneret, når
        // vi bruger f.eks. Console.WriteLine på et objekct af klassen Point.
        public override string ToString()
        {
            return ("(" + this.XCoordinate.ToString() + "; " + this.YCoordinate.ToString() + ")");
        }
    }
}
