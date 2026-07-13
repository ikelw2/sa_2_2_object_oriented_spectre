using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Assignments_2_2;

internal class Maths // sample class library, only contains "Add" and "Multiply" functions
{
    // Addition functionality overloaded
    public static int Add(int a, int b)
    {
        return a + b;
    }
    public static int Add(int a, int b, int c)
    {
        return a + b + c;
    }
    //public static double Add(double a, double b)
    //{
    //    return a + b;
    //}
    //public static double Add(double a, double b, double c)
    //{
    //    return a + b + c;
    //}
    public static decimal Add(decimal a, decimal b)
    {
        return a + b;
    }
    public static decimal Add(decimal a, decimal b, decimal c)
    {
        return a + b + c;
    }

    // Multiplication functionality overloaded
    public static int Multiply(int a, int b)
    {
        return a * b;
    }
    public static int Multiply(int a, int b, int c)
    {
        return a * b * c;
    }
    //public static double Multiply(double a, double b)
    //{
    //    return a * b;
    //}
    //public static double Multiply(double a, double b, double c)
    //{
    //    return a * b * c;
    //}
    public static decimal Multiply(decimal a, decimal b)
    {
        return a * b;
    }
    public static decimal Multiply(decimal a, decimal b, decimal c)
    {
        return a * b * c;
    }

}
/// Assignment 2.2.2 - simple maths class
///

// Write overloaded methods with logic and give choice to user to call different methods :

// a.Add(int num1, int num2)
// b.Add(decimal num1, decimal num2, decimal num3)
// c.Multiply(float num1, float num2)
// d.Multiply(float num1, float num2, float num3)

// Declare these methods as public and static.
