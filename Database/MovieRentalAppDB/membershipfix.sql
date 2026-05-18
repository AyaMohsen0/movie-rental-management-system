USE MovieRentalAppDB;
GO

-- Find the actual constraint names
SELECT 
    fk.name AS constraint_name,
    OBJECT_NAME(fk.parent_object_id) AS referencing_table,
    OBJECT_NAME(fk.referenced_object_id) AS referenced_table
FROM 
    sys.foreign_keys fk
WHERE 
    OBJECT_NAME(fk.referenced_object_id) = 'MemberShip';
GO

-- Drop constraints (replace with actual names from above query)
ALTER TABLE SubscribesTo DROP CONSTRAINT [FK_SubscribesTo_MemberShip];
ALTER TABLE Rental DROP CONSTRAINT [FK_Rental_MemberShip];
GO


-- Create new table with IDENTITY
CREATE TABLE MemberShip_new (
    MemberShipID INT IDENTITY(1,1) PRIMARY KEY,
    Price DECIMAL(6,2),
    StartDate DATE,
    EndDate DATE,
    Status VARCHAR(50),
    Type VARCHAR(50)
);
GO

-- Enable identity insert to preserve existing values
SET IDENTITY_INSERT MemberShip_new ON;

-- Copy data
INSERT INTO MemberShip_new (MemberShipID, Price, StartDate, EndDate, Status, Type)
SELECT MemberShipID, Price, StartDate, EndDate, Status, Type FROM MemberShip;

SET IDENTITY_INSERT MemberShip_new OFF;
GO

-- Drop the old table
DROP TABLE MemberShip;
GO

-- Rename the new table
EXEC sp_rename 'MemberShip_new', 'MemberShip';
GO


-- Recreate constraints
ALTER TABLE SubscribesTo ADD CONSTRAINT FK_SubscribesTo_MemberShip
FOREIGN KEY (MemberShipID) REFERENCES MemberShip(MemberShipID);

ALTER TABLE Rental ADD CONSTRAINT FK_Rental_MemberShip
FOREIGN KEY (MemberShipID) REFERENCES MemberShip(MemberShipID);
GO