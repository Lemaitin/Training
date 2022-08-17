CREATE DATABASE SecretManagerDB;
USE SecretManagerDB;
CREATE TABLE SecretAudit
(
SecretAuditId INT IDENTITY PRIMARY KEY NOT NULL,
SecretId INT NOT NULL,
Message NVARCHAR(MAX) NOT NULL,
CreationTime DATETIME NOT NULL,
ModificationTime DATETIME NOT NULL
);
CREATE TABLE Categories
(
CategoriesId INT IDENTITY PRIMARY KEY NOT NULL,
Name NVARCHAR (30) NOT NULL,
);
CREATE TABLE Users
(
UserId INT IDENTITY PRIMARY KEY NOT NULL,
FirstName NVARCHAR (58) NOT NULL,
LastName NVARCHAR (100) NOT NULL,
Login NVARCHAR (30) UNIQUE NOT NULL,
MasterKey NVARCHAR(50) UNIQUE NOT NULL,
Email NVARCHAR (50) UNIQUE NOT NULL,
);
CREATE TABLE Secrets
(
SecretId INT IDENTITY PRIMARY KEY NOT NULL,
Value NVARCHAR(MAX) NOT NULL,
ExperationDate DATETIME NOT NULL,
UserId INT NOT NULL,
CategoriesId INT NOT NULL,
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
FROM inserted;

GO
CREATE TRIGGER Trigger_AuditSecret_Record_DEL
ON [dbo].[Secrets]
AFTER DELETE
AS
INSERT INTO SecretAudit(SecretId, Message)
SELECT SecretId, ' password deleted: ' + Value
FROM deleted;

----------------------------------PROCEDURE-----------------------------------------------
--------INSERT----------
GO
CREATE PROCEDURE [dbo].[InsertCategories]
@Name NVARCHAR(30),
@CategoriesId INT OUTPUT
AS
BEGIN
SET NOCOUNT ON
INSERT INTO Categories
(Name)
VALUES
(@Name)
SET @CategoriesId = @@IDENTITY
RETURN
END;

GO
CREATE PROCEDURE [dbo].[InsertUsers]
@FirstName NVARCHAR(58),
@LastName NVARCHAR(100),
@Login NVARCHAR(30),
@MasterKey NVARCHAR(50),
@Email NVARCHAR(50),
@UserId INT OUTPUT
AS
BEGIN
SET NOCOUNT ON
INSERT INTO Users
(FirstName, LastName, Login, MasterKey, Email)
VALUES
(@FirstName,@LastName,@Login,@MasterKey,@Email)
SET @UserId = @@IDENTITY
RETURN
END

GO
CREATE PROCEDURE [dbo].[InsertSecrets]
@Value NVARCHAR(MAX),
@ExperationDate DATETIME,
@UserId INT,
@CategoriesId INT,
@SecretId INT OUTPUT
AS
BEGIN
SET NOCOUNT ON
INSERT INTO Secrets
(Value, ExperationDate, UserId, CategoriesId)
VALUES
(@Value, @ExperationDate, @UserId, @CategoriesId)
SET @SecretId = @@IDENTITY
RETURN
END

--------UPDATE----------
GO
CREATE PROCEDURE [dbo].[UpdateCategories]
@CategoriesId INT,
@Name NVARCHAR(30)
AS
BEGIN
UPDATE Categories SET Name = @Name
WHERE CategoriesId = @CategoriesId
END

GO
CREATE PROCEDURE [dbo].[UpdateUsers]
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
CREATE PROCEDURE [dbo].[UpdateSecrets]
@SecretId INT,
@Value NVARCHAR(MAX),
@ExperationDate DATETIME,
@UserId INT,
@CategoriesId INT
AS
BEGIN
UPDATE Secrets 
SET 
Value = @Value, ExperationDate = @ExperationDate, UserId = @UserId, CategoriesId = @CategoriesId
WHERE SecretId = @SecretId
END

--------DELETE----------
GO
CREATE PROCEDURE [dbo].[DeleteCategories]
AS
BEGIN
DELETE FROM Categories
END

GO
CREATE PROCEDURE [dbo].[DeleteSecrets]
AS
BEGIN
DELETE FROM Secrets
END

GO
CREATE PROCEDURE [dbo].[DeleteUsers]
AS
BEGIN
DELETE FROM Users
END

----------------------------------JOBS-----------------------------------------------

--------INSERT JOB---------
USE [msdb]
GO
DECLARE @jobId BINARY(16)
EXEC  msdb.dbo.sp_add_job @job_name=N'InsertJob', 
		@enabled=1, 
		@notify_level_eventlog=0, 
		@notify_level_email=2, 
		@notify_level_page=2, 
		@delete_level=0, 
		@category_name=N'[Uncategorized (Local)]', 
		@owner_login_name=N'DESKTOP-LGLE7HE\iliam', @job_id = @jobId OUTPUT
select @jobId
GO
EXEC msdb.dbo.sp_add_jobserver 
@job_name=N'InsertJob', 
@server_name = N'DESKTOP-LGLE7HE'
GO
USE [msdb]
GO
EXEC msdb.dbo.sp_add_jobstep @job_name=N'InsertJob', @step_name=N'Teststep', 
		@step_id=1, 
		@cmdexec_success_code=0, 
		@on_success_action=1, 
		@on_fail_action=2, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=
N'
DECLARE @Data VARCHAR(255) = CONVERT(varchar(255), NEWID())
DECLARE @CategoriesId INT
EXECUTE InsertCategories @Name = @Data, @CategoriesId = @CategoriesId OUTPUT

DECLARE @UserId INT
EXECUTE InsertUsers @FirstName = @Data, @LastName = @Data, @Login = @Data, @MasterKey = @Data, @Email = @Data, @UserId = @UserId OUTPUT

DECLARE @SecretId INT, @ExperationDate DATETIME
SELECT @ExperationDate = GETDATE()
EXECUTE InsertSecrets @Value = @Data, @ExperationDate = @ExperationDate, @UserId = @UserId, @CategoriesId = @CategoriesId, @SecretId = @SecretId OUTPUT
', 
		@database_name=N'SecretManagerDB', 
		@flags=0
GO
USE [msdb]
GO
EXEC msdb.dbo.sp_update_job @job_name=N'InsertJob', 
		@enabled=1, 
		@start_step_id=1, 
		@notify_level_eventlog=0, 
		@notify_level_email=2, 
		@notify_level_page=2, 
		@delete_level=0, 
		@description=N'', 
		@category_name=N'[Uncategorized (Local)]', 
		@owner_login_name=N'DESKTOP-LGLE7HE\iliam', 
		@notify_email_operator_name=N'', 
		@notify_page_operator_name=N''
GO
USE [msdb]
GO
DECLARE @schedule_id int
EXEC msdb.dbo.sp_add_jobschedule @job_name=N'InsertJob', @name=N'testshce', 
		@enabled=1, 
		@freq_type=4, 
		@freq_interval=1, 
		@freq_subday_type=4, 
		@freq_subday_interval=1, 
		@freq_relative_interval=0, 
		@freq_recurrence_factor=1, 
		@active_start_date=20220810, 
		@active_end_date=99991231, 
		@active_start_time=0, 
		@active_end_time=235959, @schedule_id = @schedule_id OUTPUT
select @schedule_id
GO



--------DELETE JOB---------
USE [msdb]
GO
DECLARE @jobId BINARY(16)
EXEC  msdb.dbo.sp_add_job @job_name=N'DeleteJob', 
		@enabled=1, 
		@notify_level_eventlog=0, 
		@notify_level_email=2, 
		@notify_level_page=2, 
		@delete_level=0, 
		@category_name=N'[Uncategorized (Local)]', 
		@owner_login_name=N'DESKTOP-LGLE7HE\iliam', @job_id = @jobId OUTPUT
select @jobId
GO
EXEC msdb.dbo.sp_add_jobserver 
@job_name=N'DeleteJob', 
@server_name = N'DESKTOP-LGLE7HE'
GO
USE [msdb]
GO
EXEC msdb.dbo.sp_add_jobstep @job_name=N'DeleteJob', @step_name=N'Teststep', 
		@step_id=1, 
		@cmdexec_success_code=0, 
		@on_success_action=1, 
		@on_fail_action=2, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=
N'
EXEC DeleteCategories;
EXEC DeleteSecrets;
EXEC DeleteUsers;
', 
		@database_name=N'SecretManagerDB', 
		@flags=0
GO
USE [msdb]
GO
EXEC msdb.dbo.sp_update_job @job_name=N'DeleteJob', 
		@enabled=1, 
		@start_step_id=1, 
		@notify_level_eventlog=0, 
		@notify_level_email=2, 
		@notify_level_page=2, 
		@delete_level=0, 
		@description=N'', 
		@category_name=N'[Uncategorized (Local)]', 
		@owner_login_name=N'DESKTOP-LGLE7HE\iliam', 
		@notify_email_operator_name=N'', 
		@notify_page_operator_name=N''
GO
USE [msdb]
GO
DECLARE @schedule_id int
EXEC msdb.dbo.sp_add_jobschedule @job_name=N'DeleteJob', @name=N'testshce', 
		@enabled=1, 
		@freq_type=4, 
		@freq_interval=1, 
		@freq_subday_type=4, 
		@freq_subday_interval=15, 
		@freq_relative_interval=0, 
		@freq_recurrence_factor=1, 
		@active_start_date=20220810, 
		@active_end_date=99991231, 
		@active_start_time=0, 
		@active_end_time=235959, @schedule_id = @schedule_id OUTPUT
select @schedule_id
GO