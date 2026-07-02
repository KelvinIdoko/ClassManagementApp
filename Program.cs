using System;
using System.Linq; // REQUIRED for char checks

class Program
{
    // Central student data structure (linked list)
    // This creates one shared list for the whole program.
    static StudentLinkedList list = new StudentLinkedList();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n========================================");
            Console.WriteLine("      CLASS MANAGEMENT SYSTEM");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Remove Student");
            Console.WriteLine("3. Display Students");
            Console.WriteLine("4. Manage Labs");
            Console.WriteLine("5. Manage Assignments");
            Console.WriteLine("0. Exit");
            Console.WriteLine("----------------------------------------");

            // MENU MUST BE INT, NOT STRING
            int choice = ReadInt("Enter your choice: ");
            Console.WriteLine();

            // Routes user request to appropriate system module
            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    RemoveStudent();
                    break;
                case 3:
                    list.Display();
                    break;
                case 4:
                    LabMenu();
                    break;
                case 5:
                    AssignmentMenu();
                    break;
                case 0:
                    Console.WriteLine("Exiting system...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Choose 0–5.");
                    break;
            }
        }
    }

    // ---------------- FIXED STRING INPUT ----------------
    // Validates and returns a safe string input (letters only)
    static string ReadString(string message)
    {
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine();

            // Ensures input is not empty or whitespace
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty.");
                continue;
            }

            // Ensures only alphabetic characters are entered
            if (!input.Replace(" ", "").All(char.IsLetter)) // removes spaces, checks every character is a letter
            {
                Console.WriteLine("Only letters are allowed.");
                continue;
            }

            return input.Trim(); // Removes extra spaces.
        }
    }

    // Validates and returns integer input (Safely convert string → integer)
    static int ReadInt(string message)
    {
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int value))
                return value;

            Console.WriteLine("Invalid number. Try again.");
        }
    }

    // Validates and returns decimal input
    static double ReadDouble(string message)
    {
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine();

            if (double.TryParse(input, out double value))
                return value;

            Console.WriteLine("Invalid decimal number. Try again.");
        }
    }

    // ---------------- STUDENT ----------------
    // Creates and stores a new student record
    static void AddStudent()
    {
        string first = ReadString("First Name: ");
        string last = ReadString("Last Name: ");
        list.Add(new Student(first, last)); // This calls StudentLinkedList.Add()
    }

    static void RemoveStudent()
    {
        string first = ReadString("First Name: ");
        string last = ReadString("Last Name: ");

        bool removed = list.Remove(first, last); // search linked list
                                                 // remove node if found

        if (removed)
            Console.WriteLine("Student removed successfully.");
        else
            Console.WriteLine("Student not found.");
    }

    static Student GetStudent()
    {
        string first = ReadString("First Name: ");
        string last = ReadString("Last Name: ");

        Student s = list.Find(first, last); // Retrieve actual Student object.

        if (s == null)
        {
            Console.WriteLine("Student not found.");
            return null;
        }

        return s;
    }

    static void LabMenu()
    {
        Student s = GetStudent();
        if (s == null) return;

        Console.WriteLine("\n1. Add Lab");
        Console.WriteLine("2. Remove Lab");
        Console.WriteLine("3. Update Lab");
        Console.WriteLine("4. Display Labs");
        Console.WriteLine();

        int choice = ReadInt("Select option: ");
        Console.WriteLine();

    if (choice == 1)
    {
            int labNo = ReadInt("Lab Number: ");

            foreach (var l in s.Labs)
            {
                if (l.LabNumber == labNo)
                {
                    Console.WriteLine("Error: Lab number already exists for this student.");
                    return;
                }
            }

            double score = ReadDouble("Score (out of 10): ");

            if (score > 10)
            {
                Console.WriteLine("Error: Score cannot be greater than 10.");
                return;
            }

            double max = 10;

            s.Labs.Enqueue(new Lab(labNo, score, max)); // Add to queue

            Console.WriteLine("Lab added successfully.");
        }
        else if (choice == 2)
        {
            // Check if student has any labs
            if (s.Labs.Count == 0)
            {
                Console.WriteLine("No labs available to remove.");
                return;
            }

            int labNo = ReadInt("Lab Number: ");

            // Queues do NOT allow direct removal.
            // Create an empty queue that will store everything except the deleted lab.
            Queue<Lab> temp = new Queue<Lab>();                                
            bool found = false;

            while (s.Labs.Count > 0)
            {
                Lab l = s.Labs.Dequeue(); // Remove the front lab

                if (l.LabNumber == labNo) // Check if this is the lab to delete
                {
                    found = true; // Skip target lab
                    continue;
                }

                temp.Enqueue(l); // Keep the lab and add it back into the new queue.
            }

            s.Labs = temp; // Replace original queue

            if (found)
                Console.WriteLine("Lab removed successfully.");
            else
                Console.WriteLine("Lab not found.");
        }
        else if (choice == 3)
        {
            int labNo = ReadInt("Lab Number: ");
            double score = ReadDouble("Score (out of 10): ");

            // enforce max rule again
            if (score > 10)
            {
                Console.WriteLine("Error: Score cannot be greater than 10.");
                return;
            }

            double max = 10; // MAX SCORE

            Queue<Lab> temp = new Queue<Lab>();

            while (s.Labs.Count > 0)
            {
                Lab l = s.Labs.Dequeue(); // Remove Front Item

                if (l.LabNumber == labNo) // Check if this is the lab to update
                    temp.Enqueue(new Lab(labNo, score, max)); // If it IS the target lab (UPDATE)
                else
                    temp.Enqueue(l); // Just move it unchanged into the new queue.
            }

            s.Labs = temp; // Replace old queue with updated one
            Console.WriteLine("Lab update completed.");
        }
        else if (choice == 4)
        {
            if (s.Labs.Count == 0)
            {
                Console.WriteLine("No labs found for this student.");
                return;
            }

            if (s.Labs == null || s.Labs.Count == 0)
            {
                Console.WriteLine("No labs available for this student.");
                return;
            }

            foreach (var l in s.Labs)
                Console.WriteLine(l);
        }
    }

    static void AssignmentMenu()
    {
        Student s = GetStudent();
        if (s == null) return;

        Console.WriteLine("\n1. Add Assignment");
        Console.WriteLine("2. Remove Assignment");
        Console.WriteLine("3. Update Assignment");
        Console.WriteLine("4. Display Assignments");
        Console.WriteLine();

        int choice = ReadInt("Select option: ");
        Console.WriteLine();

        if (choice == 1)
        {
            int num = ReadInt("Assignment #: ");

            // CHECK FOR DUPLICATE
            foreach (var a in s.Assignments)
            {
                if (a.AssignmentNumber == num)
                {
                    Console.WriteLine("Error: Assignment number already exists for this student.");
                    return;
                }
            }

            double score = ReadDouble("Score: ");
            double max = ReadDouble("Maximum Score: ");

            if (score > max)
            {
                Console.WriteLine("Error: Score cannot be greater than maximum score.");
                return;
            }

            s.Assignments.Push(new Assignment(num, score, max)); // Add assignment to stack

            Console.WriteLine("Assignment added successfully.");
        }
        else if (choice == 2)
        {
            // Check if student has any assignments
            if (s.Assignments.Count == 0)
            {
                Console.WriteLine("No assignments available to remove.");
                return;
            }

            int num = ReadInt("Assignment #: ");

            Stack<Assignment> temp = new Stack<Assignment>(); // Create temporary stack
            bool found = false; // Track if item is found

            while (s.Assignments.Count > 0)
            {
                var a = s.Assignments.Pop();

                if (a.AssignmentNumber == num)
                {
                    found = true;
                    continue;
                }

                temp.Push(a); // If it is not, Put it into the new stack.
            }

            s.Assignments = temp; // Replace old stack

            if (found)
                Console.WriteLine("Assignment removed successfully.");
            else
                Console.WriteLine("Assignment not found.");
        }
        else if (choice == 3)
        {
            if (s.Assignments.Count == 0)
            {
                Console.WriteLine("No assignments available to update.");
                return;
            }

            int num = ReadInt("Assignment #: ");
            double score = ReadDouble("Score: ");
            double max = ReadDouble("Maximum Score: ");

            if (score > max)
            {
                Console.WriteLine("Error: Score cannot be greater than maximum score.");
                return;
            }

            Stack<Assignment> temp = new Stack<Assignment>();
            bool found = false;

            while (s.Assignments.Count > 0)
            {
                var a = s.Assignments.Pop();

                if (a.AssignmentNumber == num)
                {
                    temp.Push(new Assignment(num, score, max));
                    found = true;
                }
                else
                {
                    temp.Push(a);
                }
            }

            s.Assignments = temp;

            if (found)
                Console.WriteLine("Assignment updated successfully.");
            else
                Console.WriteLine("Assignment not found.");
        }
        else if (choice == 4)
        {
            if (s.Assignments.Count == 0)
            {
                Console.WriteLine("No assignments available for this student.");
                return;
            }

            Console.WriteLine("\n--- ASSIGNMENT LIST ---");

            foreach (var a in s.Assignments)
                Console.WriteLine(a);
        }
    }
}