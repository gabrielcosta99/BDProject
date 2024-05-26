-- Trigger for checking if a personal trainer has slots available before inserting a subscription, and updating the slots after inserting
GO
CREATE TRIGGER check_PT_slots ON subscription
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @num_PT INT, @slots INT;
    SELECT @num_PT = num_PT FROM inserted;
    
    SELECT @slots = slots FROM personal_trainer WHERE num_PT = @num_PT;
    
    IF @slots <= 0
    BEGIN
        RAISERROR ('Sem slots disponíveis para este Personal Trainer.', 16, 1);
        ROLLBACK TRAN; -- Anula a inserção
    END
    ELSE
    BEGIN
        UPDATE personal_trainer SET slots = slots - 1 WHERE num_PT = @num_PT;
    END
END
GO


-- Trigger for deleting all related data to a personal trainer when deleting a personal trainer
GO
CREATE TRIGGER delete_related_PT_data ON personal_trainer
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @num_PT INT;
    SELECT @num_PT = num_PT FROM deleted;
    
    DECLARE @num_ex INT;
    SELECT @num_ex = num_ex FROM exercise WHERE PT_num = @num_PT;

    -- save entry from reps_progress and time_progress so we can delete exercise_progress
    DECLARE @entry_reps INT;
    SELECT @entry_reps = entry_num FROM reps_progress WHERE num_ex = @num_ex;
    DECLARE @entry_time INT;
    SELECT @entry_time = entry_num FROM time_progress WHERE num_ex = @num_ex;
    
    DELETE FROM subscription WHERE num_PT = @num_PT;

    -- Before deleting chat, delete all related data
    DELETE FROM message WHERE chat_num IN (SELECT num_chat FROM chat WHERE PT_num = @num_PT);
    DELETE FROM chat WHERE PT_num = @num_PT;
    
    -- Before deleting exercise, delete all related data
    DELETE FROM workout_exercise WHERE num_workout IN (SELECT num_workout FROM workout WHERE PT_num = @num_PT);
    DELETE FROM time_progress WHERE num_ex = @num_ex;
    DELETE FROM reps_progress WHERE num_ex = @num_ex;
    DELETE FROM reps_exercise WHERE num_ex = @num_ex;
    DELETE FROM time_exercise WHERE num_ex = @num_ex;
    DELETE FROM exercise_progress WHERE entry_num = @entry_reps;
    DELETE FROM exercise_progress WHERE entry_num = @entry_time;
    DELETE FROM exercise WHERE PT_num = @num_PT;

    DELETE FROM workout WHERE PT_num = @num_PT;

    DELETE FROM personal_trainer WHERE num_PT = @num_PT;
END

-- Trigger for deleting all related data to a athlete when deleting a athlete
GO
CREATE TRIGGER delete_related_athlete_data ON athlete
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @num_athlete INT;
    SELECT @num_athlete = num_athlete FROM deleted;
    
    DELETE FROM athlete_weight WHERE num_athlete = @num_athlete;
    DELETE FROM subscription WHERE num_athlete = @num_athlete;

    -- Before deleting chat, delete all related data
    DELETE FROM message WHERE chat_num IN (SELECT num_chat FROM chat WHERE Athlete_num = @num_athlete);
    DELETE FROM chat WHERE Athlete_num = @num_athlete;
    
    -- Before deleting exercise_progress, delete all related data
    DELETE FROM time_progress WHERE entry_num IN (SELECT entry_num FROM exercise_progress WHERE Athlete_num = @num_athlete);
    DELETE FROM reps_progress WHERE entry_num IN (SELECT entry_num FROM exercise_progress WHERE Athlete_num = @num_athlete);
    DELETE FROM exercise_progress WHERE Athlete_num = @num_athlete;
    
    DELETE FROM athlete WHERE num_athlete = @num_athlete;
END

-- To Delete the triggers do:
-- DROP TRIGGER <trigger_name> 