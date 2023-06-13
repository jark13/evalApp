using evalApp;
using System.Xml.Linq;
using System;


Console.WriteLine("Welcome to evalApp application for a student evaluation.");

Console.WriteLine("The application allows to enter the grades obtained, calculates the average and predicts the final grade in the subject.");
Console.WriteLine("========================================================================================================================");
Console.WriteLine();

Console.Write("Please enter the First name: ");
string name = Console.ReadLine();

Console.Write("Please enter the Surname: ");
string surname = Console.ReadLine();

Console.Write("Please enter the Sex: ");
string sex = Console.ReadLine();
Console.WriteLine();

var student = new StudentInFile(name, surname, sex);


void StudentGradeAdded(object sender, EventArgs args)
{
    Console.WriteLine("Dodano nową ocenę");
}

while (true)
{
    Console.Write($"Enter the student's next grade (if quit, press 'q/Q') :");
    var input = Console.ReadLine();
    Console.WriteLine();
    if (input == "q" || input == "Q")
    {
        break;
    }
    try
    {
        student.AddGrade(input);
    }
    catch (Exception e)
    {
        Console.WriteLine($"Exception catched: {e.Message}");
    }
}
var statistics = student.GetStatistics();
Console.WriteLine($"Average: {statistics.Average:N3}");
Console.WriteLine($"Min: {statistics.Min}");
Console.WriteLine($"Max: {statistics.Max}");


//Console.WriteLine();
//Console.Write($"Enter the number of student you want to asess (1 - {numberOfStudents}): ");
//string studentID = Console.ReadLine();
//Console.WriteLine();


//string currentDirectory = Directory.GetCurrentDirectory();
//string filePath = Path.Combine(currentDirectory, $"Student{studentID}.txt");//"data.txt");

//string[] lines = File.ReadAllLines(filePath);

//string nameOfStudent = lines[0];
//string surnameOfStudent = lines[1];
//string sexOfStudent = lines[2];
//string fileNameOfStudentRecord = lines[3];


//var student = new StudentInMemory(nameOfStudent, surnameOfStudent, sexOfStudent);
//var student = new StudentInFile(nameOfStudent, surnameOfStudent, sexOfStudent);




//void StudentGradeAdded(object sender, EventArgs args)
//{
//    Console.WriteLine("Dodano nową ocenę");
//}

//while (true)
//{
//    Console.Write($"Enter the student's {studentID} next grade (if quit, press 'q/Q') :");
//    var input = Console.ReadLine();
//    Console.WriteLine();
//    if (input == "q" || input == "Q")
//    {
//        break;
//    }
//    try
//    {
//        student.AddGrade(input);
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine($"Exception catched: {e.Message}");
//    }
//}

//var statistics = student.GetStatistics();
//Console.WriteLine($"Average: {statistics.Average:N3}");
//Console.WriteLine($"Min: {statistics.Min}");
//Console.WriteLine($"Max: {statistics.Max}");