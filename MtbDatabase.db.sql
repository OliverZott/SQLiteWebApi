BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "MountainbikeTours" (
	"TourId"	INTEGER NOT NULL UNIQUE,
	"TourName"	TEXT,
	"TourLength"	NUMERIC,
	"TourLocation"	TEXT,
	PRIMARY KEY("TourId" AUTOINCREMENT)
);
INSERT INTO "MountainbikeTours" VALUES (1,'Herbsttour',7.3,'Innsbruck');
COMMIT;
