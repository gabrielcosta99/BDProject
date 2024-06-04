-- View to display the top 3 cheapest personal trainers

GO
CREATE VIEW Top3CheapestPTs AS
SELECT TOP 3
    num_PT,
    name,
    description,
    tags,
    photo,
    price,
    slots
FROM 
    personal_trainer
ORDER BY 
    price ASC;
GO

-- to test : SELECT * FROM Top3CheapestPTs;

-- To drop a View, use the following command: 
-- DROP VIEW <view_name>;