-- CREATE
CREATE TABLE user_data (
	user_id INT PRIMARY KEY IDENTITY(1,1),
	user_name VARCHAR(200),
	created_on DATETIME DEFAULT GETDATE(),
	modified_on DATETIME DEFAULT GETDATE(),
	is_active BIT DEFAULT 1
)
GO

-- DROP
-- DROP TABLE user_data
GO

-- SELECT
SELECT * from user_data
GO

-- INSERT
INSERT INTO user_data(user_name) values('Alice')
INSERT INTO user_data(user_name) values('Bob')
INSERT INTO user_data(user_name) values('Trudy'),('Frank'),('Micheal'),('Michelle');
GO

-- UPDATE
UPDATE user_data
SET user_name = 'user11'
where user_id = 1
GO

-- DELETE
delete from user_data
where user_id = 4
GO

-- STORED PROCEDURE
-- getAllUsers
CREATE PROCEDURE getAllUsers
AS
	SELECT user_id,user_name from user_data
	where is_active = 1;
GO

EXECUTE getAllUsers
GO

-- getUser
CREATE PROCEDURE getUser
	@userId INT
AS
	SELECT user_id, user_name from user_data
	where user_id = @userId and is_active = 1
GO

EXECUTE getUser 2
GO


-- HOMEWORK --



-- HOMEWORK 1 (EASY)
-- update records stored procedure
CREATE PROCEDURE updateUserData
	@newUserName VARCHAR(200),
	@userId INT
AS
	UPDATE user_data
	SET user_name = @newUserName
	where user_id = @userId
GO

-- HOMEWORK 2 (EASY)
-- delete records stored procedure
CREATE PROCEDURE deleteUserData
	@userId INT
AS
	DELETE from user_data
	where user_id = @userId
GO

-- HOMEWORK 3 (MEDIUM)
CREATE TABLE user_phone_book (
	record_id INT PRIMARY KEY IDENTITY(1,1),
	user_id INT FOREIGN KEY REFERENCES user_data(user_id),
	person_id INT FOREIGN KEY REFERENCES user_data(user_id),
	created_on DATETIME DEFAULT GETDATE(),
	modified_on DATETIME DEFAULT GETDATE(),
	is_active BIT DEFAULT 1
)

-- DROP TABLE user_phone_book

SELECT * from user_phone_book

INSERT INTO user_phone_book (user_id, person_id) VALUES (1,2),(1,3),(1,4),(2,5),(2,6)

CREATE PROCEDURE getContactIdsForUser
	@userId INT
AS
	SELECT person_id from user_phone_book
	where user_id = @userId and is_active = 1
GO

-- HOMEWORK 4 (HARD)
ALTER PROCEDURE getContactNamesForUser
	@userId INT
AS
	SELECT A.user_id, A.user_name from user_data A
	INNER JOIN user_phone_book B
	on A.user_id = B.person_id
	where B.user_id = @userId and B.is_active = 1
GO

EXECUTE getContactNamesForUser 2
GO

CREATE PROCEDURE addUser
	@userName VARCHAR(200)
AS
	INSERT INTO user_data(user_name) VALUES (@userName)
GO


CREATE PROCEDURE addUserPhonebook
	@userId INT,
	@personId INT
AS
	INSERT INTO user_phone_book(user_id, person_id) VALUES (@userId, @personId)
GO

CREATE PROCEDURE updateUserPhonebook
	@userId INT,
	@personId INT,
	@newPersonId INT
AS
	UPDATE user_phone_book
	set person_id = @newPersonId
	where user_id =@userId and person_id = @personId
GO

CREATE PROCEDURE deleteUserPhonebook
	@userId INT,
	@personId INT
AS
	DELETE from user_phone_book
	where user_id =@userId and person_id = @personId
GO

