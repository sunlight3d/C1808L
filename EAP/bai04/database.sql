-- Create database template
-- =============================================
-- Drop the database if it already exists
drop database dbChat;
create database dbChat;

CREATE TABLE tblUser(
	UserName NVARCHAR(200) PRIMARY KEY,
	Password NVARCHAR(200)
)

CREATE TABLE tblChat(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Content NVARCHAR(1000),
	UserName NVARCHAR(200) not null references tblUser(UserName),	
	SentTime DateTime
)

INSERT INTO tblUser(UserName, Password)
VALUES('hoangnd', '123456');
INSERT INTO tblChat(Content, UserName, SentTime)
VALUES('Chao ban', 'hoangnd', GETDATE())
INSERT INTO tblChat(Content, UserName, SentTime)
VALUES('how are you ?', 'hoangnd', GETDATE())
INSERT INTO tblChat(Content, UserName, SentTime)
VALUES('I''m fine', 'hoangnd', GETDATE())

select * from tblUser;
select * from tblChat;