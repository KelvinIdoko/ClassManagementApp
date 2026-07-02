// Represents one node in the linked list.
public class StudentNode
{
    // Stores student data
    public Student Data; // Data is a variable

    // Stores a reference to another StudentNode.
    public StudentNode Next;

    // Constructor assigns student to node
    public StudentNode(Student data)
    {
        Data = data;   // This stores the student passed into the constructor inside the node
        Next = null;   // next node is empty initially
    }
}