select * from workout_progress;

select * from reps_progress;

DELETE FROM reps_progress WHERE entry_num>5;
DELETE FROM workout_progress WHERE entry_num>4;