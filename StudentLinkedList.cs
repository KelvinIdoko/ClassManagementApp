using System;
// Represents the entire linked list and manages all the nodes.

// Sorted linked list storing students
public class StudentLinkedList
{
    private StudentNode head; // stores the first node in list (If head is null, the list is empty.)

    // Compares two students for sorting
    private int Compare(Student a, Student b)
    {
        int first = string.Compare(a.FirstName, b.FirstName, StringComparison.OrdinalIgnoreCase);

        // If the first names are the same, it compares last names.
        if (first == 0)
            return string.Compare(a.LastName, b.LastName, StringComparison.OrdinalIgnoreCase);

        return first;
    }

    // Checks if student already exists
    private bool Exists(string f, string l)
    {
        StudentNode current = head;

        while (current != null)
        {
            if (current.Data.FirstName.Equals(f, StringComparison.OrdinalIgnoreCase) &&
                current.Data.LastName.Equals(l, StringComparison.OrdinalIgnoreCase))
                return true;

            current = current.Next;
        }

        return false;
    }

    // Adds student in sorted order
    public void Add(Student s)
    {
        if (Exists(s.FirstName, s.LastName)) // Check for duplicates
        {
            Console.WriteLine("Student already exists");
            return;
        }

        // Creates a new node containing the student.
        StudentNode node = new StudentNode(s);

        if (head == null || Compare(s, head.Data) < 0)
        {
            node.Next = head; // list is empty
            head = node;      // new student should come before current first student
            return;
        }

        // Find insertion position
        StudentNode current = head;

        while (current.Next != null && Compare(current.Next.Data, s) < 0)
            current = current.Next;

        node.Next = current.Next; // Insert node
        current.Next = node;
    }

    // Finds a student
    public Student Find(string f, string l)
    {
        StudentNode current = head;

        while (current != null)
        {
            if (current.Data.FirstName.Equals(f, StringComparison.OrdinalIgnoreCase) &&
                current.Data.LastName.Equals(l, StringComparison.OrdinalIgnoreCase))
                return current.Data;

            current = current.Next;
        }

        return null;
    }

    public bool Remove(string f, string l)
    {
        if (head == null)
            return false;

        if (head.Data.FirstName.Equals(f, StringComparison.OrdinalIgnoreCase) &&
            head.Data.LastName.Equals(l, StringComparison.OrdinalIgnoreCase))
        {
            head = head.Next; // removes student is first node
            return true;
        }

        StudentNode current = head;

        while (current.Next != null)
        {
            if (current.Next.Data.FirstName.Equals(f, StringComparison.OrdinalIgnoreCase) &&
                current.Next.Data.LastName.Equals(l, StringComparison.OrdinalIgnoreCase))
            {
                current.Next = current.Next.Next; // Student is somewhere else
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    // Displays all students
    public void Display()
    {
        if (head == null)
        {
            Console.WriteLine("No students available.");
            return;
        }

        StudentNode current = head; // Start from the first node

        while (current != null)
        {
            current.Data.Display();
            current = current.Next; // Then move to next node
        }
    }
}