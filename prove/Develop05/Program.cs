using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;
    private bool _isCompleted;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isCompleted = false;
    }

    public string GetName()
    {
        return this._name;
    }

    public string GetDescription()
    {
        return this._description;
    }

    public int GetPoints()
    {
        return this._points;
    }
    public bool GetDone()
    {
        return this._isCompleted;
    }

    public void setDone()
    {
        this._isCompleted = true;
    }

    public virtual string getDone()
    {
        if (_isCompleted)
            return "[X]";
        else
            return "[ ]";
    }
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) :
        base(name, description, points)
    {

    }

}

public class EternalGoal : Goal
{
    private int _times;
    private int _bonus;

    public EternalGoal(string name, string description, int points, int times, int bonus) :
        base(name, description, points)
    {
        this._times = times;
        this._bonus = bonus;
    }

    public int GetTimes()
    {
        return this._times;
    }

    public int GetBonus()
    {
        return this._bonus;
    }

}

public class ChecklistGoal : Goal
{
    private bool[] _checklist;

    public ChecklistGoal(string name, string description, int points, int size) :
        base(name, description, points)
    {
        _checklist = new bool[size];
    }

    public bool[] GetChecklist()
    {
        return _checklist;
    }

    public void setChecklist(int x)
    {
        _checklist[x] = true;
    }

    public int getTotalDone()
    {
        int x = 0;
        for (int i = 0; i < GetChecklist().Length; i++)
        {
            if (GetChecklist()[i])
                x++;
        }
        return x;
    }

    public void setOneDone()
    {
        for (int i = 0; i < GetChecklist().Length; i++)
        {
            if (GetChecklist()[i] == false)
            {
                setChecklist(i);
                break;
            }
        }
    }

    public override string getDone()
    {
        if (getTotalDone() == GetChecklist().Length)
            return "[X]";
        else
            return "[ ]";
    }
}

public class Program
{
    public static void Main()
    {
        int totalGoalPoints = 0;
        int selection = 0;
        SimpleGoal sg = null;
        EternalGoal eg = null;
        ChecklistGoal cg = null;

        do
        {
            Console.WriteLine("\nYou have " + totalGoalPoints + " Points...!!\n\n");
            Console.WriteLine("1) Create a New Goal");
            Console.WriteLine("2) List Goals");
            Console.WriteLine("3) Save Goals");
            Console.WriteLine("4) Load Goals");
            Console.WriteLine("5) Record Goals");
            Console.WriteLine("6) Quit");
            Console.Write("Select an option: ");
            selection = Convert.ToInt32(Console.ReadLine());

            switch (selection)
            {
                case 1:
                    Console.WriteLine("1) Simple Goal");
                    Console.WriteLine("2) Eternal Goal");
                    Console.WriteLine("3) Checklist Goal");
                    Console.Write("Select an option: ");
                    selection = Convert.ToInt32(Console.ReadLine());

                    switch (selection)
                    {
                        case 1:
                            Console.Write("What is the name of your Goal? ");
                            string name = Console.ReadLine();
                            Console.Write("What is the short description of your Goal? ");
                            string description = Console.ReadLine();
                            Console.Write("What is the amount of points associated with this goal? ");
                            int points = Convert.ToInt32(Console.ReadLine());
                            sg = new SimpleGoal(name, description, points);
                            break;
                        case 2:
                            Console.Write("What is the name of your Goal? ");
                            name = Console.ReadLine();
                            Console.Write("What is the short description of your Goal? ");
                            description = Console.ReadLine();
                            Console.Write("What is the amount of points associated with this goal? ");
                            points = Convert.ToInt32(Console.ReadLine());
                            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                            int times = Convert.ToInt32(Console.ReadLine());
                            Console.Write("What is the bonus for accomplishing it that many times? ");
                            int bonus = Convert.ToInt32(Console.ReadLine());
                            eg = new EternalGoal(name, description, points, times, bonus);
                            break;
                        case 3:
                            Console.Write("What is the name of your Goal? ");
                            name = Console.ReadLine();
                            Console.Write("What is the short description of your Goal? ");
                            description = Console.ReadLine();
                            Console.Write("What is the amount of points associated with this goal? ");
                            points = Convert.ToInt32(Console.ReadLine());
                            Console.Write("How many items are in the checklist? ");
                            int size = Convert.ToInt32(Console.ReadLine());
                            cg = new ChecklistGoal(name, description, points, size);
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("The Goals are: ");
                    if (sg != null)
                    {
                        Console.WriteLine("1) " + sg.getDone() + " Simple Goal: " + sg.GetName() + "(" + sg.GetDescription() + ")");
                    }
                    if (eg != null)
                    {
                        Console.WriteLine("2) [ ] Eternal Goal: " + eg.GetName() + "(" + eg.GetDescription() + ")");
                    }
                    if (cg != null)
                    {
                        Console.WriteLine("3) " + cg.getDone() + " Checklist Goal: " + cg.GetName() + "(" + cg.GetDescription() + ") -- Currently Completed: " + cg.getTotalDone() + "/" + cg.GetChecklist().Count());
                    }
                    break;
                case 3:
                    List<string> lines = new List<string>();
                    Console.WriteLine("Enter the Name of the File: ");
                    string fileName = Console.ReadLine();
                    lines.Add(Convert.ToString(totalGoalPoints));
                    if (sg != null)
                    {
                        lines.Add("Simple Goal:" + sg.GetName() + "," + sg.GetDescription() + "," + sg.GetPoints() + "," + sg.GetDone());
                    }
                    if (eg != null)
                    {
                        lines.Add("Eternal Goal:" + eg.GetName() + "," + eg.GetDescription() + "," + eg.GetPoints());
                    }
                    if (cg != null)
                    {
                        lines.Add("Checklist Goal:" + cg.GetName() + "," + cg.GetDescription() + ",50," + cg.GetPoints() + "," + cg.GetChecklist().Count() + "," + cg.getTotalDone());
                    }
                    string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, fileName)))
                    {
                        foreach (string line in lines)
                            outputFile.WriteLine(line);
                    }
                    break;
                case 4:
                    Console.WriteLine("Enter the Name of the File: ");
                    string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    try
                    {
                        string filesName = Console.ReadLine();
                        string actPath = Path.Combine(docsPath, filesName);
                        foreach (string line in System.IO.File.ReadLines(actPath))
                        {
                            if (line.StartsWith("Simple"))
                            {
                                string[] names = line.Split(':');
                                string[] desc = names[1].Split(',');
                                sg = new SimpleGoal(desc[0], desc[1], Convert.ToInt16(desc[2]));
                                if (desc[3] == "True")
                                    sg.setDone();
                            }
                            else if (line.StartsWith("Eternal"))
                            {
                                string[] names = line.Split(':');
                                string[] desc = names[1].Split(',');
                                eg = new EternalGoal(desc[0], desc[1], Convert.ToInt16(desc[2]), 0, 0);
                            }
                            else if (line.StartsWith("Checklist"))
                            {
                                string[] names = line.Split(':');
                                string[] desc = names[1].Split(',');
                                cg = new ChecklistGoal(desc[0], desc[1], Convert.ToInt16(desc[3]), Convert.ToInt16(desc[4]));
                                for (int i = 0; i < Convert.ToInt16(desc[5]); i++)
                                {
                                    cg.setOneDone();
                                }
                            }
                            else
                            {
                                totalGoalPoints = Convert.ToUInt16(line);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    break;
                case 5:
                    if (sg != null)
                    {
                        Console.WriteLine("1. " + sg.GetName());
                    }
                    if (eg != null)
                    {
                        Console.WriteLine("2. " + eg.GetName());
                    }
                    if (cg != null)
                    {
                        Console.WriteLine("3. " + cg.GetName());
                    }

                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            sg.setDone();
                            Console.WriteLine("\nCongratulations: You earned " + sg.GetPoints() + " Points");
                            totalGoalPoints += sg.GetPoints();
                            break;
                        case "2":
                            eg.setDone();
                            Console.WriteLine("\nCongratulations: You earned " + eg.GetPoints() + " Points");
                            totalGoalPoints += eg.GetPoints();
                            break;
                        case "3":
                            cg.setDone();
                            if (cg.GetChecklist().Count() == cg.getTotalDone() - 1)
                                Console.WriteLine("\nCongratulations: You earned " + cg.GetPoints() + " Points");
                            else
                                Console.WriteLine("\nCongratulations: You earned 50 Points");
                            if (cg.GetChecklist().Count() == cg.getTotalDone() - 1)
                                totalGoalPoints += cg.GetPoints();
                            else
                            {
                                cg.setOneDone();
                                totalGoalPoints += 50;
                            }
                            break;
                        default:
                            break;
                    }

                    break;
                case 6:
                    Console.WriteLine("Goodbye!");
                    break;
            }
        } while (selection != 6);
    }
}

