using System;

public class RepsProgress
{
	private int _entry_num;
	private int _num_ex;
	private int _set_num;
	private int _reps_made;
	private int _weight_used;


	public int EntryNum {
		get { return _entry_num; }
		set { _entry_num = value; }
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

	public int RepsMade {
		get { return _reps_made;}
		set { _reps_made = value; }
	}

	public int WeightUsed
	{
		get { return _weight_used;}
		set { _weight_used = value; }
	}


    public override String ToString()
    {
        return "exercise: " + _num_ex + " set_num: " +_set_num;
    }

    public RepsProgress() : base()
	{
	}

	public RepsProgress(int entry_num, int num_ex, int set_num, int reps_made, int weight_used) : base()
	{
		this._entry_num = entry_num;
		this._num_ex = num_ex;
		this._set_num = set_num;
		this._reps_made = reps_made;
		this._weight_used = weight_used;
	}
}
