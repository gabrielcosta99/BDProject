


SELECT * FROM reps_progress where entry_workout_prog=1 and num_ex=2

SELECT * FROM workout_progress;


SELECT * FROM workout_exercise join exercise on workout_exercise.num_ex=exercise.num_ex WHERE num_workout=1

select * from exercise;


insert into reps_progress VALUES (4,1,@num_ex,@set_num,0,0);