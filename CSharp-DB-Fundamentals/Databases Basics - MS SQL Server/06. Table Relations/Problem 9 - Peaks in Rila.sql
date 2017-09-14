SELECT MountainRange AS [MountainRange], PeakName AS [PeakName], Elevation FROM Peaks
JOIN Mountains ON
Peaks.MountainId = Mountains.Id
WHERE Mountains.Id = 17
ORDER BY Elevation DESC