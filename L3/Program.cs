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
        set
        {
            a -= value;
            b -= value;
        }
    }
    protected float a;
    protected float b;
}

public class B : A
{
    private B(float a, float b, bool d) : base(a, b)
    {
        this.d = d;
    }
    public B(uint size) : this((float)size, 2.5f, true)
    {
        array = new float[size];
        for (uint i = 0; i < array.Length; i++)
        {
            array[i] = c2 * i;
        }
    }
    public void PrintArray()
    {
        Console.Write("Array: ");
        foreach (float element in array)
        {
           Console.Write("{0} ", element);
        }
        Console.WriteLine("");
    }
    
    public float c2
    {
        get {
            if (d) { return a + b; }
            else { return a - b; } 
        }
    }
    bool d;
    float[] array;
} 

class Program
{
    static void Main()
    {
        B b = new B(4);
        Console.WriteLine("b.c: {0}", b.c);
        Console.WriteLine("b.c2: {0}", b.c2);
        b.PrintArray();
    }
}