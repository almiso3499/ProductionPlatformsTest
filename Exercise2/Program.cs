using Exercise2;
using System.Text;

    Console.WriteLine("Points3D Program starting...");
    var points = ReadTextFile(); // Reading the points
    var firstPoint = points[0]; // Taking the first point 
    
    // Iterating the list of points from the second element to the last one 
    for (var i = 1; i < points.Count; i++)
    {
        // The following line prints the distance between the firs point and the current point of the iteration
        Console.WriteLine($"Distance between {firstPoint.ToString()} and {points[i].ToString()} is {firstPoint.DistanceTo(points[i])}");
    }

    Console.WriteLine("Points3D Program has finished");

    /// <summary>
    /// Method to read the text file and return a list of Point3D objects
    /// </summary>
    static List<Point3D> ReadTextFile()
    {
        try
        {
            var points = new List<Point3D>();
            foreach (string line in File.ReadLines(@".\Input3DPoints.txt", Encoding.UTF8))
            {
                points.Add(GetPoint(line));
            }
            Console.WriteLine("The points have been read correctly");
            return points;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"An error has occurred reading the text file");
            Console.WriteLine(exception.Message);
            Console.WriteLine(exception.StackTrace);
            throw;
        }
    }

    /// <summary>
    /// Method to Cast the line of the text file to a Point3D object
    /// </summary>
    /// <param name="textLine"></param>
    static Point3D GetPoint(string textLine)
    {
        try
        {
            var position = textLine.IndexOf("(");
            var points = textLine.Substring(position + 1, 8);
            var pointSplitted = points.Split(',');
            return new Point3D(double.Parse(pointSplitted[0]), double.Parse(pointSplitted[1]), double.Parse(pointSplitted[2]));
        }
        catch (Exception exception)
        {
            Console.WriteLine($"An error has occurred parsing the point");
            Console.WriteLine(exception.Message);
            Console.WriteLine(exception.StackTrace);
            throw;
        }
    }