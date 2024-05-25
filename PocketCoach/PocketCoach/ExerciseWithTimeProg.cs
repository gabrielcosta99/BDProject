using System;

public class ExerciseWithTimeProgress
{
    private Exercise _exercise;
    private TimeProgress _timeProg;
    
    public Exercise Exercise
    {
        get { return _exercise; }
        set { _exercise = value; }
    }

    public TimeProgress Progress { 
        get { return _timeProg; } 
        set { _timeProg = value; }
    }

    public ExerciseWithTimeProgress() : base()
    {

    }
    public ExerciseWithTimeProgress(Exercise exercise, TimeProgress progress)
    {
        _exercise = exercise;
        _timeProg = progress;
    }


    // Override ToString() if needed for display purposes in listBox1
    public override string ToString()
    {
        return $"Exercise: {Exercise.Name}";
    }
}