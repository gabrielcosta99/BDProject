using System;

public class WorkoutExercise
{
	private int _num_workout;
	private int _num_exercise;

	public int NumWorkout
	{
		get { return _num_workout; }
		set { _num_workout = value; }
	}

	public int NumExercise
	{
		get { return _num_exercise; }
		set { _num_exercise = value; }
	}

	public WorkoutExercise() : base()
	{
	}

	public WorkoutExercise(int num_workout, int num_exercise) : base()
	{
		_num_workout = num_workout;
		_num_exercise = num_exercise;
	}
}
