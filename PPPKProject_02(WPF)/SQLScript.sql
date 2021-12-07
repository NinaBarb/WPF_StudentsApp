drop database people

create database people
use people

-----------------------------------------
--------------TABLES---------------------
-----------------------------------------
create table Person
(
	IDPerson int constraint PK_Person primary key identity,
	FirstName nvarchar(50),
	LastName nvarchar(50),
	Age int,
	JMBAG nvarchar(10),
	Gender nvarchar(50),
	Email nvarchar(50),
	Picture Image
)
go

create table Position
(
	IDPosition int constraint PK_Position primary key identity,
	Title nvarchar(50)
)
go

create table PositionPerson
(
	IDPositionPerson int constraint PK_PositionPerson primary key identity,
	PersonID int constraint FK_PersonPosition foreign key references Person(IDPerson),
	PositionID int constraint FK_Position foreign key references Position(IDPosition)
)
go

create table Course
(
	IDCourse int constraint PK_Course primary key identity,
	Title nvarchar(50),
	ECTS int
)
go

drop table PersonCourse
create table PersonCourse
(
	IDPersonCourse int constraint PK_PersonCourse primary key identity,
	CourseID int constraint FK_Course foreign key references Course(IDCourse),
	PersonID int constraint FK_PersonCourse foreign key references Person(IDPerson),
	PositionID int constraint FK_PositionPersonCourse foreign key references Position(IDPosition),
)
go


-----------------------------------------
--------------PERSON---------------------
-----------------------------------------
create proc CreatePerson
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Age int,
	@JMBAG nvarchar(50),
	@Gender nvarchar(50),
	@Email nvarchar(50),
	@Picture image,
	@IDPerson int output
as
begin 
	BEGIN 
		IF exists (select * from Person as p where p.FirstName = @FirstName and p.LastName = @LastName)
			BEGIN
				select @IDPerson = p.IDPerson from Person as p where p.FirstName = @FirstName and p.LastName = @LastName
			END
		ELSE
			BEGIN
				INSERT INTO Person VALUES(@FirstName, @LastName, @Age, @JMBAG , @Gender, @Email, @Picture)
				SET @IDPerson = SCOPE_IDENTITY()
			END		
	END
end
go

alter procedure UpdatePerson
	@FirstName nvarchar(300),
	@LastName nvarchar(90),
	@Age int,
	@JMBAG nvarchar(50),
	@Gender nvarchar(50),
	@Email nvarchar(50),
	@Picture image,
	@IDPerson int 
as 
begin 
	update PersonCourse set
		PersonID = @IDPerson
	where 
		PersonID = @IDPerson
	update Person set
		FirstName = @FirstName,
		LastName = @LastName,
		Age = @Age,
		JMBAG = @JMBAG,
		Gender = @Gender,
		Email = @Email,
		Picture = @Picture
	where 
		IDPerson = @IDPerson
end
go

create procedure DeletePerson
	@IDPerson int
as 
begin 
	delete from PersonCourse
	where PersonCourse.PersonID=@IDPerson
	delete from Person
	where IDPerson= @IDPerson
end
go

create procedure GetPerson
	@IDPerson int
as 
begin 
	select * from Person
	where IDPerson = @IDPerson
end
go

create procedure GetPeople
as 
begin
	select * from Person
end
go


-----------------------------------------
--------------COURSE---------------------
-----------------------------------------
create proc CreateCourse
	@Title nvarchar(50),
	@ECTS int,
	@IDCourse int output
as
begin
	BEGIN 
		IF exists (select * from Course as c where c.Title=@Title)
			BEGIN
				select @IDCourse = c.IDCourse from Course as c where c.Title = @Title and c.ECTS = @ECTS
			END
		ELSE
			BEGIN
				INSERT INTO Course VALUES(@Title, @ECTS)
				SET @IDCourse = SCOPE_IDENTITY()
			END		
	END
end
go

create proc UpdateCourse
	@Title nvarchar(50),
	@ECTS int,
	@IDCourse int
as
begin 
	update Course set
		Title = @Title,
		ECTS = @ECTS
	where 
		IDCourse = @IDCourse
end
go

create procedure DeleteCourse
	@IDCourse int
as 
begin 
	delete from Course
	where IDCourse= @IDCourse
end
go

create procedure GetCourse
	@IDCourse int
as 
begin 
	select * from Course
	where IDCourse = @IDCourse
end
go

create procedure GetCourses
as 
begin
	select * from Course
end
go
-----------------------------------------
-----------------POSITION----------------
-----------------------------------------
create proc CreatePosition
	@Title nvarchar(50),
	@IDPosition int output
as
begin
	BEGIN 
		IF exists (select * from Position as c where c.Title=@Title)
			BEGIN
				select @IDPosition = c.IDPosition from Position as c where c.Title = @Title
			END
		ELSE
			BEGIN
				INSERT INTO Position VALUES(@Title)
				SET @IDPosition = SCOPE_IDENTITY()
			END		
	END
end
go

alter proc UpdatePosition
	@Title nvarchar(50),
	@IDPosition int
as
begin 
	update PersonCourse set
		PositionID = @IDPosition
	where 
		PositionID = @IDPosition
	update Position set
		Title = @Title
	where 
		IDPosition = @IDPosition
end
go

alter procedure DeletePosition
	@IDPosition int
as 
begin 
	delete from PositionPerson
	where PositionID = @IDPosition
	delete from Position
	where IDPosition = @IDPosition
end
go

create procedure GetPosition
	@IDPosition int
as 
begin 
	select * from Position
	where IDPosition = @IDPosition
end
go

create procedure GetPositions
as 
begin
	select * from Position
end
go

-----------------------------------------
--------------PERSON_COURSE--------------
-----------------------------------------
alter proc CreatePersonCourse
	@CourseID int,
	@PersonID int,
	@PositionID int,
	@IDPersonCourse int output
as
begin
	INSERT INTO PersonCourse VALUES(@CourseID, @PersonID, @PositionID)
	SET @IDPersonCourse = SCOPE_IDENTITY()
end
go

alter proc UpdatePersonCourse
	@CourseID int,
	@PersonID int,
	@PositionID int,
	@IDPersonCourse int output
as
begin
	update PersonCourse set
		CourseID = @CourseID,
		PersonID = @PersonID,
		PositionID = @PositionID
	where 
		IDPersonCourse = @IDPersonCourse
end
go

create procedure DeletePersonOnCourse
	@IdPerson int,
	@IDCourse int
as 
begin 
	delete from PersonCourse
	where PersonID= @IdPerson and CourseID=@IDCourse
end
go

create procedure GetPersonCourse
	@IDPersonCourse int
as 
begin 
	select * from PersonCourse
	where IDPersonCourse = @IDPersonCourse
end
go

alter procedure GetPeopleCourses
	@IDCourse int
as 
begin
	select Person.IDPerson, Person.FirstName, Person.LastName, Person.Age, Person.JMBAG, Person.Gender, Person.Email, Person.Picture, Position.Title as PositionTitle FROM PersonCourse 
	INNER JOIN Person on Person.IDPerson = PersonCourse.PersonID
	INNER JOIN Position on PersonCourse.PositionID = Position.IDPosition
	WHERE PersonCourse.CourseID = @IDCourse
end
go
-----------------------------------------
--------------PERSON_POSITION------------
-----------------------------------------
create proc CreatePositionPerson
	@PersonID int,
	@PositionID nvarchar(20),
	@IDPositionPerson int output
as
begin
	INSERT INTO PositionPerson VALUES(@PersonID, @PositionID)
	SET @IDPositionPerson = SCOPE_IDENTITY()
end
go

create proc UpdatePositionPerson
	@PersonID int,
	@PositionID nvarchar(20),
	@IDPositionPerson int output
as
begin
	update PositionPerson set
		PersonID = @PersonID,
		PositionID = @PositionID
	where 
		IDPositionPerson = @IDPositionPerson
end
go

--insert into Person(FirstName, LastName, Age, JMBAG, Gender, Email, Position, Picture)
--values ('Nina', 'Ninic', 22, '1234567891', 'Female', 'jahsjs@gmail.com', 'Student', null)
--insert into Person(FirstName, LastName, Age, JMBAG, Gender, Email, Position, Picture)
--values ('Pero', 'Peric', 45, '1234566891', 'Male', 'jahsjs@gmail.com', 'Assistant', null)
select*from Person
select*from Course
select*from PersonCourse
inner join Person on PersonCourse.PersonID=Person.IDPerson
inner join Course on PersonCourse.CourseID=Course.IDCourse
inner join Position on PersonCourse.PositionID = Position.IDPosition 


delete from PersonCourse

--delete from Person
--where IDPerson=2