using System;

public class TimeProgress : IProgress
{
	private int _entry_num;
    private int _entry_workout;
    private int _num_ex;
    private int _set_num;
    private int _time;

    public int EntryNum {
        get { return _entry_num; }
        set { _entry_num = value; }
    }

    public int EntryWorkout {
        get { return _entry_workout; }
        set { _entry_workout = value; }
    }

    public int NumEx {
        get { return _num_ex; }
        set { _num_ex = value; }
    }

    public int SetNum
    {
        get { return _set_num; }
        set { _set_num = value; }
    }

    public int Time {
        get { return _time;}
        set { _time = value; }
    }




	/*
    public override String ToString()
    {
        return "exercise: " + _num_ex + " set_num: " +_set_num;
    }
	*/
	public override String ToString()
    {
        return "entry_num:"+_entry_num+" entry_workout:"+_entry_workout+" exercise: " + _num_ex + " set_num: " +_set_num+ " time: " + _time;
    }

    public TimeProgress() : base()
	{
	}

	public TimeProgress(int entry_num,int _entry_workout, int num_ex, int set_num, int time) : base()
	{
		this._entry_num = entry_num;
		this._entry_workout = _entry_workout;
		this._num_ex = num_ex;
		this._set_num = set_num;
		this._time = time;
	}
}
