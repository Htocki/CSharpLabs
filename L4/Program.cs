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
    bool d;
    float[] array;
    int[] array2 = new int[5] {1, 2, 3, 4, 5};
}

public class C<T> {
    static int s = 0;
    T[] array = new T[5];
}

class Program
{
    static void Main()
    {
        B b = new B(-4.2f, 2.5f, true);
        Console.WriteLine("b.c: {0}", b.c);
        Console.WriteLine("b.c2: {0}", b.c2);
        
        Console.Write("Array: ");
        for (uint i = 0; i < b.Length(); i++)
        {
           Console.Write("{0} ", b[i]);
        }
        Console.WriteLine("");

        Console.Write("Array2: ");
        for (int i = 0; i < b.Length2(); i++)
        {
           Console.Write("{0} ", b[i]);
        }
        Console.WriteLine("");

        C<string> c1 = new C<string>();
        C<int> c2 = new C<int>();
    }
}