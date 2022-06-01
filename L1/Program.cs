using System;

public class A {
    public float c 
    {
        get { return a / b; }
        set
        {
            a -= value;
            b -= value;
        }
    }
    float a = 3;
    float b = 1;
}

class Program
{
    static void Main()
    {
        A a = new A();
        Console.WriteLine("a.c: {0}", a.c);
        a.c = 5;
        Console.WriteLine("a.c: {0}", a.c);
    }
}