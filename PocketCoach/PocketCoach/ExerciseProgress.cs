using System;



public class ExerciseProgress
{
    private int _entry_num;
    private int _Athlete_num;
    private String _date;

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

    public ExerciseProgress() : base()
    {

    }
    public ExerciseProgress(int entry_num, int athlete_num, String date) : base()
	{
        this._entry_num = entry_num;
        this._Athlete_num = athlete_num;
        this._date = date;

    }
}
