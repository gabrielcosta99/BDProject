using System;



public class WorkoutProgress
{
    private int _entry_num;
    private int _Athlete_num;
    private String _date;
    private int _num_workout;

    public int EntryNum
    {
        get { return _entry_num; }
        set { _entry_num = value; }
    }

    public int AthleteNum
    {
        get { return _Athlete_num; }
        set { _Athlete_num = value; }

    }

    public String Date
    {
        get { return _date; }
        set { _date = value; }
    }

    public int NumWorkout
    {
        get { return _num_workout; }
        set { _num_workout = value; }
    }

    public WorkoutProgress() : base()
    {

    }
    public WorkoutProgress(int entry_num, int athlete_num, String date, int num_workout) : base()
	{
        this._entry_num = entry_num;
        this._Athlete_num = athlete_num;
        this._date = date;
        this._num_workout = num_workout;
    }
}
