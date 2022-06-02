using System;

public record Student(string SurnameAndInitials, uint[] AcademicPerformance)
{
    public string AsString()
    {
        string numbers = "";
        foreach (uint element in AcademicPerformance)
        {
            numbers += " " + element.ToString();
        }
        return SurnameAndInitials + numbers;
    }
    public bool IsOk()
    {
        foreach (uint element in AcademicPerformance)
        {
            if (element < 4) { return false; }
        }
        return true;
    }
}

class Program
{
    static void Main()
    {
        string[] lines = System.IO.File.ReadAllLines(@"Inlet.in");
        
        Student[] students = new Student[lines.Length / 2];
        
        for (uint i = 0; i < students.Length; i++)
        {
            string[] words = lines[i * 2 + 1].Split(" ");
            uint[] numbers = new uint[words.Length];
            for (uint j = 0; j < numbers.Length; j++)
            {
                numbers[j] = uint.Parse(words[j]);
            }
            students[i] = new(lines[i * 2], numbers);
        }

        var sorted = from student in students
             orderby student.SurnameAndInitials
             select student;

        using StreamWriter file = new("Outlet.out");
        foreach (Student student in sorted)
        {
            file.WriteLine(student.AsString());
        }
        uint count = 0;
        foreach (Student student in sorted)
        {
            if(student.IsOk()) { count++; }
        }
        file.WriteLine(count);
    }
}