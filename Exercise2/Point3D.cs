namespace Exercise2
{
    public class Point3D
    {
        /// <summary>
        /// Property X
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Property Y
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// Property Z
        /// </summary>
        public double Z { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Point3D()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        /// <summary>
        /// Constructor with the variables as parameters
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Method that allows to move the current point to a new one position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void MoveTo(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Method to calculate the distance between the current point and another point entered as a parameter
        /// </summary>
        /// <param name="point3D"></param>
        /// <returns></returns>
        public double DistanceTo(Point3D point3D) => Math.Pow((Math.Pow(point3D.X - X, 2) + Math.Pow(point3D.Y - Y, 2) + Math.Pow(point3D.Z - Z, 2) * 1.0), 0.5);

        /// <summary>
        /// Method to print the properties of the class as string variable
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>  $"{X},{Y},{Z}";
    }
}