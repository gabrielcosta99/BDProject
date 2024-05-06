using System;

public class Subscription
{
	private int _num_PT;
	private int _num_athlete;
	
	public int Num_PT
	{
		get { return _num_PT; }
		set { _num_PT = value; }
	}

	public int Num_Athlete
	{
		get { return _num_athlete; }
		set { _num_athlete = value; }
	}
	
	public Subscription() : base()
	{
	}
	public Subscription(int num_PT, int num_athlete) : base()
	{
		_num_PT = num_PT;
		_num_athlete = num_athlete;
	}
}
