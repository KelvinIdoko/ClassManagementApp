// Represents a single Lab for a student
public class Lab
{
    // Lab identifier number
    public int LabNumber { get; set; }

    // Score obtained in the lab
    public double Score { get; set; }

    // Maximum possible score
    public double MaxScore { get; set; }

    // Constructor to initialize lab values
    public Lab(int labNumber, double score, double maxScore)
    {
        LabNumber = labNumber; // assign lab number
        Score = score;         // assign score
        MaxScore = maxScore;   // assign max score
    }

    // Converts lab object to readable string format
    public override string ToString()
    {
        return $"Lab {LabNumber}: {Score}/{MaxScore}";
    }
}