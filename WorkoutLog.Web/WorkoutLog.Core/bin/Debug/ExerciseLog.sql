/**********************************************************/
-- Script: Exercise.sql
-- Author: Quayne
-- Date: May 5, 2015
-- Description: Create Exercise Database objects for Workout log
/**********************************************************/

-- Setting NOCOUNT ON suppresses completion messages for each INSERT
SET NOCOUNT ON

-- Set date format to year, month, day
SET DATEFORMAT ymd;

-- Make the master database the current database
USE master

-- If database Exercise exists, drop it
IF EXISTS ( SELECT  * FROM sysdatabases WHERE name = 'Exercise' )
  DROP DATABASE Exercise;
GO

-- Create the Exercise database
CREATE DATABASE Exercise;
GO

-- Make the Exercise database the current database
USE Exercise;

-- Create ExerciseType table
CREATE TABLE ExerciseType ( 
	ID INT IDENTITY NOT NULL , 
	ExerciseName NVARCHAR(200) NOT NULL , 
	CONSTRAINT PK_ExerciseType PRIMARY KEY ( ID ) 
) ;


-- Create Sales table
CREATE TABLE BodyParts ( 
	ID INT IDENTITY NOT NULL , 
	BodyParts NVARCHAR(200) NOT NULL , 
	CONSTRAINT PK_BodyParts PRIMARY KEY ( ID )
) ;


-- Create Persons table
CREATE TABLE Persons ( 
	EmailAddress NVARCHAR(70) NOT NULL , 
	UserName NVARCHAR(70) NOT NULL , 
	UserPassword NVARCHAR(70) NOT NULL , 
	CONSTRAINT PK_Persons PRIMARY KEY ( EmailAddress )
 ) ;

 -- Create Exercise table
CREATE TABLE Exercise ( 
  ID INT IDENTITY NOT NULL , 
  CurrentDate DATETIME NOT NULL , 
  ExerciseSets INT NOT NULL , 
  Weights DECIMAL(5,2) NOT NULL ,
  Reps INT NOT NULL ,
  EmailAddress NVARCHAR(70) NOT NULL,
  BodyPartID INT NOT NULL,
  ExerciseTypeID INT NOT NULL,
  CONSTRAINT PK_Exercise PRIMARY KEY ( ID ) ,
  CONSTRAINT FK_Exercise_ExerciseType_ID FOREIGN KEY ( ExerciseTypeID ) REFERENCES ExerciseType ( ID ),
  CONSTRAINT FK_Persons_EmailAddress FOREIGN KEY ( EmailAddress ) REFERENCES Persons ( EmailAddress ),
  CONSTRAINT FK_BodyParts_ID FOREIGN KEY ( BodyPartID ) REFERENCES BodyParts ( ID )
 ) ; 

-- Insert BodyParts records
INSERT INTO BodyParts (BodyParts) VALUES('Biceps');
INSERT INTO BodyParts (BodyParts) VALUES('Abdominals');
INSERT INTO BodyParts (BodyParts) VALUES('Shoulders');
INSERT INTO BodyParts (BodyParts) VALUES('Chest');
INSERT INTO BodyParts (BodyParts) VALUES('Calves');
INSERT INTO BodyParts (BodyParts) VALUES('Triceps');
INSERT INTO BodyParts (BodyParts) VALUES('Forearms');
INSERT INTO BodyParts (BodyParts) VALUES('Hamstrings');
INSERT INTO BodyParts (BodyParts) VALUES('Neck');
INSERT INTO BodyParts (BodyParts) VALUES('Lower Back');
INSERT INTO BodyParts (BodyParts) VALUES('Lats');
GO

-- Insert ExerciseType records
INSERT INTO ExerciseType (ExerciseName) VALUES( 'ALTERNATE INCLINE DUMBBELL CURL');
INSERT INTO ExerciseType (ExerciseName) VALUES( 'DECLINE DUMBBELL FLYES');
INSERT INTO ExerciseType (ExerciseName) VALUES( 'CABLE CHEST PRESS');
INSERT INTO ExerciseType (ExerciseName) VALUES( 'PIN PRESSES');
INSERT INTO ExerciseType (ExerciseName) VALUES( 'RACK PULLS');
INSERT INTO ExerciseType (ExerciseName) VALUES( 'DEADLIFT WITH BANDS');
GO

-- Insert Persons records
INSERT INTO Persons VALUES( 'quayne@gmail.com', 'Quayne', '123');
INSERT INTO Persons VALUES( 'quayne@live.com', 'Brown', '123');
INSERT INTO Persons VALUES( 'quayne@hotmail.com', 'Hazza', '123');
GO

-- Insert Exercise records
INSERT INTO Exercise VALUES( '2015-05-05', 1, 50, 10, 'quayne@gmail.com', 1, 1);
GO