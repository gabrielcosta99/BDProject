CREATE INDEX idx_subscription_num_athlete ON subscription(num_athlete);		-- due to constant search for an athlete subscriptions


CREATE INDEX idx_exercise_PT_num ON exercise(PT_num);	-- in order to speed up lookups of exercises by personal trainer

CREATE INDEX idx_workout_PT_num ON workout(PT_num);		-- in order to speed up lookups of workouts by personal trainer



