CREATE TABLE athlete(
    num_athlete INT PRIMARY KEY,
    name VARCHAR(50),
);

CREATE TABLE athlete_weight(
    num_athlete INT,
    weight INT,
    date DATE,
    PRIMARY KEY (num_athlete, date),
    FOREIGN KEY (num_athlete) REFERENCES athlete(num_athlete)
);

CREATE TABLE personal_trainer(
    num_PT INT PRIMARY KEY,
    name VARCHAR(50),
    description VARCHAR(50),
    tags VARCHAR(50),
    photo VARCHAR(50),
    price INT,
    slots INT,
);

CREATE TABLE subscription(
    num_PT INT,
    num_athlete INT,
    PRIMARY KEY (num_PT, num_athlete),
    FOREIGN KEY (num_PT) REFERENCES personal_trainer(num_PT),
    FOREIGN KEY (num_athlete) REFERENCES athlete(num_athlete)
);

CREATE TABLE exercise(
    num_ex INT PRIMARY KEY,
    path VARCHAR(50),
    name VARCHAR(50),
    description VARCHAR(1000),
    muscletargets VARCHAR(50),
    releasedate DATE,
    premium INT,
    PT_num INT,
    thumbnail VARCHAR(50),
    FOREIGN KEY (PT_num) REFERENCES personal_trainer(num_PT)
)

CREATE TABLE chat(
    num_chat INT PRIMARY KEY,
    Athlete_num INT,
    PT_num INT,   
    FOREIGN KEY (PT_num) REFERENCES personal_trainer(num_PT),
    FOREIGN KEY (Athlete_num) REFERENCES athlete(num_athlete)
);

CREATE TABLE message(
    num_msg INT PRIMARY KEY,
    chat_num INT,
    sent_by_user INT,
    text VARCHAR(1000),
    FOREIGN KEY (chat_num) REFERENCES chat(num_chat)
);

CREATE TABLE exercise_progress(
    entry_num INT PRIMARY KEY,
    Athlete_num INT,
    date DATE,
    FOREIGN KEY (Athlete_num) REFERENCES athlete(num_athlete)
);

CREATE TABLE time_exercise(
    num_ex INT PRIMARY KEY,
    FOREIGN KEY (num_ex) REFERENCES exercise(num_ex)
);

CREATE TABLE time_progress(
    entry_num INT PRIMARY KEY,
    num_ex INT,
    set_num INT,
    time INT,
    FOREIGN KEY (entry_num) REFERENCES exercise_progress(entry_num),
    FOREIGN KEY (num_ex) REFERENCES time_exercise(num_ex)
);

CREATE TABLE reps_exercise(
    num_ex INT PRIMARY KEY,
    FOREIGN KEY (num_ex) REFERENCES exercise(num_ex)
);

CREATE TABLE reps_progress(
    entry_num INT PRIMARY KEY,
    num_ex INT,
    set_num INT,
    reps_made INT,
    weight_used INT,
    FOREIGN KEY (entry_num) REFERENCES exercise_progress(entry_num),
    FOREIGN KEY (num_ex) REFERENCES reps_exercise(num_ex)
);

CREATE TABLE workout(
    workout_num INT PRIMARY KEY,
    workout_name VARCHAR(50),
    tags VARCHAR(50),
);

CREATE TABLE workout_playlist(
    workout_num INT,
    num_ex INT,
    PRIMARY KEY (workout_num, num_ex),
    FOREIGN KEY (workout_num) REFERENCES workout(workout_num),
    FOREIGN KEY (num_ex) REFERENCES exercise(num_ex)
);




