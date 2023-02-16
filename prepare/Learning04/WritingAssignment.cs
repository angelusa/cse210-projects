public class WritingAssignment: Assignment 
{
    private string _title;

    public WritingAssignment(string studentName, string topics, string title):base(studentName, topics)
    {
        _title = title;
    }
    public string GetWritingInfo()
    {
        string studentName = GetStudentName();

        return $"{_title} by {studentName}";
    }
}