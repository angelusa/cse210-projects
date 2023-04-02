
using System;

public class Activity
{
    private DateTime _date;
    protected int _lengthInMinutes;

    public Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public string GetSummary()
    {
        return $"{_date.ToShortDateString()} {this.GetType().Name} ({_lengthInMinutes} min): Distance {GetDistance()}, Speed {GetSpeed()}, Pace {GetPace()}";
    }
}

public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int lengthInMinutes, double distance) : base(date, lengthInMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return _distance * 60 / _lengthInMinutes;
    }

    public override double GetPace()
    {
        return _lengthInMinutes / _distance;
    }
}

public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int lengthInMinutes, double speed) : base(date, lengthInMinutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return _speed * _lengthInMinutes / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int lengthInMinutes, int laps) : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50 / 1000;
    }

    public override double GetSpeed()
    {
        return _laps * 50 / 1000 * 60 / _lengthInMinutes;
    }

    public override double GetPace()
    {
        return _lengthInMinutes / _laps * 50 / 1000;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Activity[] activities = {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 3), 30, 10.0),
            new Swimming(new DateTime(2022, 11, 3), 30, 12)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
