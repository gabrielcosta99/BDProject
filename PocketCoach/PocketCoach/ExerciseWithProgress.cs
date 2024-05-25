﻿using System;

public class ExerciseWithProgress
{
    private Exercise _exercise;
    public IProgress _progress;
    
    public Exercise Exercise
    {
        get { return _exercise; }
        set { _exercise = value; }
    }

    public IProgress Progress { 
        get { return _progress; } 
        set { _progress = value; }
    }

    public ExerciseWithProgress() : base()
    {

    }
    public ExerciseWithProgress(Exercise exercise, IProgress progress)
    {
        _exercise = exercise;
        _progress = progress;
    }


    // Override ToString() if needed for display purposes in listBox1
    public override string ToString()
    {
        return $"Exercise: {Exercise.Name}";
    }
}