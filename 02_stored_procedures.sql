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

-- SP to get all the workouts that an athlete has access to

CREATE PROCEDURE GetAccessibleWorkouts
    @num_athlete INT
AS
BEGIN
    SELECT w.num_workout, w.title,w.tags,w.premium,w.PT_num 
	FROM athlete JOIN subscription ON athlete.num_athlete=subscription.num_athlete 
		JOIN workout AS w ON subscription.num_PT=w.PT_num 
	WHERE athlete.num_athlete=@num_athlete OR premium=0;

END

GO
-- to test the SP : EXEC GetWorkoutExercises 1;

-- SP to get the progress of all exercises of a workout progress for an athlete

GO
CREATE PROCEDURE GetWorkoutExerciseProgressForAthlete
    @entry_num INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Seleciona o progresso dos exercícios de time
    SELECT  tp.num_ex AS ExerciseID,
		e.name AS ExerciseName,
        tp.set_num AS SetNumber,
		tp.time AS Time,
        NULL AS RepsMade,
        NULL AS WeightUsed
	FROM time_progress AS tp
		JOIN workout_progress ON workout_progress.entry_num=tp.entry_workout_prog
		JOIN exercise AS e ON tp.num_ex = e.num_ex
	WHERE workout_progress.entry_num = @entry_num

	UNION ALL

	SELECT rp.num_ex AS ExerciseID,
        e.name AS ExerciseName,
        rp.set_num,
        NULL AS time,
        rp.reps_made,
        rp.weight_used
	FROM reps_progress AS rp
		JOIN workout_progress ON workout_progress.entry_num=rp.entry_workout_prog
		JOIN exercise AS e ON rp.num_ex = e.num_ex
	WHERE workout_progress.entry_num = @entry_num

	ORDER BY SetNumber, ExerciseID

END
/*
CREATE PROCEDURE GetWorkoutExerciseProgressForAthlete
    @num_workout INT,
    @num_athlete INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Seleciona o progresso dos exercícios de time
    SELECT 
        tp.num_ex AS ExerciseID,
        e.name AS ExerciseName,
        tp.set_num AS SetNumber,
        tp.time AS Time,
        NULL AS RepsMade,
        NULL AS WeightUsed
    FROM
        workout_progress wp
    INNER JOIN
        time_progress tp ON wp.entry_num = tp.entry_workout_prog
    INNER JOIN
        time_exercise te ON tp.num_ex = te.num_ex
    INNER JOIN
        exercise e ON te.num_ex = e.num_ex
    WHERE
        wp.num_workout = @num_workout AND wp.Athlete_num = @num_athlete

    UNION ALL

    -- Seleciona o progresso dos exercícios de reps
    SELECT 
        rp.num_ex AS ExerciseID,
        e.name AS ExerciseName,
        rp.set_num AS SetNumber,
        NULL AS Time,
        rp.reps_made AS RepsMade,
        rp.weight_used AS WeightUsed
    FROM 
        workout_progress wp
    INNER JOIN
        reps_progress rp ON wp.entry_num = rp.entry_workout_prog
    INNER JOIN
        reps_exercise re ON rp.num_ex = re.num_ex
    INNER JOIN
        exercise e ON re.num_ex = e.num_ex
    WHERE
        wp.num_workout = @num_workout AND wp.Athlete_num = @num_athlete
END



GO
*/
-- to test the SP : EXEC GetWorkoutExerciseProgressForAthlete 1, 2;

-- SP to get Athlete Workout Progress with repective Workout data

GO
CREATE PROCEDURE GetAthleteWorkoutProgressRespData
    @num_athlete INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        wp.entry_num AS WorkoutProgressID,
        w.title AS WorkoutTitle,
        w.tags AS WorkoutTags,
        w.premium AS WorkoutPremium,
        pt.name AS WorkoutPTName,
        wp.date AS Date
    FROM
        workout_progress wp
    INNER JOIN
        workout w ON wp.num_workout = w.num_workout
    INNER JOIN
        personal_trainer pt ON w.PT_num = pt.num_PT
    WHERE
        wp.Athlete_num = @num_athlete
END


GO
CREATE PROCEDURE DeleteSub
    @num_athlete INT,
	@num_PT INT

AS
BEGIN
    SET NOCOUNT ON;

	DELETE FROM subscription WHERE num_athlete=@num_athlete and num_PT=@num_PT;
	
	DECLARE @num_chat INT;
	select @num_chat=num_chat from chat where athlete_num=@num_athlete and PT_num=@num_PT;

	DELETE from message where chat_num = @num_chat;
	DELETE from chat where num_chat = @num_chat;


END

-- to test the SP : EXEC GetAthleteWorkoutProgressRespData 2;

-- To drop a SP, use the following command:

-- IF Object_Id('<sp_name>', 'P') IS NOT NULL
-- DROP PROCEDURE <sp_name>;