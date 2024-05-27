-- UDF - para um dado workout_progress, retorna os reps_progress e time_progress associados
CREATE FUNCTION GetWorkoutProgressDetails(@entry_num INT)
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
);

-- to test the UDF - SELECT * FROM GetWorkoutProgressDetails(1);

CREATE TABLE exercise(
    num_ex INT PRIMARY KEY,
    path VARCHAR(50),
    name VARCHAR(50),
    description VARCHAR(1000),
    muscletargets VARCHAR(50),
    releasedate DATE,
    PT_num INT,
    thumbnail VARCHAR(50),
    FOREIGN KEY (PT_num) REFERENCES personal_trainer(num_PT)
)

CREATE TABLE reps_exercise(
    num_ex INT PRIMARY KEY,
    FOREIGN KEY (num_ex) REFERENCES exercise(num_ex)
);

CREATE TABLE time_exercise(
    num_ex INT PRIMARY KEY,
    FOREIGN KEY (num_ex) REFERENCES exercise(num_ex)
);

CREATE TABLE workout(
    num_workout INT PRIMARY KEY,
    title VARCHAR(50),
    tags VARCHAR(50),
	premium INT,
	PT_num INT,
	FOREIGN KEY (PT_num) REFERENCES personal_trainer(num_PT)
);

CREATE TABLE workout_exercise(
    num_workout INT,
    num_ex INT,
	set_num INT DEFAULT 1,
    PRIMARY KEY (num_workout, num_ex,set_num),
    FOREIGN KEY (num_workout) REFERENCES workout(num_workout),
    FOREIGN KEY (num_ex) REFERENCES exercise(num_ex)
);



CREATE TABLE workout_progress(
    entry_num INT PRIMARY KEY,
    Athlete_num INT,
    date DATE,
	num_workout INT,
    FOREIGN KEY (Athlete_num) REFERENCES athlete(num_athlete),
	FOREIGN KEY (num_workout) REFERENCES workout(num_workout),
);

CREATE TABLE time_progress(
    entry_num INT PRIMARY KEY,
	entry_workout_prog INT,
    num_ex INT,
    set_num INT,
    time INT,
    FOREIGN KEY (entry_workout_prog) REFERENCES workout_progress(entry_num),
	FOREIGN KEY (num_ex) REFERENCES time_exercise(num_ex),
);


CREATE TABLE reps_progress(
    entry_num INT PRIMARY KEY,
	entry_workout_prog INT,
    num_ex INT,
    set_num INT,
    reps_made INT,
    weight_used INT,
    FOREIGN KEY (entry_workout_prog) REFERENCES workout_progress(entry_num),
	FOREIGN KEY (num_ex) REFERENCES reps_exercise(num_ex),
);

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