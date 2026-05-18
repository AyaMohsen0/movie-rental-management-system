-- (a): What was the most interesting movie genre(s) that had maximum number of rentals?

USE MovieRentalAppDB;
GO

SELECT MG.GenreName, COUNT(R.MovieID) AS Rental_Count
FROM Rental R
JOIN MovieGenre MGN ON MGN.MovieID = R.MovieID
JOIN Movie_Genre MG ON MG.GenreName = MGN.GenreName
GROUP BY MG.GenreName
HAVING COUNT(R.MovieID) = (
    SELECT MAX(Rental_Count)
    FROM (
        SELECT COUNT(R2.MovieID) AS Rental_Count
        FROM Rental R2
        JOIN MovieGenre MGN2 ON MGN2.MovieID = R2.MovieID
        JOIN Movie_Genre MG2 ON MG2.GenreName = MGN2.GenreName
        GROUP BY MG2.GenreName
    ) AS MaxRentals
)
ORDER BY MG.GenreName;




-- (b:What are the Movie genres with no rental requests in the last month ?
SELECT MG.GenreName
FROM Movie_Genre MG
WHERE MG.GenreName NOT IN (
    SELECT DISTINCT MGN.GenreName
    FROM Rental R
    JOIN MovieGenre MGN ON MGN.MovieID = R.MovieID
    WHERE R.RentalDate >= DATEADD(MONTH, -1, GETDATE())
);




-- (c): What were the added movies for each genre and when?
SELECT MG.GenreName, MT.Title, MS.SupplyDate
FROM MovieSupply MS
JOIN Movie_Tape MT ON MT.MovieID = MS.MovieID
JOIN MovieGenre MGN ON MGN.MovieID = MT.MovieID
JOIN Movie_Genre MG ON MG.GenreName = MGN.GenreName
ORDER BY MG.GenreName, MS.SupplyDate;




-- (d) Customer info with count of rented movies 
SELECT C.*,
       (SELECT COUNT(*) FROM Rental R WHERE EXISTS (
           SELECT 1 FROM SubscribesTo ST WHERE ST.CustomerID = C.CustomerID AND ST.MemberShipID = R.MemberShipID
       )) AS Rented_Movies
FROM Customer C;




-- (e):  What are the Total rentals and total sales per genre ?
SELECT MG.GenreName,
       COUNT(R.MovieID) AS Total_Rentals,
       SUM(R.RentalCharge) AS Total_Sales
FROM Rental R
JOIN MovieGenre MGN ON MGN.MovieID = R.MovieID
JOIN Movie_Genre MG ON MG.GenreName = MGN.GenreName
GROUP BY MG.GenreName
ORDER BY Total_Rentals DESC;




-- (f): Who are the Suppliers who have not supplied any movies in the last 3 months ?
SELECT S.*
FROM Supplier S
WHERE S.SupplierName NOT IN (
    SELECT DISTINCT MS.SupplierName
    FROM MovieSupply MS
    WHERE MS.SupplyDate >= DATEADD(MONTH, -3, GETDATE())
);
