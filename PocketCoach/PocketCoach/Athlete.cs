using System;

public class Athlete
{
	private int _num_athlete;
	private string name;

	public int NumAthlete
	{
		get
		{
			return _num_athlete;
		}
		set
		{
			_num_athlete = value;
		}
	}

	public string Name
	{
		get
		{
			return name;
		}
		set
		{
			name = value;
		}
	}

	public override String ToString()
	{
		return "Athlete: " + name;
	}


	public Athlete() : base()
	{
	}

	public Athlete(int num_athlete, string name)
	{
		_num_athlete = num_athlete;
		this.name = name;
	}


}
