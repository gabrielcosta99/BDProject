-- SP to get all the exercises of a workout

GO
CREATE PROCEDURE GetWorkoutExercises
    @num_workout INT
AS
BEGIN
    SELECT * FROM
        workout_exercise we
    JOIN
        exercise e ON we.num_ex = e.num_ex
    WHERE
        we.num_workout = @num_workout
END
GO

CREATE PROCEDURE GetAccessibleWorkouts
    @num_athlete INT
AS
BEGIN
    SELECT w.num_workout, w.title,w.tags,w.premium,w.PT_num 
	FROM athlete join subscription on athlete.num_athlete=subscription.num_athlete 
		join workout as w on subscription.num_PT=w.PT_num 
	WHERE athlete.num_athlete=@num_athlete or premium=0;

END

GO
-- to test the SP : EXEC GetWorkoutExercises 1;

-- SP to get the progress of all exercises of a workout for an athlete

GO
CREATE PROCEDURE GetWorkoutExerciseProgressForAthlete
    @num_workout INT,
    @num_athlete INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Seleciona o progresso dos exercícios de time
    SELECT 
        we.num_ex AS ExerciseID,
        e.name AS ExerciseName,
        tp.set_num AS SetNumber,
        tp.time AS Time,
        NULL AS RepsMade,
        NULL AS WeightUsed
    FROM 
        workout_exercise we
    INNER JOIN 
        exercise e ON we.num_ex = e.num_ex
    INNER JOIN 
        time_exercise te ON e.num_ex = te.num_ex
    INNER JOIN 
        workout_progress ep ON ep.Athlete_num = @num_athlete
    INNER JOIN 
        time_progress tp ON ep.entry_num = tp.entry_num AND tp.num_ex = te.num_ex
    WHERE 
        we.num_workout = @num_workout

    UNION ALL

    -- Seleciona o progresso dos exercícios de reps
    SELECT 
        we.num_ex AS ExerciseID,
        e.name AS ExerciseName,
        rp.set_num AS SetNumber,
        NULL AS Time,
        rp.reps_made AS RepsMade,
        rp.weight_used AS WeightUsed
    FROM 
        workout_exercise we
    INNER JOIN 
        exercise e ON we.num_ex = e.num_ex
    INNER JOIN 
        reps_exercise re ON e.num_ex = re.num_ex
    INNER JOIN 
        workout_progress ep ON ep.Athlete_num = @num_athlete
    INNER JOIN 
        reps_progress rp ON ep.entry_num = rp.entry_num AND rp.num_ex = re.num_ex
    WHERE 
        we.num_workout = @num_workout;
END
GO

-- to test the SP : EXEC GetWorkoutExerciseProgressForAthlete 1, 2;

-- To drop a SP, use the following command:

-- IF Object_Id('<sp_name>', 'P') IS NOT NULL
-- DROP PROCEDURE <sp_name>;