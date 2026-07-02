// Represents a single assignment for a student record
public class Assignment
{
    // Assignment identifier number
    public int AssignmentNumber { get; set; }

    // Score obtained
    public double Score { get; set; }

    // Maximum score possible
    public double MaxScore { get; set; }

    // Constructor initializes assignment values
    public Assignment(int assignmentNumber, double score, double maxScore)
    {
        AssignmentNumber = assignmentNumber; // store assignment id
        Score = score;                       // store score
        MaxScore = maxScore;                // store max score
    }

    // String representation of assignment
    public override string ToString()
    {
        return $"Assignment {AssignmentNumber}: {Score}/{MaxScore}";
    }
}