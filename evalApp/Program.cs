using evalApp;
using System.Xml.Linq;
using System;


Console.WriteLine("Welcome to evalApp application for a students evaluation.");
//Console.WriteLine("student: Marek Kowalski");

Console.WriteLine("The application aims to create a new group of students, add their grades assess their achievements based on grades.");
Console.WriteLine("================================================================================");
Console.WriteLine();
//Console.WriteLine("Would you like to add new grade (press 'n'/'N') or just print stastistics from the student's index (press 's'/'S')?");

Console.Write("Please enter the number of students in the group: ");
int numberOfStudents = int.Parse(Console.ReadLine());
Console.WriteLine();
//List<StudentInFile> students  = new List<StudentInFile>();
List<string> students = new List<string>();
List<string> fileNames = new List<string>();

for (int i = 1; i <= numberOfStudents; i++)
{
    var studentInList = $"Student{i}";
    students.Add(studentInList);

    Console.WriteLine($"\nStudent {i}:");
    Console.WriteLine("Please enter the First name:");
    string name = Console.ReadLine();

    Console.WriteLine("Please enter the Surname:");
    string surname = Console.ReadLine();

    Console.WriteLine("Please enter the Sex:");
    string sex = Console.ReadLine();

    //var student = new StudentInFile(name, surname, sex);

    string fileName = studentInList + ".txt"; // $"{name}{surname}{sex}.txt";
    fileNames.Add(fileName);
    //var student = new StudentInFile(name, surname, sex);

    try
    {
        // Create a new text file for a student including the provided name, surname, and sex
        using (StreamWriter writer = File.CreateText(fileName))
        {
            writer.WriteLine(name);
            writer.WriteLine(surname);
            writer.WriteLine(sex);
            writer.WriteLine(fileName);

        }

        Console.WriteLine($"Text file created successfully for Student {i}.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while creating the text file for Student {i}: " + ex.Message);
    }
}


Console.WriteLine();
Console.Write($"Enter the number of student you want to asess (1 - {numberOfStudents}): ");
string studentID = Console.ReadLine();
Console.WriteLine();


string currentDirectory = Directory.GetCurrentDirectory();
string filePath = Path.Combine(currentDirectory, $"Student{studentID}.txt");//"data.txt");

string[] lines = File.ReadAllLines(filePath);

string nameOfStudent = lines[0];
string surnameOfStudent = lines[1];
string sexOfStudent = lines[2];
string fileNameOfStudentRecord = lines[3];


//var student = new StudentInMemory("Jan", "Kowalski", "Male");
//var student = new StudentInMemory(nameOfStudent, surnameOfStudent, sexOfStudent);
var student = new StudentInFile(nameOfStudent, surnameOfStudent, sexOfStudent);

//student.AddGrade(53.0f);
//student.AddGrade('B');
//student.AddGrade(9);
//student.AddGrade('a');




void StudentGradeAdded(object sender, EventArgs args)
{
    Console.WriteLine("Dodano nową ocenę");
}

//var student1 = new StudentInMemory("Mark", "Kowalski", "Male");
//var student = new StudentInFile("Mark", "Kowalski", "Male");

while (true)
{
    Console.Write($"Enter the student's {studentID} next grade (if quit, press 'q/Q') :");
    var input = Console.ReadLine();
    Console.WriteLine();
    if (input == "q" || input == "Q")
    {
        break;
    }
    try
    {
        //student.AddGrade(input);
        student.AddGrade(input);
        //student1.AddGrade('a');
    }
    catch (Exception e)
    {
        Console.WriteLine($"Exception catched: {e.Message}");
    }
}

var student1 = new StudentInFile(nameOfStudent, surnameOfStudent, sexOfStudent);
//foreach (var grade in grades)
//    {
//        var i = 0;
//    }

var statistics = student.GetStatistics();
Console.WriteLine($"Average: {statistics.Average:N3}");
Console.WriteLine($"Min: {statistics.Min}");
Console.WriteLine($"Max: {statistics.Max}");