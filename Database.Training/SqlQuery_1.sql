CREATE DATABASE SecretManagerDB;
USE SecretManagerDB;
CREATE TABLE AuditLogs
(
AuditId INT IDENTITY PRIMARY KEY NOT NULL,
Message NVARCHAR(MAX) NOT NULL,
CreationTime DATETIME NOT NULL,
ModificationTime DATETIME NOT NULL
);
CREATE TABLE Categories
(
CategoriesId INT IDENTITY PRIMARY KEY NOT NULL,
Name NVARCHAR (30) NOT NULL,
AuditId INT NOT NULL,
CONSTRAINT FK_AuditLogs_Categories FOREIGN KEY (AuditId) REFERENCES AuditLogs(AuditId)
);
CREATE TABLE Users
(
UserId INT IDENTITY PRIMARY KEY NOT NULL,
FirstName NVARCHAR (58) NOT NULL,
LastName NVARCHAR (100) NOT NULL,
Login NVARCHAR (30) UNIQUE NOT NULL,
MasterKey NVARCHAR(50) UNIQUE NOT NULL,
Email NVARCHAR (50) UNIQUE NOT NULL,
AuditId INT NOT NULL,
CONSTRAINT Fk_AuditLogs_Users FOREIGN KEY (AuditId) REFERENCES AuditLogs(AuditId)
);
CREATE TABLE Secrets
(
SecretId INT IDENTITY PRIMARY KEY NOT NULL,
Value NVARCHAR(MAX) NOT NULL,
ExperationDate DATETIME NOT NULL,
AuditId INT NOT NULL,
UserId INT NOT NULL,
CategoriesId INT NOT NULL,
CONSTRAINT Fk_AuditLogs_Secrets FOREIGN KEY (AuditId) REFERENCES AuditLogs(AuditId),
CONSTRAINT Fk_Users_Secrets FOREIGN KEY (UserId) REFERENCES Users(UserId),
CONSTRAINT FK_Categories_Secrets FOREIGN KEY (CategoriesId) REFERENCES Categories(CategoriesId)
)

----------------------------------TRIGGER-----------------------------------------------
USE SecretManagerDB;
GO
CREATE TRIGGER Trigger_AuditSecret_Record
ON Secrets
AFTER INSERT, UPDATE
AS
INSERT INTO SecretAudit(SecretId, Message)
SELECT SecretId, ' Добавлен пароль: ' + Value
FROM inserted


----------------------------------PROCEDURE-----------------------------------------------
--------INSERT----------
GO
CREATE PROCEDURE InsertCategories
@CategoriesId INT,
@Name NVARCHAR(30)
AS
BEGIN
SET NOCOUNT ON
INSERT INTO Categories
(CategoriesId, Name)
VALUES
(@CategoriesId),
(@Name)
SELECT * FROM Categories
WHERE CategoriesId = @CategoriesId AND Name = @Name
END
GO


USE SecretManagerDB;
GO
CREATE PROCEDURE InsertUsers
@UserId INT,
@FirstName NVARCHAR(58),
@LastName NVARCHAR(100),
@Login NVARCHAR(30),
@MasterKey NVARCHAR(50),
@Email NVARCHAR(50)
AS
BEGIN
SET NOCOUNT ON
INSERT INTO Users
(UserId, FirstName, LastName, Login, MasterKey, Email)
VALUES
(@UserId, @FirstName,@LastName,@Login,@MasterKey,@Email)
SELECT * FROM Users
WHERE UserId = @UserId
END
GO


USE SecretManagerDB;
GO
CREATE PROCEDURE InsertSecrets
@Value NVARCHAR(MAX),
@ExperationDate DATETIME,
@UserId INT,
@CategoriesId INT
AS
BEGIN
SET NOCOUNT ON
INSERT INTO Secrets
(Value, ExperationDate, UserId, CategoriesId)
VALUES
(@Value, @ExperationDate, @UserId, @CategoriesId)
SELECT * FROM Secrets
WHERE Value = @Value
END
GO

--------UPDATE----------
Use SecretManagerDB;
GO
CREATE PROCEDURE UpdateCategories
@CategoriesId INT,
@Name NVARCHAR(30)
AS
BEGIN
UPDATE Categories SET Name = @Name
WHERE CategoriesId = @CategoriesId
END


GO
CREATE PROCEDURE UpdateUsers
@UserId INT,
@FirstName NVARCHAR(58),
@LastName NVARCHAR(100),
@Login NVARCHAR(30),
@MasterKey NVARCHAR(50),
@Email NVARCHAR(50)
AS
BEGIN
UPDATE Users 
SET 
FirstName = @FirstName, LastName = @LastName, Login = @Login, MasterKey = @MasterKey, Email = @Email
WHERE UserId = @UserId
END

GO
CREATE PROCEDURE UpdateSecrets
@SecretId INT,
@Value NVARCHAR(MAX),
@ExperationDate DATETIME,
@UserId INT,
@CategoriesId INT
AS
BEGIN
UPDATE Secrets
SET 
Value= @Value, ExperationDate= @ExperationDate, UserId= @UserId, CategoriesId= @CategoriesId
WHERE SecretId = @SecretId
END

--------DELETE----------
GO
CREATE PROCEDURE DeleteCategories
@CategoriesId INT,
@Name NVARCHAR(30)
AS
BEGIN
DELETE FROM Categories WHERE CategoriesId = @CategoriesId AND Name = @Name
END
GO


Use SecretManagerDB;
GO
CREATE PROCEDURE DeleteSecrets
@SecretId INT,
@Value NVARCHAR(MAX),
@ExperationDate DATETIME,
@UserId INT,
@CategoriesId INT
AS
BEGIN
DELETE FROM Secrets WHERE SecretId = @SecretId AND Value = @Value AND ExperationDate = @ExperationDate AND UserId = @UserId AND CategoriesId = @CategoriesId
END
GO

Use SecretManagerDB;
GO
CREATE PROCEDURE DeleteUsers
@UserId INT,
@FirstName NVARCHAR(58),
@LastName NVARCHAR(100),
@Login NVARCHAR(30),
@MasterKey NVARCHAR(50),
@Email NVARCHAR(50)
AS
BEGIN
DELETE FROM Users WHERE UserId = @UserId AND FirstName = @FirstName AND LastName = @LastName AND Login = @Login AND MasterKey = @MasterKey AND Email = @Email
END
GO