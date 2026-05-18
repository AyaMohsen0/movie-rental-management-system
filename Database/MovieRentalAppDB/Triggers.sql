-- Fixed trigger for rental charge calculation
CREATE OR ALTER TRIGGER trg_CalculateRentalCharge
ON Rental
INSTEAD OF INSERT
AS
BEGIN
    INSERT INTO Rental (MemberShipID, MovieID, RentalDate, ReturnDate, RentalDuration, Quantity, RentalCharge)
    SELECT 
        i.MemberShipID,
        i.MovieID,
        i.RentalDate,
        i.ReturnDate,
        i.RentalDuration,
        i.Quantity,
        mt.Price_Per_Day * i.Quantity * i.RentalDuration AS RentalCharge
    FROM inserted i
    JOIN Movie_Tape mt ON i.MovieID = mt.MovieID;
END;
GO

-- Fixed trigger for availability update
CREATE OR ALTER TRIGGER trg_UpdateAvailabilityAfterRental
ON Rental
AFTER INSERT
AS
BEGIN
    UPDATE mt
    SET 
        mt.NoOfCopies = mt.NoOfCopies - i.Quantity,
        mt.AvailabilityStatus = CASE 
            WHEN (mt.NoOfCopies - i.Quantity) <= 0 THEN 0
            ELSE 1
        END
    FROM Movie_Tape mt
    JOIN inserted i ON mt.MovieID = i.MovieID;
END;
GO