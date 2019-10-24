USE master
GO

CREATE LOGIN GuildCarsApp WITH PASSWORD='welovecars123'
GO

USE GuildCars
GO

CREATE USER GuildCarsApp FOR LOGIN GuildCarsApp
GO

GRANT EXECUTE TO GuildCarsApp
GO

GRANT EXECUTE ON CreateDirector TO GuildCarsApp
GRANT EXECUTE ON CreateDVD TO GuildCarsApp
GRANT EXECUTE ON CreateRating TO GuildCarsApp
GRANT EXECUTE ON DeleteDVD TO GuildCarsApp
GRANT EXECUTE ON EditDVD TO GuildCarsApp
GRANT EXECUTE ON GetAllDVDs TO GuildCarsApp
GRANT EXECUTE ON GetDVDByDirector TO GuildCarsApp
GRANT EXECUTE ON GetDVDById TO GuildCarsApp
GRANT EXECUTE ON GetDVDByRating TO GuildCarsApp
GRANT EXECUTE ON GetDVDByReleaseYear TO GuildCarsApp
GRANT EXECUTE ON GetDVDByTitle TO GuildCarsApp
GO

GRANT SELECT ON Director TO GuildCarsApp
GRANT INSERT ON Director TO GuildCarsApp
GRANT UPDATE ON Director TO GuildCarsApp
GRANT DELETE ON Director TO GuildCarsApp
GO

GRANT SELECT ON Rating TO GuildCarsApp
GRANT INSERT ON Rating TO GuildCarsApp
GRANT UPDATE ON Rating TO GuildCarsApp
GRANT DELETE ON Rating TO GuildCarsApp
GO

GRANT SELECT ON DVD TO GuildCarsApp
GRANT INSERT ON DVD TO GuildCarsApp
GRANT UPDATE ON DVD TO GuildCarsApp
GRANT DELETE ON DVD TO GuildCarsApp
GO