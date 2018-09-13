CREATE TABLE gast 
(
gastID	INT NOT NULL,
voornaam	nvarchar(25), 
achternaam	NVARCHAR(255), 
adres nvarchar(100) NOT NULL,
woonplaats nvarchar(100),
postcode nvarchar(10),
telNr nvarchar(25),
email nvarchar(50)
)
ALTER TABLE gast ADD constraint gastID PRIMARY KEY CLUSTERED (gastID)

CREATE TABLE boeking(
boekingID INT NOT NULL,
gastID INT NOT NULL,
)
ALTER TABLE boeking ADD constraint boekingID PRIMARY KEY CLUSTERED (boekingID)

CREATE TABLE reservering(
reserveringID INT NOT NULL,
lodgeID INT NOT NULL,
boekingID INT NOT NULL,
incheckDatum DateTime NOT NULL,
uitcheckDatum DateTime NOT NULL
)
ALTER TABLE reservering ADD constraint reserveringID PRIMARY KEY CLUSTERED (reserveringID)

CREATE TABLE lodge(
lodgeID INT NOT NULL,
lodgeTypeID INT NOT NULL,
lodgeNaam nvarchar(50),
lodgeNR nvarchar(50),
bezettingsgraad nvarchar(20)
)
ALTER TABLE lodge ADD constraint lodgeID PRIMARY KEY CLUSTERED (lodgeID)

CREATE TABLE lodgetype(
lodgeTypeID INT NOT NULL,
lodgeTypeNaam nvarchar(100),
lodgeTypeOmschrijving nvarchar(250),
aantalpersonen INT NOT NULL,
prijs Money NOT NULL,
)
ALTER TABLE lodgetype ADD constraint lodgeTypeID PRIMARY KEY CLUSTERED (lodgeTypeID)

--Boeking FK
ALTER TABLE boeking ADD CONSTRAINT boeking_gast_FK FOREIGN KEY ( gastID ) REFERENCES gast ( gastID )
ON DELETE NO ACTION 
ON UPDATE 
NO ACTION
--Reservering FK
ALTER TABLE reservering ADD CONSTRAINT reservering_lodge_FK FOREIGN KEY ( lodgeID ) REFERENCES lodge ( lodgeID )
ON DELETE NO ACTION 
ON UPDATE 
NO ACTION
ALTER TABLE reservering ADD CONSTRAINT reservering_boeking_FK FOREIGN KEY ( boekingID ) REFERENCES boeking ( boekingID )
ON DELETE NO ACTION 
ON UPDATE 
NO ACTION
--Lodge FK
ALTER TABLE lodge ADD CONSTRAINT lodge_lodgetype_FK FOREIGN KEY ( lodgeTypeID ) REFERENCES lodgetype ( lodgeTypeID )
ON DELETE NO ACTION 
ON UPDATE 
NO ACTION


select * from gast;