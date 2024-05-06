using System;

public class Workout
{
    private int _num_workout;
    private string _title;
    private string _tags;
    private int _premium;
    private int _pt_num;

    public int NumWorkout
    {
        get {  return _num_workout; }
        set { _num_workout = value; }
    }

    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }

    public string Tags
    {
        get { return _tags; }
        set { _tags = value; }
    }

    public int Premium
    {
        get { return _premium; }
        set { _premium = value; }
    }

    public int PTNum
    {
        get { return _pt_num; }
        set { _pt_num = value; }
    }

    public Workout() : base()
    {
    }

    public Workout(int num_workout, string title, string tags, int premium, int pt_num) : base()
    {
        _num_workout = num_workout;
        _title = title;
        _tags = tags;
        _premium = premium;
        _pt_num = pt_num;
    }
}
