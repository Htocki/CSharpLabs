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
    public B(float a, float b, bool d) : base(a, b)
    {
        this.d = d;
        array = new float[(uint)Math.Abs(a)];
        for (uint i = 0; i < array.Length; i++)
        {
            array[i] = c2 * i;
        }
    }
    public float this[uint index] {
        get { return array[index]; }
        set { array[index] = value; }
    }
    public int this[int index] {
        get { return array2[index]; }
        set { array2[index] = value; }
    } 
    public float c2
    {
        get {
            if (d) { return a + b; }
            else { return a - b; } 
        }
    }
    public uint Length() {
        return (uint)array.Length;
    }
    public int Length2() {
        return array2.Length;
    }
    public static bool operator true(B b)
    {
        return b.d == true;
    }
    public static bool operator false(B b)
    {
        return b.d == false;
    }
    public static bool operator &(B x, B y)
    {
         return x.d & y.d;
    }
    bool d;
    float[] array;
    int[] array2 = new int[5] {1, 2, 3, 4, 5};
}

class Program
{
    static void Main()
    {
        B b1 = new B(-4.2f, 2.5f, false);
        B b2 = new B(1.2f, 4.5f, true);
        if (b2) { Console.WriteLine("true"); }
        else { Console.WriteLine("false"); }
        if (b1 & b2) { Console.WriteLine("true"); }
        else { Console.WriteLine("false"); }
    }
}