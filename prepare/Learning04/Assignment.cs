public class Assignment 
{
    private string _studentName;
    private string _topics;

    public Assignment (string studentName, string topics)
    {
        _studentName = studentName;
        _topics = topics;
    }

    public string GetStudentName()
    {
        return _studentName;
    }

    public string GetTopics()
    {
        return _topics;
    }

    public string GetSummary()
    {
        return _studentName + " - " + _topics;
    }
}