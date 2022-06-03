// Подключение классов стандартного модуля System.
using System;

// Объявление записи Student, которая содержит 2 элемента: строку с фамилией
// и инициалами студента, а тажке численный массив с успеваемостью.
public record Student(string SurnameAndInitials, uint[] AcademicPerformance)
{
    // Метод проверяет в порядке ли успеваемость студента, то есть
    // проверяет есть ли в массиве с оценками оценки
    // ниже 4-х, если есть, то метод возвращает false, если нет - true. 
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
        // Считывание строк из файла Inlet.in и сохранение их в массив lines.
        string[] lines = System.IO.File.ReadAllLines(@"Inlet.in");
        // Определение массива записей Student размером в два раза меньшим
        // чем количество строк, так как одна запись Student содержит фактически
        // две строки из lines.
        Student[] students = new Student[lines.Length / 2];
        // Цикл приводит строки из lines к необходимому виду и сохраняет их в
        // массив students.
        for (uint i = 0; i < students.Length; i++)
        {
            // Разбиение строки содержащей успеваемость на массив подстрок,
            // где каждая подстрока(слово) - это оценка. Разбиение строки
            // с успеваемостью производится по пробелам.
            string[] words = lines[i * 2 + 1].Split(" ");
            // Преобразование строкового массива, содержащего оцеки в
            // численный массив.
            uint[] numbers = new uint[words.Length];
            for (uint j = 0; j < numbers.Length; j++)
            {
                numbers[j] = uint.Parse(words[j]);
            }
            // Создание нового экземпляра записи Student с передачей ему
            // как параметров строки, содержащей Фамилию и инициалы студената,
            // а также численный массив, содержаций его оценки, c посдедующим
            // сохранением этого экземпляра в массив student, созданный ранее.
            students[i] = new(lines[i * 2], numbers);
        }

        // Сортировка записей из массива students в алфавитном порядке
        // по полю, которое содержит Фимилию и инициалы студента, и
        // cохранение их в новый массив записей Students под названием sorted. 
        var sorted = from student in students
             orderby student.SurnameAndInitials
             select student;

        // Связывание потока записи с файлом Outlet.out.
        using StreamWriter file = new("Outlet.out");
        // Последовательная запись фамилий и инициалов студентов из
        // отсортированного массива sorted в файл Outlet.out.
        foreach (Student student in sorted)
        {
            file.WriteLine(student.SurnameAndInitials);
        }
        // Подсчет количества студентов, у которых нет оценок меньше 4.
        uint count = 0;
        foreach (Student student in sorted)
        {
            if(student.IsOk()) { count++; }
        }
        // Запись полученного значения в файл Outlet.out.
        file.WriteLine(count);
    }
}