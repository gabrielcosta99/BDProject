using System;

public class Workout
{
    private int _num_workout;
    private string _title;
    private string _tags;

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

    public Workout() : base()
    {
    }

    public Workout(int num_workout, string title, string tags) : base()
    {
        _num_workout = num_workout;
        _title = title;
        _tags = tags;
    }
}
