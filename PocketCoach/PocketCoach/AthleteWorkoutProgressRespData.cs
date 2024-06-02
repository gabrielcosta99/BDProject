using System;

public class AthleteWorkoutProgressRespData
{ 
    private int _workoutProgressID;
    private string _workoutTitle;
    private int _workoutPremium;
    private string _workoutPTName;

    public int WorkoutProgressID
    {
        get { return _workoutProgressID; }
        set { _workoutProgressID = value; }
    }

    public string WorkoutTitle
    {
        get { return _workoutTitle; }
        set { _workoutTitle = value; }
    }

    public int WorkoutPremium
    {
        get { return _workoutPremium; }
        set { _workoutPremium = value; }
    }

    public string WorkoutPTName
    {
        get { return _workoutPTName; }
        set { _workoutPTName = value; }
    }

    public override string ToString()
    {
        return _workoutTitle;
    }

    public AthleteWorkoutProgressRespData() : base()
    {
    }

    public AthleteWorkoutProgressRespData(int workoutProgressID, string workoutTitle, int workoutPremium, string workoutPTName) : base()
    {
        _workoutProgressID = workoutProgressID;
        _workoutTitle = workoutTitle;
        _workoutPremium = workoutPremium;
        _workoutPTName = workoutPTName;
    }
}
