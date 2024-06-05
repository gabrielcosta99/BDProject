select * from workout_progress;

select * from reps_progress;
select * from time_progress;

DELETE FROM reps_progress WHERE entry_num>5;

DELETE FROM time_progress WHERE entry_num>=2;
DELETE FROM workout_progress WHERE entry_num>4;
