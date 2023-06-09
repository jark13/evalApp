﻿using evalApp;
using System;

Console.WriteLine("Welcome to evalApp application for a student evaluation.");

Console.WriteLine("The application allows to enter the grades obtained, calculates the average and predicts the final grade in the subject.");
Console.WriteLine("========================================================================================================================");
Console.WriteLine();

Console.Write("Please enter the First name: ");
string name = Console.ReadLine();

Console.Write("Please enter the Surname: ");
string surname = Console.ReadLine();

Console.Write("Please enter the Sex (Fimale/fimale or Male/male): ");
string sex = Console.ReadLine().ToLower(); ;
while (true)
{
    if (sex == "male" || sex == "female")
    {
        break;
    }
    else
    {
        Console.WriteLine("Invalid sex. Please try again.");
    }
    Console.Write("Please enter your sex (male/female): ");
    sex = Console.ReadLine().ToLower();
}


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
