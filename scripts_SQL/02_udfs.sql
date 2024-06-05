-- UDF - para um dado workout_progress, retorna os reps_progress e time_progress associados
/*CREATE FUNCTION GetWorkoutProgressDetails(@entry_num INT)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        rp.set_num AS SetNumber,
        rp.reps_made AS RepsMade,
        rp.weight_used AS WeightUsed,
        NULL AS Time
    FROM 
        reps_progress rp
    WHERE 
        rp.entry_workout_prog = @entry_num

    UNION ALL

    SELECT 
        tp.set_num AS SetNumber,
        NULL AS RepsMade,
        NULL AS WeightUsed,
        tp.time AS Time
    FROM 
        time_progress tp
    WHERE 
        tp.entry_workout_prog = @entry_num
);*/

-- to test the UDF - SELECT * FROM GetWorkoutProgressDetails(1);

-- UDF - estimativa de duração do workout de um athlete, ou seja, se houvesse "time_exercises" somava o tempo deste (o tempo original do exercicio), se fossem "reps_exercises" então dizia-se que cada exercicio durava 30s e somava-se
GO
CREATE FUNCTION GetWorkoutDuration(@num_workout INT, @num_athlete INT)
RETURNS INT
AS
BEGIN
    DECLARE @Duration INT = 0;

    -- Variável temporária para armazenar os resultados combinados
    DECLARE @CombinedResults TABLE (
        ExerciseID INT,
        SetNumber INT,
        Time INT,
        RepsMade INT,
        WeightUsed INT
    );

    -- Inserir resultados do time_progress
    INSERT INTO @CombinedResults (ExerciseID, SetNumber, Time, RepsMade, WeightUsed)
    SELECT 
        tp.num_ex AS ExerciseID,
        tp.set_num AS SetNumber,
        tp.time AS Time,
        NULL AS RepsMade,
        NULL AS WeightUsed
    FROM 
        workout_progress wp
    INNER JOIN 
        time_progress tp ON wp.entry_num = tp.entry_workout_prog
    WHERE 
        wp.num_workout = @num_workout
        AND wp.Athlete_num = @num_athlete;

    -- Inserir resultados do reps_progress
    INSERT INTO @CombinedResults (ExerciseID, SetNumber, Time, RepsMade, WeightUsed)
    SELECT 
        rp.num_ex AS ExerciseID,
        rp.set_num AS SetNumber,
        NULL AS Time,
        rp.reps_made AS RepsMade,
        rp.weight_used AS WeightUsed
    FROM 
        workout_progress wp
    INNER JOIN 
        reps_progress rp ON wp.entry_num = rp.entry_workout_prog
    WHERE 
        wp.num_workout = @num_workout
        AND wp.Athlete_num = @num_athlete;

    -- Calcular a duração total
    SELECT 
        @Duration = @Duration + 
        CASE 
            WHEN cr.Time IS NOT NULL THEN cr.Time
            ELSE 30
        END
    FROM 
        @CombinedResults cr;

    RETURN @Duration;
END
GO

-- to test the UDF - SELECT dbo.GetWorkoutDuration(1, 2);

-- To drop a UDF, use the following command:
-- DROP FUNCTION <udf_name>;