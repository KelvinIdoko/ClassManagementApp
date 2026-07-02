using System;
using System.Collections.Generic;

// Represents a student and their academic data
public class Student
{
    // First name of student
    public string FirstName { get; set; }

    // Last name of student
    public string LastName { get; set; }

    // Queue stores labs (FIFO order)
    public Queue<Lab> Labs { get; set; }

    // Stack stores assignments (LIFO order)
    public Stack<Assignment> Assignments { get; set; }

    // Constructor initializes student and collections
    public Student(string firstName, string lastName)
    {
        FirstName = firstName;     // set first name
        LastName = lastName;       // set last name

        Labs = new Queue<Lab>();   // initialize lab queue
        Assignments = new Stack<Assignment>(); // initialize assignment stack
    }

    // Calculates total lab percentage
    public double GetLabPercentage()
    {
        double totalScore = 0; // sum of lab scores
        double totalMax = 0;   // sum of max scores

        // iterate through all labs
        foreach (var lab in Labs)
        {
            totalScore += lab.Score;     // add score
            totalMax += lab.MaxScore;    // add max score
        }

        // prevent division by zero (ternary operator.)
        return totalMax == 0 ? 0 : (totalScore / totalMax) * 100;
    }

    // Calculates total assignment percentage
    public double GetAssignmentPercentage()
    {
        double totalScore = 0; // sum of assignment scores
        double totalMax = 0;   // sum of max scores

        // iterate through all assignments
        foreach (var a in Assignments)
        {
            totalScore += a.Score;     // add score
            totalMax += a.MaxScore;    // add max score
        }

        // safe percentage calculation
        return totalMax == 0 ? 0 : (totalScore / totalMax) * 100;
    }

    // Displays student summary
    public void Display()
    {
        Console.WriteLine($"\nStudent: {FirstName} {LastName}"); // student name
        Console.WriteLine($"Lab %: {GetLabPercentage():F2}");    // lab percentage
        Console.WriteLine($"Assignment %: {GetAssignmentPercentage():F2}"); // assignment %
    }
}