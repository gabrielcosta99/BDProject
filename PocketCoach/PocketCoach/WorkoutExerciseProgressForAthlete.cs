using System;

public class WorkoutExerciseProgressForAthlete
{
    private int _exerciseProgressID;
    private string _exerciseName;
    private int _exerciseSetNumber;
    private int _exerciseTime;
    private int _exerciseRepsMade;
    private int _exerciseWeightUsed;

    public int ExerciseProgressID
    {
        get { return _exerciseProgressID; }
        set { _exerciseProgressID = value; }
    }

    public string ExerciseName
    {
        get { return _exerciseName; }
        set { _exerciseName = value; }
    }

    public int ExerciseSetNumber
    {
        get { return _exerciseSetNumber; }
        set { _exerciseSetNumber = value; }
    }

    public int ExerciseTime
    {
        get { return _exerciseTime; }
        set { _exerciseTime = value; }
    }

    public int ExerciseRepsMade
    {
        get { return _exerciseRepsMade; }
        set { _exerciseRepsMade = value; }
    }

    public int ExerciseWeightUsed
    {
        get { return _exerciseWeightUsed; }
        set { _exerciseWeightUsed = value; }
    }

    public override string ToString()
    {
        return _exerciseName;
    }

    public WorkoutExerciseProgressForAthlete() : base()
    {
    }

    public WorkoutExerciseProgressForAthlete(int exerciseProgressID, string exerciseName, int exerciseSetNumber, int exerciseTime, int exerciseRepsMade, int exerciseWeightUsed) : base()
    {
        _exerciseProgressID = exerciseProgressID;
        _exerciseName = exerciseName;
        _exerciseSetNumber = exerciseSetNumber;
        _exerciseTime = exerciseTime;
        _exerciseRepsMade = exerciseRepsMade;
        _exerciseWeightUsed = exerciseWeightUsed;
    }
}
