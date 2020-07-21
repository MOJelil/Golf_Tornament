-- --------------------------------------------------------------------------------
-- Options
-- --------------------------------------------------------------------------------
USE dbSQL1;     -- Get out of the master database
SET NOCOUNT ON; -- Report only errors

-- --------------------------------------------------------------------------------
-- Drop Tables
-- --------------------------------------------------------------------------------
IF OBJECT_ID( 'TGolferEventYearSponsors' )		IS NOT NULL DROP TABLE	TGolferEventYearSponsors
IF OBJECT_ID( 'TGolferEventYears' )				IS NOT NULL DROP TABLE	TGolferEventYears
IF OBJECT_ID( 'TEventYears' )					IS NOT NULL DROP TABLE	TEventYears
IF OBJECT_ID( 'TGolfers' )						IS NOT NULL DROP TABLE	TGolfers
IF OBJECT_ID( 'TGenders' )						IS NOT NULL DROP TABLE	TGenders
IF OBJECT_ID( 'TShirtSizes' )					IS NOT NULL DROP TABLE	TShirtSizes
IF OBJECT_ID( 'TPaymentTypes' )					IS NOT NULL DROP TABLE	TPaymentTypes
IF OBJECT_ID( 'TSponsors' )						IS NOT NULL DROP TABLE	TSponsors
IF OBJECT_ID( 'TSponsorTypes' )					IS NOT NULL DROP TABLE	TSponsorTypes

IF OBJECT_ID( 'uspDeleteGolfer' )					IS NOT NULL DROP PROCEDURE	uspDeleteGolfer
IF OBJECT_ID( 'uspUpdateGolfer' )					IS NOT NULL DROP PROCEDURE	uspUpdateGolfer

IF OBJECT_ID( 'uspDeleteSponsor' )					IS NOT NULL DROP PROCEDURE	uspDeleteSponsor
IF OBJECT_ID( 'uspUpdateSponsor' )					IS NOT NULL DROP PROCEDURE	uspUpdateSponsor


-- --------------------------------------------------------------------------------
-- Step #1: Create Tables
-- --------------------------------------------------------------------------------
CREATE TABLE TEventYears
(
	 intEventYearID		INTEGER			NOT NULL
	,intEventYear		INTEGER			NOT NULL
	,CONSTRAINT TEventYears_PK PRIMARY KEY ( intEventYearID	)
)

CREATE TABLE TGenders
(
	 intGenderID		INTEGER			NOT NULL
	,strGenderDesc			VARCHAR(50)		NOT NULL
	,CONSTRAINT TGenders_PK PRIMARY KEY ( intGenderID )
)

CREATE TABLE TShirtSizes
(
	 intShirtSizeID			INTEGER			NOT NULL
	,strShirtSizeDesc		VARCHAR(50)		NOT NULL
	,CONSTRAINT TShirtSizes_PK PRIMARY KEY ( intShirtSizeID )
)

CREATE TABLE TGolfers
(
	 intGolferID		INTEGER			NOT NULL
	,strGolferFirstName		VARCHAR(50)		NOT NULL
	,strGolferLastName		VARCHAR(50)		NOT NULL
	,strGolferStreetAddress	VARCHAR(50)		NOT NULL
	,strGolferCity			VARCHAR(50)		NOT NULL
	,strGolferState			VARCHAR(50)		NOT NULL
	,strGolferZip				VARCHAR(50)		NOT NULL
	,strGolferPhoneNumber		VARCHAR(50)		NOT NULL
	,strGolferEmail			VARCHAR(50)		NOT NULL
	,intShirtSizeID		INTEGER			NOT NULL
	,intGenderID		INTEGER			NOT NULL
	,CONSTRAINT TGolfers_PK PRIMARY KEY ( intGolferID )
)

CREATE TABLE TSponsors
(
	 intSponsorID		INTEGER			NOT NULL
	,strFirstName		VARCHAR(50)		NOT NULL
	,strLastName		VARCHAR(50)		NOT NULL
	,strStreetAddress	VARCHAR(50)		NOT NULL
	,strCity			VARCHAR(50)		NOT NULL
	,strState			VARCHAR(50)		NOT NULL
	,strZip				VARCHAR(50)		NOT NULL
	,strPhoneNumber		VARCHAR(50)		NOT NULL
	,strEmail			VARCHAR(50)		NOT NULL
	,CONSTRAINT TSponsors_PK PRIMARY KEY ( intSponsorID )
)

CREATE TABLE TPaymentTypes
(
	 intPaymentTypeID		INTEGER			NOT NULL
	,strPaymentTypeDesc		VARCHAR(50)		NOT NULL
	,CONSTRAINT TPaymentTypes_PK PRIMARY KEY ( intPaymentTypeID )
)

CREATE TABLE TGolferEventYears
(
	 intGolferEventYearID	INTEGER		NOT NULL
	,intGolferID			INTEGER			NOT NULL
	,intEventYearID			INTEGER			NOT NULL
	,CONSTRAINT TGolferEventYears_UQ UNIQUE ( intGolferID, intEventYearID )
	,CONSTRAINT TGolferEventYears_PK PRIMARY KEY ( intGolferEventYearID )
)


CREATE TABLE TGolferEventYearSponsors
(
	 intGolferEventYearSponsorID	INTEGER			NOT NULL
	,intGolferID					INTEGER			NOT NULL
	,intEventYearID					INTEGER			NOT NULL
--	,intSponsorIndex				INTEGER			NOT NULL
	,intSponsorID					INTEGER			NOT NULL
	,monPledgeAmount				MONEY			NOT NULL
	,intSponsorTypeID				INTEGER			NOT NULL
	,intPaymentTypeID				INTEGER			NOT NULL
	,blnPaid						BIT			NOT NULL
	,CONSTRAINT TGolferEventYearSponsors_UQ UNIQUE ( intGolferID, intEventYearID, intSponsorID )
	,CONSTRAINT TGolferEventYearSponsors_PK PRIMARY KEY ( intGolferEventYearSponsorID )
)

CREATE TABLE TSponsorTypes
(
	 intSponsorTypeID		INTEGER			NOT NULL
	,strSponsorTypeDesc		VARCHAR(50)		NOT NULL
	,CONSTRAINT TSponsorTypes_PK PRIMARY KEY ( intSponsorTypeID )
)


-- --------------------------------------------------------------------------------
-- Step #2: Identify and Create Foreign Keys
-- --------------------------------------------------------------------------------
--
-- #	Child							Parent						Column(s)
-- -	-----							------						---------
-- 1	TGolfers						TGenders					intGenderID
-- 2	TGolfers						TShirtSizes					intShirtSizeID
-- 3    TGolferEventYears				TGolfers					intGolferID
-- 4	TGolferEventYearSponsors		TGolferEventYears			intGolferID, intEventYearID
-- 5	TGolferEventYears				TEventYears					intEventYearID
-- 6    TGolferEventYearSponsors		TSponsors					intSponsorID
-- 7	TGolferEventYearSponsors		TSponsorTypes				intSponsorTypeID
-- 8	TGolferEventYearSponsors		TPaymentTypes				intPaymentTypeID

-- 1
ALTER TABLE TGolfers ADD CONSTRAINT TGolfers_TGenders_FK
FOREIGN KEY ( intGenderID ) REFERENCES TGenders ( intGenderID )

-- 2
ALTER TABLE TGolfers ADD CONSTRAINT TGolfers_TShirtSizes_FK
FOREIGN KEY ( intShirtSizeID ) REFERENCES TShirtSizes ( intShirtSizeID )

-- 3
ALTER TABLE TGolferEventYears ADD CONSTRAINT TGolferEventYears_TGolfers_FK
FOREIGN KEY ( intGolferID ) REFERENCES TGolfers ( intGolferID )

-- 4
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TGolferEventYears_FK
FOREIGN KEY ( intGolferID, intEventYearID ) REFERENCES TGolferEventYears ( intGolferID, intEventYearID )

-- 5
ALTER TABLE TGolferEventYears ADD CONSTRAINT TGolferEventYears_TEventYears_FK
FOREIGN KEY ( intEventYearID ) REFERENCES TEventYears ( intEventYearID )

-- 6
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TSponsors_FK
FOREIGN KEY ( intSponsorID ) REFERENCES TSponsors ( intSponsorID )

-- 7
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TSponsorTypes_FK
FOREIGN KEY ( intSponsorTypeID ) REFERENCES TSponsorTypes ( intSponsorTypeID )

-- 8
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TPaymentTypes_FK
FOREIGN KEY ( intPaymentTypeID ) REFERENCES TPaymentTypes ( intPaymentTypeID )

-- --------------------------------------------------------------------------------
-- Step #3: Add data to Gender
-- --------------------------------------------------------------------------------

INSERT INTO TGenders( intGenderID, strGenderDesc)
VALUES		(1, 'Female')
		,(2, 'Male')

---- --------------------------------------------------------------------------------
---- Step #4: Add men's and women's shirt sizes
---- --------------------------------------------------------------------------------

INSERT INTO TShirtSizes( intShirtSizeID, strShirtSizeDesc)
VALUES		(1, 'Mens Small')
		,(2, 'Mens Medium')
		,(3, 'Mens Large')
		,(4, 'Mens XLarge')
		,(5, 'Womens Small')
		,(6, 'Womens Medium')
		,(7, 'Womens Large')
		,(8, 'Womens XLarge')

---- --------------------------------------------------------------------------------
---- Step #5: Add years
---- --------------------------------------------------------------------------------
INSERT INTO TEventYears ( intEventYearID, intEventYear )
	VALUES	 ( 1, 2015)
		,( 2, 2016)
		,(3, 2017)
		,(4, 2018)

---- --------------------------------------------------------------------------------
---- Step #6: Add sponsor types
---- --------------------------------------------------------------------------------
INSERT INTO TSponsorTypes ( intSponsorTypeID, strSponsorTypeDesc)
	VALUES (1, 'Parent')
		,(2, 'Alumni')
		,(3, 'Friend')
		,(4, 'Business')

---- --------------------------------------------------------------------------------
---- Step #7: Add payment types
---- --------------------------------------------------------------------------------
INSERT INTO TPaymentTypes ( intPaymentTypeID, strPaymentTypeDesc)
	VALUES (1, 'Check')
		,(2, 'Cash')
		,(3, 'Credit Card')
---- --------------------------------------------------------------------------------
---- Step #8: Add sponsors
---- --------------------------------------------------------------------------------

INSERT INTO TSponsors ( intSponsorID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail )
VALUES	 ( 1, 'Jim', 'Smith', '1979 Wayne Trace Rd.', 'Willow', 'OH', '42368', '5135551212', 'jsmith@yahoo.com' )
		,( 2, 'Sally', 'Jones', '987 Mills Rd.', 'Cincinnati', 'OH', '45202', '5135551234', 'sjones@yahoo.com' )
		,( 3, 'Glover', 'John', '1121 Riverview Avenue.', 'Dayton', 'OH', '45402', '9375551284', 'johneg@gmail.com' )
		,( 4, 'Langley', 'Patrick', '71 Stroup Rd.', 'Kettering', 'OH', '45407', '9375551055', 'lones@yahoo.com' )

---- --------------------------------------------------------------------------------
---- Step #9: Add golfers
---- --------------------------------------------------------------------------------

INSERT INTO TGolfers ( intGolferID, strGolferFirstName, strGolferLastName, strGolferStreetAddress, strGolferCity, strGolferState, strGolferZip, strGolferPhoneNumber, strGolferEmail, intShirtSizeID, intGenderID )
VALUES	 ( 1, 'Bill', 'Goldstein', '156 Main St.', 'Mason', 'OH', '45040', '5135559999', 'bGoldstein@yahoo.com',  1, 2 )
		,( 2, 'Tara', 'Everett', '3976 Deer Run', 'West Chester', 'OH', '45069', '5135550101', 'teverett@yahoo.com',  6, 1 )
		,( 3, 'Hankaka', 'Lie', '102 firelane Dr', 'New Haven', 'OH', '45012', '5130010101', 'liekak@yahoo.fr',  4, 1 )
		,( 4, 'Tara', 'Ever', '2916 Deer Run', 'West Chester', 'OH', '45069', '5135550707', 'tever@yahoo.com',  8, 2 )

---- --------------------------------------------------------------------------------
---- Step # 10: Add Golfers and sponsors to link them
---- --------------------------------------------------------------------------------

INSERT INTO TGolferEventYears ( intGolferEventYearID, intGolferID, intEventYearID)
	VALUES (1, 1, 1)
		  ,(2, 2, 1)
		  ,(3, 1, 2)
		  ,(4, 2, 2)

---- --------------------------------------------------------------------------------
---- Step # 10: Add Golfers and sponsors to link them
---- --------------------------------------------------------------------------------
INSERT INTO TGolferEventYearSponsors ( intGolferEventYearSponsorID, intGolferID, intEventYearID, intSponsorID, monPledgeAmount, intSponsorTypeID, intPaymentTypeID, blnPaid )
VALUES	 ( 1, 1, 1, 1, 25.00, 1, 1, 1 )
		,( 2, 1, 1, 2, 100.00, 1, 1, 1 )

			




GO 
CREATE PROCEDURE uspDeleteGolfer
	@intGolferID				INTEGER
AS

--SET NOCOUNT ON
SET XACT_ABORT ON 

BEGIN TRANSACTION 

DELETE FROM TGolfers WHERE intGolferID = @intGolferID

DELETE FROM TGolfers WHERE intGolferID = @intGolferID

COMMIT TRANSACTION 
GO

GO
CREATE PROCEDURE uspUpdateGolfer
	 @intGolferID		INTEGER
	,@strGolferFirstName		VARCHAR(50)	
	,@strGolferLastName		VARCHAR(50)		
	,@strGolferStreetAddress	VARCHAR(50)		
	,@strGolferCity			VARCHAR(50)		
	,@strGolferState			VARCHAR(50)		
	,@strGolferZip			VARCHAR(50)		
	,@strGolferPhoneNumber	VARCHAR(50)		
	,@strGolferEmail			VARCHAR(50)	
	,@intShirtSizeID	INTEGER
	,@intGenderID	INTEGER
			
	
AS

--SET NOCOUNT ON
SET XACT_ABORT ON 

BEGIN TRANSACTION

UPDATE TGolfers SET strGolferFirstName = @strGolferFirstName, strGolferLastName = @strGolferLastName, strGolferStreetAddress = @strGolferStreetAddress,
	 strGolferCity = @strGolferCity, strGolferState = @strGolferState,  strGolferZip = @strGolferZip, strGolferPhoneNumber = @strGolferPhoneNumber, strGolferEmail = @strGolferEmail, intShirtSizeID = @intShirtSizeID, intGenderID = @intGenderID
	WHERE intGolferID = @intGolferID
	
	 
	 SELECT @@ROWCOUNT AS intRowsEffected
	 
	
COMMIT TRANSACTION 

GO



GO
CREATE PROCEDURE uspDeleteSponsor
	@intSponsorID					INTEGER
AS

--SET NOCOUNT ON
SET XACT_ABORT ON 

BEGIN TRANSACTION 

DELETE FROM TSponsors WHERE intSponsorID = @intSponsorID

DELETE FROM TSponsors WHERE intSponsorID = @intSponsorID
COMMIT TRANSACTION 
GO



GO



CREATE PROCEDURE uspUpdateSponsor
	 @intSponsorID		INTEGER
	,@strFirstName		VARCHAR(50)	
	,@strLastName		VARCHAR(50)		
	,@strStreetAddress	VARCHAR(50)		
	,@strCity			VARCHAR(50)		
	,@strState			VARCHAR(50)		
	,@strZip			VARCHAR(50)		
	,@strPhoneNumber	VARCHAR(50)		
	,@strEmail			VARCHAR(50)		
	
AS

--SET NOCOUNT ON
SET XACT_ABORT ON 

BEGIN TRANSACTION

UPDATE TSponsors SET strFirstName = @strFirstName, strLastName = @strLastName, strStreetAddress = @strStreetAddress,
	 strCity = @strCity, strState = @strState,  strZip = @strZip, strPhoneNumber = @strPhoneNumber, strEmail = @strEmail
	WHERE intSponsorID = @intSponsorID
	
	 
	 SELECT @@ROWCOUNT AS intRowsEffected
	 
	
COMMIT TRANSACTION 

GO

SELECT  TSponsors.strFirstName + ' ' + TSponsors.strLastName AS Name, TGolferEventYearSponsors.monPledgeAmount
FROM TSponsors
INNER JOIN TGolferEventYearSponsors ON TSponsors.intSponsorID = TGolferEventYearSponsors.intSponsorID
WHERE intEventYearID=1 AND intGolferID=1


  SELECT S.strFirstName + ' ' + S.strLastName + '  |  ' + CAST(GEYS.MonPledgeAmount AS VARCHAR(10))
  FROM [dbSQL1].[dbo].[TGolferEventYearSponsors] AS GEYS
  INNER JOIN TSponsors S ON S.intSponsorID = GEYS.intSponsorID
  WHERE intGolferID = 1 AND intEventYearID = 1
