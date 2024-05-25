public interface IProgress
{
    int EntryNum { get; set; }
    int EntryWorkout { get; set; }
    int NumEx { get; set; }
    int SetNum { get; set; }
}

/*
public class RepsProgress : IProgress
{
    public int EntryNum { get; set; }
    public int EntryWorkout { get; set; }
    public int NumEx { get; set; }
    public int SetNum { get; set; }
    public int RepsMade { get; set; }
    public int WeightUsed { get; set; }
}

public class TimeProgress : IProgress
{
    public int EntryNum { get; set; }
    public int EntryWorkout { get; set; }
    public int NumEx { get; set; }
    public int SetNum { get; set; }
    public int Time { get; set; }
}


public class ExerciseWithProgress
{
    public Exercise Exercise { get; set; }
    public IProgress Progress { get; set; }
}
*/
