// NOTE: the assignments are all in one file, first is Assignment 2.2.3, then 2.2.2, then 2.2.1
// Hatchmarked commented lines separate the code in each assignment

using Spectre.Console;
using Spectre.Console.Rendering;

using Assignments_2_2;

class Program
{
    static void Main(string[] args)
    {
        // Console rich text formatting, panels
        AnsiConsole.Write(new Panel("[gray]Object Oriented Programming Demonstration[/]").BorderColor(Color.MediumVioletRed));

        // Assignment 2.2.1
        AnsiConsole.MarkupLine("\n\n[bold magenta]Assignment 2.2.1[/]");
        EuroNoParkingSign strangeNewSign = new EuroNoParkingSign();
        strangeNewSign.InstructHumanDriver();

        // Assignment 2.2.2
        AnsiConsole.MarkupLine("\n\n[bold magenta]Assignment 2.2.2[/]");
        //Maths myMathInstance = new Maths(); // didn't like that this was not null????
        int a = 3;
        int b = 3;
        double c = 3.555;
        AnsiConsole.MarkupLine($"{a} + {b} + {c:F3} = " + Maths.Add(a, b, Convert.ToDecimal(c)) + "   [Turquoise4]// demo of Add      (3 params decimals)[/] ");
        AnsiConsole.MarkupLine($"{a} + {b}         = " + Maths.Add(a, b) + "       [Turquoise4]// demo of Add      (2 params integers)[/] ");
        AnsiConsole.MarkupLine($"{a} * {b} * {c:F3} = " + Maths.Multiply(a, b, Convert.ToDecimal(c)) + "  [Turquoise4]// demo of Multiply (3 params decimals)[/] ");
        AnsiConsole.MarkupLine($"{a} * {b}         = "   + Maths.Multiply(a, b)                        + "       [Turquoise4]// demo of Multiply (2 params decimals)[/] ");

        // Assignment 2.2.3
        AnsiConsole.MarkupLine("\n\n[bold magenta]Assignment 2.2.3[/]");
        Circle myCircle = new Circle();
        myCircle.Radius = 3.0;
        Console.WriteLine($"A circle with radius {myCircle.Radius} has an area of {myCircle.CalculateArea():F1}.");
        Square mySquare = new Square();
        mySquare.Length = 3.0;
        mySquare.CalculateArea();
        Console.WriteLine($"A square with length {mySquare.Length} has an area of {mySquare.CalculateArea():F1}.");

        Console.WriteLine("\n-----------------");
    }
}


/////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////
/// Assignment 2.2.3 - class heirarchy and polymorphism
///

// 3.Write a abstract base class: ‘Shape’ and add properties like id, name and color and method ‘calculate area’ .
// Inherit circle shape from base class and add properties like radius. override calculate area logic for circle.
// Inherit square class from shape and change the calculate area logic. Add property like side of square.
// 
// Take the input from user to select circle or square and display the calculated area . no hard coded values!

public abstract class Shape 
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    //public Shape(int id = 0, string name = "unnamed", string color = "none")
    //{
    //    ID = id;
    //    Name = name;
    //    Color = color;
    //}

    // better to leave explicit constructors off, built-in constructors leave all properties blank...
    public abstract double CalculateArea();
    //{
    //    return null; // returns null if this function is not overridden
    //}
}
//-------------------------
public class Circle : Shape
{
    public double Radius { get; set; }
    
    // removing this because automatic constructors better to leave as is
    //public Circle(int id, string name, string color, double radius) : base(id, name, color) 
    //{
    //    this.radius = radius;
    //}
    
    public override double CalculateArea()  
    {
        return Math.PI * 2 * Radius;
    }
}
//-------------------------
public class Square : Shape
{
    public double Length { get; set; }
    public override double CalculateArea() // since I used abstract in base class, I did not have to use the poss-null '?' type... because it 
    {
        return Length * Length;
    }
}








/////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////
/// Assignment 2.2.2 - simple maths class
///
//  See Maths.cs (separate file)




/////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////
/// Assignment 2.2.1 - class heirarchy and polymorphism
///

// --------------------------------- define some custom enums for shape and color ---------------------------------
//using System.Drawing; // I didn't think this was necessary but AI/visual studio tried to add it?

public enum ShapeType
{
    Triangle,
    Square,
    Rectangle,
    Pentagon,
    Octagon,
    Circle
}
public enum ColorType
{
    Red,
    Green,
    Blue,
    Yellow,
    White
}

// // uncomment Program class below, to demonstrate functionality of this class heirarchy

//class Program
//{
//    static void Main(string[] args)
//    {
//        EuroNoParkingSign strangeNewSign = new EuroNoParkingSign();
//        strangeNewSign.InstructHumanDriver();

//        //        Shape shape = Shape.Circle;
//        //        Color color = Color.Red;
//        //        Console.WriteLine($"Shape: {shape}, Color: {color}");
//    }
//}

// --------------------------------- define custom abstract (must-be-parent) TrafficSignBase class ----------------------------------
public abstract class TrafficSignBase
{
    public ShapeType Shape { get; set; }
    public ColorType Color { get; set; }
    public TrafficSignBase(ShapeType shape, ColorType color)
    {
        this.Shape = shape;
        this.Color = color;
    }
    public virtual void InstructHumanDriver() // demonstrates virtual function, which means it is expected to be overridden in derived classes, but not required to be
    {
        Console.WriteLine($"Obey the sign! The traffic Sign is {Shape} shape and {Color} color.");
    }
}

public sealed class StopSign : TrafficSignBase
{
    public StopSign() : base(ShapeType.Octagon, ColorType.Red)
    {
    }
    public override void InstructHumanDriver() // demonstrates overridden function
    {
        Console.WriteLine($"When you see this {Color} traffic sign in {Shape} shape, come to a complete stop.");
    }
}

public class YieldSign : TrafficSignBase
{
    public YieldSign() : base(ShapeType.Triangle, ColorType.Yellow)
    {
        // properties set in base constructor
    }
    public override void InstructHumanDriver()
    {
        Console.WriteLine($"When you see this {Color} traffic sign in {Shape} shape, slow down and yield to other vehicles.");
    }
}

public class SpeedLimitSign : TrafficSignBase
{
    public int SpeedLimit { get; set; }
    public SpeedLimitSign(int speedLimit) : base(ShapeType.Rectangle, ColorType.White) 
    { 
        this.SpeedLimit = speedLimit;
    }
    public override void InstructHumanDriver()
    {
        Console.WriteLine($"When you see this {Color} traffic sign in {Shape} shape, do not exceed the speed limit of {SpeedLimit} mph.");
    }
}

public class  EuroNoParkingSign : TrafficSignBase
{
    public ColorType SecondaryColor { get; }
    public EuroNoParkingSign() : base(ShapeType.Circle, ColorType.Blue)
    { 
        this.SecondaryColor = ColorType.Red;
    }

    // // // ---- the below function InstructHumanDriver() is commented out to demonstrate that the virtual base class function does not have to be overridden in this new class

    //public override void InstructHumanDriver() // demonstrates overridden function that simply calls the base class function
    //{
    //    base.InstructHumanDriver(); // in this case, we simply let the driver assume all responsibility up front
    //}
}

















