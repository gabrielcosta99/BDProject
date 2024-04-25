using System;

public class Exercise
{
    private int _num_ex;
	private string _path;
	private string _name;
	private string _description;
	private string _muscletargets;
	private string _releasedate;
	private int _premium;
	private int _PT_num;
	private string _thumbnail;

	public int NumEx
	{
		get { return _num_ex; }
		set { _num_ex = value; }
	}

	public string Path
	{
		get { return _path; }
		set { _path = value; }
	}

	public string Name
	{
		get { return _name; }
		set { _name = value; }
	}

	public string Description
	{
		get { return _description; }
		set { _description = value; }
	}

	public string MuscleTargets
	{
		get { return _muscletargets; }
		set { _muscletargets = value; }
	}

	public string ReleaseDate
	{
		get { return _releasedate; }
		set { _releasedate = value; }
	}

	public int Premium
	{
		get { return _premium; }
		set { _premium = value; }
	}

	public int PTNum
	{
		get { return _PT_num; }
		set { _PT_num = value; }
	}

	public string Thumbnail
	{
		get { return _thumbnail; }
		set { _thumbnail = value; }	
	}


	public override String ToString()
	{
		return _name;
	}

	public Exercise() : base()
	{

	}


    public Exercise(int num_ex, string path, string name, string description, string muscletargets, string releasedate, int premium, int PT_num, string thumbnail) : base()
	{
		this._num_ex = num_ex;
		this._path = path;
		this._name = name;
		this._description = description;
		this._muscletargets = muscletargets;
		this._releasedate = releasedate;
		this._premium = premium;
		this._PT_num = PT_num;
		this._thumbnail = thumbnail;
	}
}
