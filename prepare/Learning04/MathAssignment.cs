public class MathAssignment: Assignment 
{
    private string _textbookSect;
    private string _problems;

    public MathAssignment(string studentName, string topics, string textbookSect, string problems) :base (studentName, topics)
    {
        _textbookSect = textbookSect;
        _problems = problems;
    }
    public string GetHomewrkLists()
    {
        return $"Section{_textbookSect} Problems{_problems}";
    }
}