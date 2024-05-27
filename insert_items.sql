INSERT INTO athlete VALUES (1, 'Gabriel Costa');
INSERT INTO athlete VALUES (2, 'Henrique Coelho');
INSERT INTO athlete VALUES (3, 'Daniel Emidio');

INSERT INTO athlete_weight VALUES(1,76,'2020-01-20');
INSERT INTO athlete_weight VALUES(1,80,'2021-01-01');
INSERT INTO athlete_weight VALUES(1,78,'2022-05-14');

INSERT INTO personal_trainer VALUES (1, 'UA1', 'Upper body expert', 'Fitness, Bodybuilding', '../../imgs/ua1.jpg', 20, 10);
INSERT INTO personal_trainer VALUES (2, 'UA2', 'Lower body expert', 'Fitness, Bodybuilding', '../../imgs/ua2.jpg', 25, 5);
INSERT INTO personal_trainer VALUES (3, 'UA3', 'Full body expert', 'Fitness, Bodybuilding', '../../imgs/ua3.jpg', 30, 15);

INSERT INTO subscription VALUES (1, 1);
INSERT INTO subscription VALUES (1, 2);
INSERT INTO subscription VALUES (2, 3);
INSERT INTO subscription VALUES (3, 2);

INSERT INTO exercise VALUES (1, '../../../../../videos/uatreino1.mp4', 'Bench Press', 'The bench press is an upper-body weight training exercise in which the trainee presses a weight upwards while lying on a weight training bench.', 'Chest, Triceps, Shoulders', '2021-05-01', 1, '../../imgs/ex1.jpg');
INSERT INTO exercise VALUES (2, '../../../../../videos/uatreino2.mp4', 'Squat', 'The squat is a lower body exercise that works several muscle groups. It is a versatile exercise that can be done in many different ways.', 'Quadriceps, Hamstrings, Glutes', '2021-05-01', 2, '../../imgs/ex2.jpg');
INSERT INTO exercise VALUES (3, '../../../../../videos/uatreino3.mp4', 'Deadlift', 'The deadlift is a weight training exercise in which a loaded barbell or bar is lifted off the ground to the level of the hips, then lowered to the ground.', 'Lower back, Glutes, Hamstrings', '2021-05-01', 3, '../../imgs/ex3.jpg')
INSERT INTO exercise VALUES (4, '../../../../../videos/uatreino3.mp4', 'Plank', 'The plank is an isometric core strength exercise that involves maintaining a position similar to a push-up for the maximum possible time.', 'Core', '2021-05-01', 1, '../../imgs/ex4.jpg');
INSERT INTO exercise VALUES (5, '../../../../../videos/uatreino3.mp4', 'Running', 'Running is a method of terrestrial locomotion allowing humans and other animals to move rapidly on foot.', 'Cardio', '2021-05-01', 1, '../../imgs/ex5.jpg');

INSERT INTO chat VALUES (1, 1, 1);
INSERT INTO chat VALUES (2, 2, 3);
INSERT INTO chat VALUES (3, 3, 3)

INSERT INTO message VALUES (1, 1, 1, 'Hello, how are you?');
INSERT INTO message VALUES (2, 1, 0, 'I am fine, thank you. How can I help you?');
INSERT INTO message VALUES (3, 2, 1, 'Hello, I would like to know more about the subscription.');
INSERT INTO message VALUES (4, 2, 0, 'Sure, what would you like to know?');

INSERT INTO workout VALUES(1,'Chest and legs','chest,legs',1,1);
INSERT INTO workout VALUES(2,'Leg day','legs',1,2);
INSERT INTO workout VALUES(3,'Beginner workout','full body',0,1);

INSERT INTO workout_exercise VALUES(1,1,1);
INSERT INTO workout_exercise VALUES(1,4,1);
INSERT INTO workout_exercise VALUES(1,5,1);
INSERT INTO workout_exercise VALUES(1,1,2);
INSERT INTO workout_exercise VALUES(1,4,2);
INSERT INTO workout_exercise VALUES(1,5,2);
INSERT INTO workout_exercise VALUES(2,2,1);
INSERT INTO workout_exercise VALUES(2,2,2);
INSERT INTO workout_exercise VALUES(3,1,1);
INSERT INTO workout_exercise VALUES(3,4,1);
INSERT INTO workout_exercise VALUES(3,5,1);


INSERT INTO workout_progress VALUES(1, 2, '2021-05-01',1);
INSERT INTO workout_progress VALUES(2, 2, '2021-05-02',1);
INSERT INTO workout_progress VALUES(3, 3, '2021-05-01',2);
INSERT INTO workout_progress VALUES(4, 3, '2021-01-01',2);

INSERT INTO reps_exercise VALUES(1);
INSERT INTO reps_exercise VALUES(2);
INSERT INTO reps_exercise VALUES(3);

INSERT INTO time_exercise VALUES(4);
INSERT INTO time_exercise VALUES(5);

-- entry_num, entry_workout ,num_ex, set_num, reps_made, weight_used
INSERT INTO reps_progress VALUES(1,1, 1, 1, 10, 50);
INSERT INTO reps_progress VALUES(2,1, 1, 2, 12, 50);
INSERT INTO reps_progress VALUES(3,1, 1, 3, 8, 50);
INSERT INTO reps_progress VALUES(4,1, 4, 1, 10, 50);
INSERT INTO reps_progress VALUES(5,1, 4, 2, 12, 50);
INSERT INTO reps_progress VALUES(6,1, 4, 3, 8, 50);


select * from athlete_weight
select * from athlete;
select * from personal_trainer;
select * from subscription; 
select * from exercise;
select * from chat;
select * from message;
select * from workout;
select * from workout_exercise;
select * from reps_exercise;
select * from time_exercise;
select * from workout_progress;
select * from reps_progress;
select * from time_progress;
