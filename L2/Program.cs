using System;

public class A
{
    public A()
    {
        a = 0;
        b = 0;
    }
    public A(float a, float b)
    {
        this.a = a;
        this.b = b;
    }
    public float c 
    {
        get { return a / b; }
        set {
            a -= value;
            b -= value;
        }
    }
    protected float a;
    protected float b;
}

public class B : A
{
    public B(float a, float b, bool d) : base(a, b)
    {
        this.d = d;
    }
    public B(bool d)
    {
        a = 1;
        b = 2; 
        this.d = d;
    }
    public float c2
    {
        get
        {
            if (d) { return a + b; }
            else { return a - b; } 
        }
    }
    bool d = true;
} 

class Program
{
    static void Main()
    {
        A a = new A(4, 2);
        Console.WriteLine("a.c: {0}", a.c);
        B b1 = new B(false);
        Console.WriteLine("b1.c: {0}", b1.c);
        Console.WriteLine("b1.c2: {0}", b1.c2);
        B b2 = new B(4, 2, true);
        Console.WriteLine("b2.c: {0}", b2.c);
        Console.WriteLine("b2.c2: {0}", b2.c2);
    }
}