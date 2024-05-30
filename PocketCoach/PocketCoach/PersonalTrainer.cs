using System;

public class PersonalTrainer
{
    private int _numPT;
	private String _name;
	private String _description;
	private String _tags;
	private String _photo;
	private int _price;
	private int _slots;

    public int NumPT
    {
        get { return _numPT; }
        set { _numPT = value; }
    }

    public String Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public String Description
    {
        get { return _description; }
        set { _description = value; }
    }

    public String Tags
    {
        get { return _tags; }
        set { _tags = value; }
    }

    public String Photo
    {
        get { return _photo; }
        set { _photo = value; }
    }

    public int Price
    {
        get { return _price; }
        set { _price = value; }
    }

    public int Slots
    {
        get { return _slots; }
        set { _slots = value; }
    }


    public override string ToString()
    {
        return "PT: "+_name;
    }



    public PersonalTrainer() : base()
    {

    }

    public PersonalTrainer( int numPT, String name, String description, String tags, String photo, int price, int slots) : base()
	{
		this._numPT = numPT;
        this._name = name;
        this._description = description;
        this._tags = tags;
		this._photo = photo;
		this._price = price;
		this._slots = slots;
	}
}